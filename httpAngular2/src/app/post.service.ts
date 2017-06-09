import { Post } from './post';
import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map'
import { Observable } from 'rxjs/Observable';

@Injectable()
export class PostService {
  url = 'https://jsonplaceholder.typicode.com/posts';
 constructor(private _http: Http) {}
 getPosts(): Observable<Post[]> {
  return this._http.get(this.url).map(res => res.json());
 }
 createPost(post: Post) {
   return this._http.post(this.url, JSON.stringify(post)).map(response => response.json());
 }

}
