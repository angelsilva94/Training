import { UserService } from './users.service';


import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'user',
  templateUrl: './users.component.html'
})

export class UserComponent implements OnInit {
  users;
  path = 'user';
  private userId;
  constructor(private _userService: UserService) {

  }
  ngOnInit() {
    this._userService.getUsers()
      .subscribe(answer => {
        this.users = answer;
        console.log(answer);
      },
      error => console.log(error),
      () => {
        console.log('ya acabe')
      }
      );
  }
  //  ngOnInit() {
  //   this._userServie.getUsers()
  //     .subscribe(answer => this.user = answer,
  //     error => console.log(error),
  //     () => console.log('ya acabe')
  //     );
  // }
  onClick(user) {
    if (confirm('Do you wan to delete it?' + user.name)) {
      let index = this.users.indexOf(user);
      this.users.splice(index, 1);
      this._userService.deleteUser(user.id).subscribe(resp => console.log(resp),
        error => {
          console.log(error);
          alert('Something went wrong');
          this.users.splice(index, 0, user);
        },
        () => {
          console.log('successfuly deleted user');
        }
      )
    }
  }
}
