import { UserService } from './../users/users.service';
import { PostService } from './post.service';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'post',
  templateUrl: 'post.component.html',
  styles: [`
        .posts li { cursor: default; }
        .posts li:hover { background: #ecf0f1; }
        .list-group-item.active,
        .list-group-item.active:hover,
        .list-group-item.active:focus {
            background-color: #ecf0f1;
            border-color: #ecf0f1;
            color: #2c3e50;
        }
    `]
})

export class PostComponent implements OnInit {
  posts;
  postLoading;
  details;
  postLoaded = false;
  currentPost;
  commentLoading;
  users;
  constructor(private _postService: PostService, private _userService: UserService ) {}
  ngOnInit() {
    this.loadPost();
    this.loadUsers();
  }
  private loadUsers() {
    this._userService.getUsers().subscribe(usersList => {
      console.log(usersList);
      this.users = usersList;
    }, null,
    () => {
      console.log('FINISH users');
    }
    )
  }
  private loadPost(filter?) {
    this.postLoading = true;
    this._postService.getPosts(filter).subscribe(postsR => {
      console.log(postsR);
      this.posts = postsR;
    },
      error => console.log(error),
      () => {
        console.log('ya acabe POSTS')
        // setTimeout(() => this.isLoading = false, 2000);
        this.postLoading = false;
        console.log(this.postLoading);

      }
    );
  }
  selectedPost(post) {
    this.currentPost = post;
    console.log(post);
    this.postLoaded = true;
    this.commentLoading = true;
    this._postService.getComments(post.id).subscribe(comments => {
      console.log(comments);
      this.currentPost.comments = comments;
    },
      error => console.log(error),
      () => {
        setTimeout(() => this.commentLoading = false, 2000);
        // this.commentLoading = false;
        console.log('ACABE');
    }
    )
  }

  reloadPosts(filter) {
    this.currentPost = null;
    this.loadPost(filter);
    console.log(filter);
  }
}
