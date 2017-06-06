import { TweetComponent } from './tweet.component';
import { TweetService } from './tweet.service';
import { Input, Directive } from '@angular/core';
import { Component } from '@angular/common';


@Component({
    selector: 'tweets',
    template: `
        <div *ngFor=" leet tweet of tweets">
            <tweet [data="tweet"]> </tweet>
        </div>
    `,
    providers: [TweetService],
    directives: [TweetComponent]

})
export class TweetsComponent{
    tweets: any[];
    constructor(tweetService: TweetService) {
        this.tweets = tweetService.getTweets();
    }
    
}