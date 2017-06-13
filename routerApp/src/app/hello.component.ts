import { Component } from '@angular/core';

@Component({
  selector: 'hello',
  template: `
    <h1>Hola Mundo</h1>
    <h2>Soy: {{nombre}}</h2>
  `
})

export class HelloComponent {
  nombre: string;
  constructor() {
    this.nombre = 'Angel';
  }
}
