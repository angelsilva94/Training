import { Component, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
    selector: 'contact-form',
    templateUrl:'app/contact-form.component.html'
})
  

export class ContactFormComponent{
    log(x) {
        console.log(x);
    }
}