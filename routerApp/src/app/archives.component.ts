import { Component } from '@angular/core';
@Component({
  template: `
    <h1>Home Page</h1>
        <ul>
            <li *ngFor="let archive of archives">
                <a [routerLink]="['arch', archive.year , archive.month]">
                    {{ archive.year }}/{{ archive.month }}
                </a>
            </li>
        </ul>
  `
})

export class ArchivesComponent {
  archives = [
      { year: 2016, month: 1 },
      { year: 2016, month: 2 },
      { year: 2016, month: 3 },
  ];
}
