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
  postUser(body) {
    return this._http.post(this._url, body).map(user => user.json());
  }
  getUser(id) {
    return this._http.get(this._url + '/' + id).map(user => user.json());
  }
  updateService(user) {
    return this._http.put(this._url + '/' + user.id, user).map(userR => userR.json());
  }
  deleteUser(id) {
    return this._http.delete(this._url + '/' + id).map(user => user.json());
  }

}
