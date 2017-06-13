import { Observable } from 'rxjs/Observable';
import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import { Followers } from './followers';

@Injectable()
export class FollowersService {
    url= 'https://api.github.com/users/';
    constructor(private _http: Http){}
    getFollowers(user: string): Observable<Followers[]>{
      return this._http.get(this.url + user + '/followers').map(followers => followers.json());
    }
}
