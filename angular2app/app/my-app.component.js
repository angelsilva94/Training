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
var zippy_component_1 = require('./zippy.component');
var tweet_component_1 = require('./tweet.component');
var tweet_service_1 = require('./tweet.service');
var vote_component_1 = require('./vote.component');
var like_component_1 = require('./like.component');
var star_component_1 = require('./star.component');
var authors_component_1 = require('./authors.component');
var courses_component_1 = require('./courses.component');
var core_1 = require('@angular/core');
var AppComponent = (function () {
    function AppComponent() {
    }
    AppComponent = __decorate([
        core_1.Component({
            selector: 'my-app',
            template: "\n    <!--<h1>Hello {{msg}} </h1>-->\n    <!--<courses></courses>\n    <authors></authors>-->\n    <!--<button (click)=\"onClick($event)\">Hola</button>-->\n    <!--<input type=\"text\" [(ngModel)]=\"title\"/>{{title}}-->\n    <!--<star (change)=\"onChange()\"></star>-->\n    <!--<like></like>-->\n    <!--<vote></vote>-->\n    <!--<div *ngFor=\"let tweet of tweets\">\n            <tweet [data]=\"tweet\"></tweet>\n    </div>-->\n    <!--<div *ngIf=\"courses.length>0\">\n        List of courses\n    </div>\n    <div>\n        You dont have any courses\n    </div>-->\n    <!--<ul class=\"nav nav-pills\">\n      <li [class.active]=\"viewMode=='map'\"><a (click)=\"viewMode='map'\">Map View</a></li>\n      <li [class.active]=\"viewMode=='list'\"><a (click)=\"viewMode='list'\">List View</a></li> \n    </ul>\n    <div [ngSwitch]=\"viewMode\">\n      <template [ngSwitchCase]=\"'map'\">Map View Content</template>\n      <template [ngSwitchCase]=\"'list'\">List View   Content</template>      \n    </div>-->\n    <!--<div>\n      <ul>\n        <il *ngFor=\"let course of courses,let i = index\">course {{i}} </il>\n      </ul>\n    </div>-->\n    <!--<star></star>-->\n    <!--<zippy title=\"Title 1\">\n      Here is my first content\n    </zippy>\n    <zippy title=\"Title 2\">\n      Here is my second content \n    </zippy>-->\n  ",
            directives: [
                courses_component_1.CoursesComponent,
                authors_component_1.AuthorsComponent,
                star_component_1.StarComponent,
                like_component_1.LikeComponent,
                vote_component_1.VoteComponent,
                tweet_component_1.TweetComponent,
                zippy_component_1.ZippyComponent
            ],
            providers: [tweet_service_1.TweetService]
        }), 
        __metadata('design:paramtypes', [])
    ], AppComponent);
    return AppComponent;
}());
exports.AppComponent = AppComponent;
//# sourceMappingURL=my-app.component.js.map