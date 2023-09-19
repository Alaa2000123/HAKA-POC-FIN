
/// <reference path="ol.js" />
/// <reference path="ol3-layerswitcher.js" />


var LayerStyles = [];
var Map = (function () {
    var Layers = {
        'Google Map': new ol.layer.Tile({
            title: 'Google Map',
            source: new ol.source.XYZ({
                url: 'http://mt{1-3}.google.com/vt/lyrs=m@129&hl=ar&x={x}&y={y}&z={z}&s=Galileo'
            }),
            type: 'base',
            visible: false
        }),
        'Bing': new ol.layer.Tile({
            title: 'Bing',
            source: new ol.source.BingMaps({
                key: 'AsJihSDzsujaimLwbAvgi5cSJlxtXkpN0nOP7BGQCr7P-oO_TFboQ1AvZZ-85AUj',
                imagerySet: 'Road'
            }),
            type: 'base',
            visible: false
        }),
        'OSM': new ol.layer.Tile({
            title: 'OSM',
            source: new ol.source.XYZ({
                url: 'http://{a-b}.tile.openstreetmap.org/{z}/{x}/{y}.png'
            }),
            type: 'base',
            visible: false
        }),
        'Google Satellite': new ol.layer.Tile({
            title: 'Google Satellite',
            source: new ol.source.XYZ({
                url: 'http://mt{1-3}.google.com/vt/lyrs=s,h@129&hl=ar&x={x}&y={y}&z={z}&s=Galileo'
            }),
            type: 'base',
            visible: true
        })
    };

    var CurrentLayer = Layers['Google Satellite'],
        RightClickLocation,
        CurrentZoom = 7,
        MyPosition;

    function Create(mapID) {
        var map = new ol.Map({
            logo: false,
            target: mapID,
            layers: [
                new ol.layer.Group({
                    title: 'Base maps',
                    layers: Object.keys(Layers).map(function (k) {
                        return Layers[k];
                    })
                })
            ],
            controls: [
                new ol.control.LayerSwitcher({
                    tipLabel: 'طبقات الخريطة'
                }),
                new ol.control.ScaleLine(),
                new ol.control.ZoomSlider()
            ],
            view: new ol.View({
                center: ol.proj.transform([36, 31.24], 'EPSG:4326', 'EPSG:3857'),
                zoom: CurrentZoom,
                maxZoom: 20,
                minZoom: 7
            })
        });

        $("#" + mapID).mousedown(function (e) {
            if (e.button == 2) {
                var parentOffset = $(this).offset();
                RightClickLocation = map.getCoordinateFromPixel([e.pageX - parentOffset.left, e.pageY - parentOffset.top]);
            }
        });

        return map;
    }

    function MyLocation(callback) {
        navigator.geolocation.getCurrentPosition(function (location) {
            var view = map.getView();
            var loc = ol.proj.transform([location.coords.longitude, location.coords.latitude], 'EPSG:4326', 'EPSG:3857');
            view.setCenter(loc);
            view.setZoom(13);
            if (callback) {
                callback(loc);
            }
        });
    }

    return {
        Create: Create,
        MyLocation: MyLocation
    };
})();

// Usage:
var map = Map.Create("mapElementID");
