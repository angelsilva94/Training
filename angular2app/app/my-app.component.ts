import { ZippyComponent } from './zippy.component';
import { TweetComponent } from './tweet.component';
import { TweetService } from './tweet.service';
import { VoteComponent } from './vote.component';
import { LikeComponent } from './like.component';
import { StarComponent} from './star.component';
import { AuthorsComponent } from './authors.component';
import { CoursesComponent } from './courses.component';
import { Component } from '@angular/core';


@Component({
  selector: 'my-app',
  template: `
    <!--<h1>Hello {{msg}} </h1>-->
    <!--<courses></courses>
    <authors></authors>-->
    <!--<button (click)="onClick($event)">Hola</button>-->
    <!--<input type="text" [(ngModel)]="title"/>{{title}}-->
    <!--<star (change)="onChange()"></star>-->
    <!--<like></like>-->
    <!--<vote></vote>-->
    <!--<div *ngFor="let tweet of tweets">
            <tweet [data]="tweet"></tweet>
    </div>-->
    <!--<div *ngIf="courses.length>0">
        List of courses
    </div>
    <div>
        You dont have any courses
    </div>-->
    <!--<ul class="nav nav-pills">
      <li [class.active]="viewMode=='map'"><a (click)="viewMode='map'">Map View</a></li>
      <li [class.active]="viewMode=='list'"><a (click)="viewMode='list'">List View</a></li> 
    </ul>
    <div [ngSwitch]="viewMode">
      <template [ngSwitchCase]="'map'">Map View Content</template>
      <template [ngSwitchCase]="'list'">List View   Content</template>      
    </div>-->
    <!--<div>
      <ul>
        <il *ngFor="let course of courses,let i = index">course {{i}} </il>
      </ul>
    </div>-->
    <!--<star></star>-->
    <!--<zippy title="Title 1">
      Here is my first content
    </zippy>
    <zippy title="Title 2">
      Here is my second content 
    </zippy>-->
  `,
  directives: [
    CoursesComponent,
    AuthorsComponent,
    StarComponent,
    LikeComponent,
    VoteComponent,
    TweetComponent,
    ZippyComponent
  ],
  providers:[TweetService]
})

export class AppComponent{
  // msg: string = 'Angular 2';
  // onClick($event) {
    
  //   console.log("Click",$event);
  // }
  // onChange() {
  //   console.log("change");
  // }
  // tweets: any[];
  // constructor(tweetService: TweetService) {
  //   this.tweets = tweetService.getTweets();
  // }
  // courses = [];
  // viewMode = 'map';
  // courses = ['course 1', 'course 2', 'course 3', 'course 4'];

}