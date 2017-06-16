import { UserNameValidators } from './userNameValidators';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';

@Component({
    selector: 'signup-form',
    templateUrl: 'signup-form.component.html'
})
export class SignUpFormComponent implements OnInit {
  form: FormGroup;
  // form = new FormGroup({
  //        username: new FormControl('', Validators.required),
  //        password: new FormControl('', Validators.required),
  //    });
  constructor(private _formBuilder: FormBuilder) { }


  ngOnInit() {
    // this.signupForm = this.formBuilder.group({
    //   name: ['', Validators.required],
    //   email: [],
    //   billing: this.formBuilder.group({
    //     cardNumber: ['', Validators.required],
    //     expiry : ['', Validators.required]
    //   })
    // });

    this.form = this._formBuilder.group({
      username: ['', Validators.compose([
        Validators.required, UserNameValidators.cannotContainSpaces
      ]), UserNameValidators.shouldBeUnique],
      password: ['', Validators.required]
    });
  }
  signUp() {
    // var res= auth.service(this.form.value); true|false
    this.form.controls['username'].setErrors({
      invalidLogin: true
    });
    console.log(this.form.value);
  }

}
