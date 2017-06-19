import { PostService } from './post.service';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'post',
  templateUrl: 'post.component.html'
})

export class PostComponent implements OnInit {
  posts;
  isLoading = true;
  constructor(private _postService: PostService) {}
  ngOnInit() {
    this._postService.getPosts().subscribe(postsR => {
      console.log(postsR);
      this.posts = postsR;
    },
      error => console.log(error),
      () => {
        console.log('ya acabe POSTS')
        // setTimeout(() => this.isLoading = false, 2000);
        this.isLoading = false;
        console.log(this.isLoading);

      }
    );
  }
}
