import { Observable } from 'rxjs/Observable';
import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';
@Injectable()
export class PostService {
  private _url = 'https://jsonplaceholder.typicode.com/posts';
  constructor(private _http: Http) { }

  getPosts(filter?) {
    let url = this._url;
    if (filter && filter.userId) {
      url += '?userId=' + filter.userId;
      console.log('filter');
      console.log(url);
    }
    return this._http.get(url).map(posts => posts.json());
  }
  getPost(id) {
    return this._http.get(this._url + '/' + id).map(post => post.json());
  }
  updatePost(post) {
    return this._http.put(this._url + '/' + post.id, post).map(postR => postR.json());
  }
  deletePost(id) {
    return this._http.delete(this._url + '/' + id).map(post => post.json());
  }
  postPost(body) {
    return this._http.post(this._url, body).map(post => post.json());
  }
  getComments(id) {
    return this._http.get(this._url + '/' + id + '/comments').map(comment => comment.json());
  }

}
