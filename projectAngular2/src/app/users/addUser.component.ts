import { UserService } from './users.service';
import { Router } from '@angular/router';
import { FormComponent } from './form.component';
import { EmailValidator } from './email-validator';
import { Component, OnInit } from '@angular/core';
import { FormsModule, FormGroup, FormBuilder, Validators } from '@angular/forms';


@Component({
  templateUrl: './addUser.component.html'
})

export class AddUserComponent implements OnInit, FormComponent  {



  signupForm: FormGroup;
  constructor(private _fb: FormBuilder, private _route: Router, private _userService: UserService) { }
  ngOnInit() {
    this.signupForm = this._fb.group({
      name: ['', Validators.required],
      email: ['', Validators.compose([
        Validators.required,
        EmailValidator.validateEmail])
      ],
      phone: ['', Validators.required],
      address: this._fb.group({
        street: [],
        suite: [],
        city: [],
        zip: []
      })
    });

  }
  onSubmit() {
    console.log('submit');
    console.log(this.signupForm.value);
    this._userService.postUser(this.signupForm.value).subscribe(resp => {
      console.log(resp);
      this.signupForm.markAsPristine();
    },
      error => {
        console.log(error);
        console.log('HUBO UN ERROR');
      },
      () => {
        console.log('TERMINE');
        this._route.navigate(['user']);
      }
    )

  }

  hasChanges(): boolean {
    console.log();
    if (this.signupForm.dirty) {
      return true;
    }
    return false;
  }
}
