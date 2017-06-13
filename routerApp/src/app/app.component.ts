import { Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
@Component({
  selector: 'app-root',
  template: `
  <ul>
    <li><a routerLink="">Home</a></li>
    <li><a routerLink="hola">Hola</a></li>
    <!--<li><a routerLink="test/1">Test</a></li>-->
    <li><a [routerLink]="['test',  1 ]">Test</a></li>
  </ul>
   <router-outlet></router-outlet>
  `

})
export class AppComponent {
  title = 'app';
}
