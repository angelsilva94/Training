import { AddUserComponent } from './users/addUser.component';
import { PostComponent } from './posts/posts.component';
import { UserComponent } from './users/users.component';

import { HomeComponent } from './home.component';
import { Router, RouterModule } from '@angular/router';

export const routing = RouterModule.forRoot([
  { path: '', component: HomeComponent },
  { path: 'user', component: UserComponent },
  { path: 'post', component: PostComponent },
  { path: 'user/addUser', component: AddUserComponent },
  { path: '**', redirectTo: '' }
]);
