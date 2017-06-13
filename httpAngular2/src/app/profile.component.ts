import { Followers } from './followers';
import { Observable } from 'rxjs/Observable';
import { ProfileService } from './profile.service';
import { Component, OnInit } from '@angular/core';
import 'rxjs/add/observable/forkJoin';

@Component({
  selector: 'profile',
  templateUrl: 'profile.component.html',
  styles: [
    `
      .avatar {
        width: 100px;
        height: 100px;
        border-radius: 100%;
      }
    `
  ]

})
export class ProfileComponent implements OnInit {
  followers: Followers;
  profile = {};
  isLoading = true;
  // abs: string;
  constructor(private _profileService: ProfileService) { }

  ngOnInit() {
    Observable.forkJoin(
      this._profileService.getUser('octocat'),
      this._profileService.getFollowers('octocat')
    )
    .subscribe(
      answer => {
        this.profile = answer[0];
        this.followers = answer[1];
        console.log(answer);
      },
      error => console.log(error),
      () => { this.isLoading = false; }
    )
  }
}
