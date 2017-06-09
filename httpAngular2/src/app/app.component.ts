import { ProfileService } from './profile.service';
import { PostService } from './post.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
    <!--<div *ngIf="isLoading">
      <i class="fa fa-spinner fa-spin fa-3x"></i>
    </div>-->
    <!--<i class="fa fa-spinner fa-spin fa-3x"></i>-->
    <profile></profile>
  `
})
// usar siempre subscribe para llamarlo
export class AppComponent  {
  // title = 'app';
  // isLoading = true;
  // constructor(private _postService: PostService) {
  // //  this._postService.createPost({userId: 1, title: 'hola' , body: 'body' });
  // }
  // // llamadas al servidor se hacen en ngOnInit
  // ngOnInit() {
  //   this._postService.getPosts()
  //     .subscribe(posts => {
  //       this.isLoading = false;
  //       console.log(posts[0].body);
  //     });
  // }






}
