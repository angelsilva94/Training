import { UserService } from './users.service';
import { Router, ActivatedRoute } from '@angular/router';
import { FormComponent } from './form.component';
import { EmailValidator } from './email-validator';
import { Component, OnInit } from '@angular/core';
import { FormsModule, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { User } from './user';

@Component({
  templateUrl: './addUser.component.html'
})

export class AddUserComponent implements OnInit, FormComponent  {
  user = new User();

  title;
  id;
  signupForm: FormGroup;
  constructor(
    private _fb: FormBuilder,
    private _route: Router,
    private _userService: UserService,
    private _url: ActivatedRoute,

  ) { }
  ngOnInit() {
    this.id = this._url.params.subscribe(url => {
      console.log(url);
      this.title = url.id ? 'Edit User' : 'New User';
      // this.user.email = '';
      if (!url.id) {
        console.log('!id');
        return;
      }
      this._userService.getUser(url.id).subscribe(user => {
        console.log(user);
        this.user = user;

      }, response => {
          console.log(response);
          if (response.status == 404) {
            this._route.navigate(['notFound']);
            console.log('NOT FOUND ROUTE');
          }
      })



    });
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
    let result;
    if (this.user.id) {
      result = this._userService.updateService(this.user);
    } else {
      result = this._userService.postUser(this.signupForm.value);
    }
    // this._userService.postUser(this.signupForm.value).subscribe(resp => {
    //   console.log(resp);
    //   this.signupForm.markAsPristine();
    // },
    //   error => {
    //     console.log(error);
    //     console.log('HUBO UN ERROR');
    //   },
    //   () => {
    //     console.log('TERMINE');
    //     this._route.navigate(['user']);
    //   }
    // )
    result.subscribe(resp => {
      console.log(resp);
      this.signupForm.markAsPristine();
    }, eror => {
      console.log('hubo un error');
      }, () => {
        console.log('ACABE USER');
        this._route.navigate(['user']);
    });

  }

  hasChanges(): boolean {
    console.log();
    if (this.signupForm.dirty) {
      return true;
    }
    return false;
  }
}
