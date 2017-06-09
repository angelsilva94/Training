import { Observable } from 'rxjs/Rx';
/// <reference path="../typings/tsd.d.ts" />

import {Component} from 'angular2/core';
// import {Observable} from 'rxjs/Rx'
import 'rxjs/operator/filter';
import 'rxjs/operator/debounceTime';
@Component({
    selector: 'my-app',
    template: `
        <!--<input id="search" type="text" class="form-control">-->
    `
})
export class AppComponent {
  ngAfterViewInit() {
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
    console.log(new Observable);
  }
}
