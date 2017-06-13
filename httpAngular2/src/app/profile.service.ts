import { Followers } from './followers';
import { Profile } from './profile';
import { Injectable, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map'
import { Observable } from 'rxjs/Observable';
// import { Observable } from 'rxjs/Observable';


@Injectable()
export class ProfileService implements OnInit {
  url = 'https://api.github.com/users/';
  constructor(private _http: Http) {
  }
  getUser(user: string): Observable<Profile[]> {
    return this._http.get(this.url + user).map(profile => profile.json());
  }
  getFollowers(user: string): Observable<Followers> {
    return this._http.get(this.url + user + '/followers').map(followers => followers.json());
  }
  ngOnInit() {

  }
}
