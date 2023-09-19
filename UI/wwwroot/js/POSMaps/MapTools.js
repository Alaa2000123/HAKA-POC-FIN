var MapTools = (function () {
    var DragZoom;
    var FlatTools = [];

    var PanTool = { title: 'تحريك', group: 'drag', icon: 'fa fa-hand-grab-o', action: PanAction, style: 'padding: 3px 7px 4px 2px;font-size:55px' };
    var AddPointTool = { title: 'اضافه نقطة', group: 'drag', icon: 'fa fa-map-marker', action: AddNewPoint, style: 'padding: 3px 3px 5px 2px' };
    var ShowAll = { title: 'إظهار الكل', icon: 'fa fa-eye', action: FitAllAction };
    var MeasureLineTool = { title: 'المسافة', group: 'click', icon: 'fa fa-pencil', action: MeasureLineAction, style: 'padding: 3px 7px 4px 2px;font-size:55px' };
    var MeasurePolygonTool = { title: 'المساحة', group: 'click', icon: 'fa fa-pencil-square-o', action: MeasurePolygonAction, style: 'padding: 3px 3px 5px 2px', style: 'padding: 3px 7px 4px 2px;font-size:55px' };
    var DeleteAll = { title: 'حذف', group: 'drag', icon: 'fa fa-eraser', action: DeleteAll, style: 'padding: 3px 3px 5px 2px' };
    var DragZoomTool = { title: 'تكبير مربع', group: 'drag', icon: 'fa fa-search-plus', action: DragZoomAction, style: 'padding: 3px 3px 5px 2px' };
    var FullScreenTool = { title: 'تكبير', group: 'drag', icon: 'fa fa-expand', action: FullScreenAction, style: 'padding: 3px 3px 5px 2px' };
    var FullWidthTool = { title: 'تكبير', group: 'drag', icon: 'fa fa-arrows-h', action: FullWidthAction, style: 'padding: 3px 3px 5px 2px' };

    var ActiveGroups = {
        'drag': null,
        'click': null
    };

    var DefaultGroups = {
        'drag': PanTool
    };

    var OnDiactivateGroup = {
        'drag': null,
        'click': null
    };

    var MapTools = [
        //PanTool,
        ShowAll,
        //MeasureLineTool,
        //MeasurePolygonTool,
        FullScreenTool,
        //FullWidthTool,
        //DeleteAll,
        [
            { title: 'تكبير', icon: 'fa fa-search-plus', action: ZoomInAction },
            { title: 'تصغير', icon: 'fa fa-search-minus', action: ZoomOutAction },
        ]
    ];

    var Zooming = false;
    var Containter;

    function Create(cont) {
        Containter = $(cont);
        Containter.on('click', 'a', ToolClicked);
        RenderTools();
    }

    //function RouteAction() {
    //    if (RouteTool.active) {
    //        Router.SetActive(false);
    //        DiactivateTool(RouteTool);
    //    } else {
    //        //Vehicles.StopContinuousTracking();
    //        ActivateTool(RouteTool);
    //        Router.SetActive(true);
    //        OnDiactivateGroup[RouteTool.group] = function () {
    //            Router.SetActive(false);
    //            UsingTools = false;
    //        };
    //    }

    //    UsingTools = RouteTool.active;
    //}

    //function MeasureLineAction() {
    //    if (MeasureLineTool.active) {
    //        MeasureTools.SetActive(false);
    //        DiactivateTool(MeasureLineTool);
    //    } else {
    //        //Vehicles.StopContinuousTracking();
    //        ActivateTool(MeasureLineTool);
    //        MeasureTools.SetActive(true, 'LineString');
    //        OnDiactivateGroup[MeasureLineTool.group] = function () {
    //            MeasureTools.SetActive(false);
    //            UsingTools = false;
    //        };
    //    }

    //    UsingTools = MeasureLineTool.active;
    //}

    //function MeasurePolygonAction() {
    //    if (MeasurePolygonTool.active) {
    //        MeasureTools.SetActive(false);
    //        DiactivateTool(MeasurePolygonTool);
    //    } else {
    //        //Vehicles.StopContinuousTracking();
    //        ActivateTool(MeasurePolygonTool);
    //        MeasureTools.SetActive(true, 'Polygon');
    //        OnDiactivateGroup[MeasurePolygonTool.group] = function () {
    //            MeasureTools.SetActive(false);
    //            UsingTools = false;
    //        };
    //    }

    //    UsingTools = MeasurePolygonTool.active;
    //}
    //function FullWidthAction() {
    //    $("#topRightPanel").toggle(function () {
    //        map.updateSize();
    //    });
    //}

    function FullWidthAction() {
        if (FullWidthTool.active) {
            DiactivateTool(FullWidthTool);
            FullWidthTool.dom.children("i")[0].className = "fa fa-arrows-h";
            $("#topRightPanel").toggle(function () {
                map.updateSize();
            });
        } else {
            var elem = map.getTargetElement();
            elem = elem.parentNode.parentNode;
            $("#topRightPanel").toggle(function () {
                map.updateSize();
            });
            ActivateTool(FullWidthTool);
            FullWidthTool.dom.children("i")[0].className = "fa fa-compress";
        }
    }

    function RenderSingle(i, tool) {
        var icon;
        if (tool.icon) {
            icon = '<i class="' + tool.icon + '"></i>';
        } else {
            icon = '<svg' + (tool.style ? ' style="' + tool.style + '"' : '') + '><use xlink:href="#' + tool.svg + '"></use></svg>';
        }
        return '<a class="btn btn-default" style:"height:50px,width:50px;" data-toggle="tooltip" data-tool="' + i + '" title="' + tool.title + '">' + icon + '</i></a>';
    }

    function Renderlvl2(j, tool) {
        var tooltipOpt = { container: "#MapPane", placement: "top" };
        var lvl2div = $('<div class="lvl2-cont"></div>');
        var cont = $('<div class="btn-group mapTools lvl2" style="width:' + (tool.length * 42) + 'px"></div>');

        for (var i = 0; i < tool.length; i++) {
            tool[i].dom = $(RenderSingle(FlatTools.length, tool[i]));
            tool[i].dom.tooltip(tooltipOpt);
            FlatTools.push(tool[i]);
            cont.append(tool[i].dom);
        }
        lvl2div.append(cont);
        Containter.append(lvl2div);
    }

    function RenderTools() {
        var tooltipOpt = { container: "#MapPane", placement: "right" };
        for (var i in MapTools) {
            var tool = MapTools[i];
            if (tool instanceof Array) {
                Renderlvl2(i, tool);
            } else {
                tool.dom = $(RenderSingle(FlatTools.length, tool));
                tool.dom.tooltip(tooltipOpt);
                tool.active = false;
                FlatTools.push(tool);
                Containter.append(tool.dom);
            }
        }

        ActivateTool(PanTool);
    }
    function DeleteAll() {
        MeasureTools.Clear();
    }
    function GetToolElement(toolname) {
        return Containter.find("[data-tool='" + toolname + "']");
    }

    //function Add(name, tool) {
    //    MapTools[name] = tool;
    //    tool.dom = $(RenderSingle(name, tool));
    //    Containter.append(tool.dom);
    //}

    //function Remove(name) {
    //    GetToolElement(name).remove();
    //    delete MapTools[name];
    //}

    //function Hide(toolname) {
    //    SingleOrMany(toolname, function (item) {
    //        GetToolElement(item).hide();
    //    });
    //}

    //function Show(toolname) {
    //    SingleOrMany(toolname, function (item) {
    //        GetToolElement(item).show();
    //    });
    //}

    function ActivateTool(tool) {
        if (tool.group) {
            if (ActiveGroups[tool.group]) {
                DiactivateTool(ActiveGroups[tool.group]);
            }
            ActiveGroups[tool.group] = tool;
        }

        $(tool.dom).addClass("active").addClass('open');
        tool.active = true;
    }

    function DiactivateTool(tool) {
        if (tool && tool.active) {
            $(tool.dom).removeClass("active").removeClass('open');

            tool.active = false;

            if (tool.group) {
                if (DefaultGroups[tool.group] && DefaultGroups[tool.group] != tool) {
                    ActivateTool(DefaultGroups[tool.group]);
                }

                if (OnDiactivateGroup[tool.group]) {
                    OnDiactivateGroup[tool.group]();
                    OnDiactivateGroup[tool.group] = null;
                }
            }
        }
    }

    function on(toolname, callback) {
        var action = FlatTools[toolname].action;

        if (action == undefined) {
            FlatTools[toolname].action = callback;
        } else if (action instanceof Array) {
            action.push(callback);
        } else {
            FlatTools[toolname].action = [action, callback];
        }
    }

    function off(toolname, callback) {
        var tool = FlatTools[toolname];

        if (tool.action instanceof Array) {
            for (var i in tool.action) {
                if (tool.action[i] == callback) {
                    delete tool.action[i];
                }
            }
        } else {
            tool.action = undefined;
        }
    }

    function ToolClicked(e) {
        var tool = FlatTools[+$(e.currentTarget).data('tool')];
        SingleOrMany(tool.action, function (action) {
            if (action != undefined) {
                action(e);
            }
        });
    }

    function SingleOrMany(item, callback) {
        if (item instanceof Array) {
            for (var i in item) {
                callback(item[i]);
            }
        } else {
            callback(item);
        }
    }

    function PanZoomAnimation(view) {
        map.beforeRender(ol.animation.zoom({
            resolution: view.getResolution(),
            duration: 400
        }));
        map.beforeRender(ol.animation.pan({
            source: view.getCenter(),
            duration: 400
        }));
    }

    function Zoom(factor) {
        var res = map.getView().getResolution() * factor;
        if (res >= 0.29858214173896974 && res <= 2445.98490512564) {
            if (Zooming == false) {
                Zooming = true;

                var view = map.getView();
                PanZoomAnimation(view);
                view.setResolution(res);

                setTimeout(function () { Zooming = false; }, 350);
            }
        }
    }

    function PanAction() {
        ActivateTool(PanTool);
    }

    function ZoomInAction() {
        Zoom(0.5);
    }

    function ZoomOutAction() {
        Zoom(2);
    }

    function DragZoomAction() {
        if (DragZoomTool.active) {
            DiactivateTool(DragZoomTool);
        } else {
            if (DragZoom == undefined) {
                DragZoom = new ol.interaction.DragZoom({
                    condition: function () { return true }
                });
                DragZoom.on('boxend', function () {
                    DiactivateTool(DragZoomTool);
                });
                map.addInteraction(DragZoom);
            } else {
                DragZoom.setActive(true);
            }

            ActivateTool(DragZoomTool);
            OnDiactivateGroup[DragZoomTool.group] = function () {
                DragZoom.setActive(false);
            };
        }
    }

    function AddNewPoint() {
        ActivateTool(AddPointTool);
        DiactivateTool(PanTool);
    }

    function FullScreenAction() {
        if (FullScreenTool.active) {
            DiactivateTool(FullScreenTool);
            FullScreenTool.dom.children("i")[0].className = "fa fa-expand";
            if (document.exitFullscreen) {
                document.exitFullscreen();
            } else if (document.mozCancelFullScreen) {
                document.mozCancelFullScreen();
            } else if (document.webkitExitFullscreen) {
                document.webkitExitFullscreen();
            }
        } else {
            var elem = map.getTargetElement();
            elem = elem
            
            if (elem.requestFullscreen) {
                elem.requestFullscreen();
            } else if (elem.msRequestFullscreen) {
                elem.msRequestFullscreen();
            } else if (elem.mozRequestFullScreen) {
                elem.mozRequestFullScreen();
            } else if (elem.webkitRequestFullscreen) {
                elem.webkitRequestFullscreen();
            }
            ActivateTool(FullScreenTool);
            FullScreenTool.dom.children("i")[0].className = "fa fa-compress";
        }
    }

    $(document).on('webkitfullscreenchange mozfullscreenchange fullscreenchange MSFullscreenChange', function () {
        var fe = document.fullscreenElement || document.webkitFullscreenElement || document.mozFullScreenElement || document.msFullscreenElement;
        if (FullScreenTool.active && fe == null) {
            DiactivateTool(FullScreenTool);
            FullScreenTool.dom.children("i")[0].className = "fa fa-expand";
        }
    });

    function AddLandMark() {
        if (LandmarksTool.active) {
            Landmarks.SetActive(false);
            DiactivateTool(LandmarksTool);
        }
        else {
            ActivateTool(LandmarksTool);
            Landmarks.SetActive(true);
            OnDiactivateGroup[LandmarksTool.group] = function () {
                Landmarks.SetActive(false);
            };
        }
    }

    function AddGeofencePolygonAction() {
        if (PolygonGeofenceTool.active) {
            GeoFence.SetActive(false);
            DiactivateTool(PolygonGeofenceTool);
        }
        else {
            ActivateTool(PolygonGeofenceTool);
            GeoFence.SetActive(true, 'Polygon');
            OnDiactivateGroup[PolygonGeofenceTool.group] = function () {
                GeoFence.SetActive(false);
            };
        }
    }

    function FitAllAction() {
        var view = map.getView();
        PanZoomAnimation(view);
        view.setCenter(ol.proj.transform([36, 31.24], 'EPSG:4326', 'EPSG:3857'));
        view.setZoom(8);
    }

    function RouteAction() {
        if (RouteTool.active) {
            Router.SetActive(false);
            DiactivateTool(RouteTool);
        } else {
            ActivateTool(RouteTool);
            Router.SetActive(true);
            OnDiactivateGroup[RouteTool.group] = function () {
                Router.SetActive(false);
            };
        }
    }

    function MeasureLineAction() {
        if (MeasureLineTool.active) {
            MeasureTools.SetActive(false);
            DiactivateTool(MeasureLineTool);
        } else {
            ActivateTool(MeasureLineTool);
            MeasureTools.SetActive(true, 'LineString');
            OnDiactivateGroup[MeasureLineTool.group] = function () {
                MeasureTools.SetActive(false);
            };
        }
    }

    function MeasurePolygonAction() {
        if (MeasurePolygonTool.active) {
            MeasureTools.SetActive(false);
            DiactivateTool(MeasurePolygonTool);
        } else {
            ActivateTool(MeasurePolygonTool);
            MeasureTools.SetActive(true, 'Polygon');
            OnDiactivateGroup[MeasurePolygonTool.group] = function () {
                MeasureTools.SetActive(false);
            };
        }
    }

    return {
        Create: Create,
        on: on,
        off: off,
        PanZoomAnimation: PanZoomAnimation,
        ZoomOutAction: ZoomOutAction,
        ZoomInAction: ZoomInAction,
        AddPointTool: AddPointTool,
        PanTool: PanTool,
        DeleteAll: DeleteAll,
        ActivateTool: ActivateTool,
        FitAllAction: FitAllAction,
        FullScreenTool: FullScreenAction,
        FullWidthTool: FullWidthAction
    };

})();