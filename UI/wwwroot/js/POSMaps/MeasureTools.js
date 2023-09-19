var MeasureTools = (function () {
    var source;
    var draw, wgs84Sphere, pointerMoveHandler;
    //Overlay to show the help messages. @type {ol.Overlay}
    var helpTooltip;
    //Overlay to show the measurement. @type {ol.Overlay}
    var measureTooltip;
    var removedMeasureTooltips, drawstart, drawend, drawStyle;

    var Layer = new ol.layer.Vector({
        title: 'القياسات',
        zIndex: 1
    });;

    function Init(type) {
        InitSphere();
        removedMeasureTooltips = [];
        //Currently drawn feature. @type {ol.Feature}
        var sketch;
        //The help tooltip element. @type {Element}
        var helpTooltipElement;
        //The measure tooltip element. @type {Element}
        var measureTooltipElement;

        //Message to show when the user is drawing a polygon.
        var continuePolygonMsg = 'إضغط لرسم المضلع';

        //Message to show when the user is drawing a line.
        var continueLineMsg = 'إضغط لرسم الخط';

        source = new ol.source.Vector();
        Layer.setSource(source);
        Layer.setStyle(new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(255, 255, 255, 0.2)'
            }),
            stroke: new ol.style.Stroke({
                color: '#ffcc33',
                width: 2
            }),
            image: new ol.style.Circle({
                radius: 7,
                fill: new ol.style.Fill({
                    color: '#ffcc33'
                })
            })
        }));

        drawStyle = new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(255, 255, 255, 0.2)'
            }),
            stroke: new ol.style.Stroke({
                color: 'rgba(0, 0, 0, 0.5)',
                lineDash: [10, 10],
                width: 2
            }),
            image: new ol.style.Circle({
                radius: 5,
                stroke: new ol.style.Stroke({
                    color: 'rgba(0, 0, 0, 0.7)'
                }),
                fill: new ol.style.Fill({
                    color: 'rgba(255, 255, 255, 0.2)'
                })
            })
        });

        pointerMoveHandler = function (evt) {
            if (evt.dragging) {
                return;
            }
            /** @type {string} */
            var helpMsg = 'إضغط لبدأ الرسم';
            /** @type {ol.Coordinate|undefined} */
            var tooltipCoord = evt.coordinate;

            if (sketch) {
                var output;
                var geom = (sketch.getGeometry());
                if (geom instanceof ol.geom.Polygon) {
                    output = formatArea(/** @type {ol.geom.Polygon} */(geom));
                    helpMsg = continuePolygonMsg;
                    tooltipCoord = geom.getInteriorPoint().getCoordinates();
                } else if (geom instanceof ol.geom.LineString || geom instanceof ol.geom.Line) {
                    output = formatLength( /** @type {ol.geom.LineString} */(geom));
                    helpMsg = continueLineMsg;
                    tooltipCoord = geom.getLastCoordinate();
                }
                measureTooltipElement.innerHTML = output;
                measureTooltip.setPosition(tooltipCoord);
            }

            helpTooltipElement.innerHTML = helpMsg;
            helpTooltip.setPosition(evt.coordinate);
        };

        /**
         * Creates a new help tooltip
         */
        function createHelpTooltip() {
            helpTooltipElement = document.createElement('div');
            helpTooltipElement.className = 'mtooltip';
            helpTooltip = new ol.Overlay({
                element: helpTooltipElement,
                offset: [15, 0],
                positioning: 'center-left'
            });
            map.addOverlay(helpTooltip);
        }

        /**
         * Creates a new measure tooltip
         */
        function createMeasureTooltip() {
            if (measureTooltipElement) {
                measureTooltipElement.parentNode.removeChild(measureTooltipElement);
            }
            measureTooltipElement = document.createElement('div');
            measureTooltipElement.className = 'mtooltip tooltip-measure';
            measureTooltip = new ol.Overlay({
                element: measureTooltipElement,
                offset: [0, -15],
                positioning: 'bottom-center'
            });
            map.addOverlay(measureTooltip);
        }

        Layer.on('change:visible', function () {
            SetToolTipVisibility(Layer.getVisible());
        });

        drawstart = function (evt) {
            sketch = evt.feature;
        };

        drawend = function (evt) {
            measureTooltipElement.className = 'mtooltip tooltip-static';
            measureTooltip.setOffset([0, -7]);
            // unset sketch
            sketch = null;
            // unset tooltip so that a new one can be created
            removedMeasureTooltips.push(measureTooltipElement);
            measureTooltipElement = null;
            createMeasureTooltip();
        };

        map.on('pointermove', pointerMoveHandler);
        addInteraction(type);
        createMeasureTooltip();
        createHelpTooltip();
    }

    function SetToolTipVisibility(state) {
        var className = 'mtooltip tooltip-static';
        if (!state)
            className = className + ' hide-tooltip';
        for (var i = 0; i < removedMeasureTooltips.length; i++) {
            removedMeasureTooltips[i].className = className;
        }
    }

    function addInteraction(type) {
        draw = new ol.interaction.Draw({
            source: source,
            type: type,
            style: drawStyle
        });

        draw.on('drawstart', drawstart, this);
        draw.on('drawend', drawend, this);

        map.addInteraction(draw);
    }

    function SetActive(state, type) {
        if (draw == undefined) {
            Init(type);
        } else {
            if (state) {
                if (draw.get('type') != type) {
                    map.removeInteraction(draw);
                    addInteraction(type);
                }
                map.on('pointermove', pointerMoveHandler);
                map.addOverlay(helpTooltip);
                Layer.setVisible(true);
            } else {
                map.un('pointermove', pointerMoveHandler);
                map.removeOverlay(helpTooltip);
            }
            draw.setActive(state);
        }
    }

    /**
     * format length output
     * @param {ol.geom.LineString} line
     * @return {string}
     */
    function formatLength(line) {
        return GetLengthUnit(MeasureLength(line.getCoordinates()));
    }

    function MeasureLength(coordinates) {
        var length = 0;
        var sourceProj = map.getView().getProjection();
        for (var i = 0, ii = coordinates.length - 1; i < ii; ++i) {
            var c1 = ol.proj.transform(coordinates[i], sourceProj, 'EPSG:4326');
            var c2 = ol.proj.transform(coordinates[i + 1], sourceProj, 'EPSG:4326');
            length += wgs84Sphere.haversineDistance(c1, c2);
        }
        return length;
    }

    function GetLengthUnit(length) {
        if (length >= 1000) {
            return (Math.round(length / 1000 * 100) / 100) + ' ' + 'كم';
        } else {
            return (Math.round(length * 100) / 100) + ' ' + 'م';
        }
    }

    /**
     * format length output
     * @param {ol.geom.Polygon} polygon
     * @return {string}
     */
    function formatArea(polygon) {
        var sourceProj = map.getView().getProjection();
        var geom = polygon.clone().transform(sourceProj, 'EPSG:4326');
        var coordinates = geom.getLinearRing(0).getCoordinates();
        var area = Math.abs(wgs84Sphere.geodesicArea(coordinates));
        var output;
        if (area > 10000) {
            output = (Math.round(area / 1000000 * 100) / 100) +
                ' ' + 'كم<sup>2</sup>';
        } else {
            output = (Math.round(area * 100) / 100) +
                ' ' + 'م<sup>2</sup>';
        }
        return output;
    }

    function Clear() {
        if (source != null) {
            MeasureTools.Layer.getSource().clear();
            SetToolTipVisibility(false);
            removedMeasureTooltips = [];
        }
    }

    function InitSphere() {
        wgs84Sphere = new ol.Sphere(6378137); // ol.sphere.WGS84 
    }

    return {
        Init: Init,
        SetActive: SetActive,
        Layer: Layer,
        Clear: Clear,
        MeasureLength: MeasureLength,
        GetLengthUnit: GetLengthUnit,
        InitSphere: InitSphere
    };
})();