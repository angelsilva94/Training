import { UserService } from './users.service';


import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'user',
  templateUrl: './users.component.html'
})

export class UserComponent implements OnInit {
  users;
  constructor(private _userService: UserService) {

  }
  ngOnInit() {
    this._userService.getUsers()
      .subscribe(answer => {
        this.users = answer;
        console.log(answer);
      },
      error => console.log(error),
      () => console.log('ya acabe')
      );
  }
  //  ngOnInit() {
  //   this._userServie.getUsers()
  //     .subscribe(answer => this.user = answer,
  //     error => console.log(error),
  //     () => console.log('ya acabe')
  //     );
  // }
}
