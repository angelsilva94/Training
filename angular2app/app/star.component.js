"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var StarComponent = (function () {
    function StarComponent() {
        this.clicked = false;
        this.change = new core_1.EventEmitter();
    }
    StarComponent.prototype.click = function () {
        this.clicked = !this.clicked;
        this.change.emit({ newValue: this.clicked });
        console.log("click");
    };
    __decorate([
        core_1.Input(), 
        __metadata('design:type', Object)
    ], StarComponent.prototype, "clicked", void 0);
    __decorate([
        core_1.Output(), 
        __metadata('design:type', Object)
    ], StarComponent.prototype, "change", void 0);
    StarComponent = __decorate([
        core_1.Component({
            selector: 'star',
            template: "\n        <i \n            class=\"glyphicon glyphicon-star\"\n            [ngClass]=\"{\n                'glyphicon-star-empty':!clicked,\n                'glyphicon-star':clicked                \n            }\"\n            (click)=\"click()\">\n        \n        </i>\n    ",
        }), 
        __metadata('design:paramtypes', [])
    ], StarComponent);
    return StarComponent;
}());
exports.StarComponent = StarComponent;
//# sourceMappingURL=star.component.js.map