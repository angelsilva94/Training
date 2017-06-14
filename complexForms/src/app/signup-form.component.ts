import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';


@Component({
    selector: 'signup-form',
    templateUrl: 'signup-form.component.html'
})
export class SignUpFormComponent {
  signupForm: FormGroup;
  constructor(private formBuilder: FormBuilder) {}


}
