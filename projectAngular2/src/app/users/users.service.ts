import { Observable } from 'rxjs/Observable';
import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';
@Injectable()
export class UserService {
  private _url = 'https://jsonplaceholder.typicode.com/users';
  constructor(private _http: Http) { }
  getUsers() {
    return this._http.get(this._url).map(users => users.json());
  }

}
