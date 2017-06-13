import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';


@Component({
  template: `
    <h1>Componente de prueba</h1>
    <h1>{{id}}</h1>
  `
})

export class TestComponent implements OnInit{
  id: number;
  constructor(private _route: ActivatedRoute) { }
  ngOnInit() {
    this._route.params.subscribe(params => { console.log(params), this.id = +params['id'] });
  }
}
