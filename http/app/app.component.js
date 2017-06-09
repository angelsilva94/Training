System.register(['rxjs/Rx', 'angular2/core', 'rxjs/operator/filter', 'rxjs/operator/debounceTime'], function(exports_1) {
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var Rx_1, core_1;
    var AppComponent;
    return {
        setters:[
            function (Rx_1_1) {
                Rx_1 = Rx_1_1;
            },
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (_1) {},
            function (_2) {}],
        execute: function() {
            AppComponent = (function () {
                function AppComponent() {
                }
                AppComponent.prototype.ngAfterViewInit = function () {
                    // var keyups = Observable.fromEvent($("#search"), "keyup")
                    //   .map(e => e.target.value)
                    //   .filter(text => text.length >= 3)
                    //   .debounceTime(400)
                    //   .distinctUntilChanged()
                    //   .flatMap(searchTerm => {
                    //     var url = "https://api.spotify.com/v1/search?q=" + searchTerm + "&type=artist";
                    //     var promise = $.getJSON(url);
                    //     return Observable.fromPromise(promise);
                    //   });
                    // var subscription = keyups.subscribe(data => console.log(data));
                    // subscription.unsubscribe();
                    console.log(new Rx_1.Observable);
                };
                AppComponent = __decorate([
                    core_1.Component({
                        selector: 'my-app',
                        template: "\n        <!--<input id=\"search\" type=\"text\" class=\"form-control\">-->\n    "
                    }), 
                    __metadata('design:paramtypes', [])
                ], AppComponent);
                return AppComponent;
            })();
            exports_1("AppComponent", AppComponent);
        }
    }
});
//# sourceMappingURL=app.component.js.map