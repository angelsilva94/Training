import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import 'rxjs/add/operator/switchMap';
import { Observable } from 'rxjs/Observable';
@Component({
  template: `
    <h1>Archive</h1>
    {{year}}/{{month}}
  `

})
export class ArchiveComponent implements OnInit, OnDestroy {
  year: number;
  month: number;
  subscription;
  constructor(private _route: ActivatedRoute) { }
  ngOnInit() {
    this.subscription = this._route.params.subscribe(params => {
      console.log('ENTRE---------');
      this.year = +params['year'];
      this.month = +params['month'];
      console.log(+params['year']);
      console.log(+params['month']);
    },

      error => {
        console.log('ERROR---------------');
        console.log(error);
      });
  }
  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
