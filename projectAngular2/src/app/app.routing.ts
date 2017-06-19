import { NotFoundComponent } from './notFound.component';
import { PreventUnsavedChanges } from './users/PreventUnsavedChanges';
import { AddUserComponent } from './users/addUser.component';
import { PostComponent } from './posts/posts.component';
import { UserComponent } from './users/users.component';
import { HomeComponent } from './home.component';
import { RouterModule } from '@angular/router';



export const routing = RouterModule.forRoot([
  { path: '', component: HomeComponent },
  { path: 'user', component: UserComponent },
  { path: 'post', component: PostComponent },
  { path: 'user/addUser', component: AddUserComponent, canDeactivate: [PreventUnsavedChanges] },
  { path: 'user/:id', component: AddUserComponent, canDeactivate: [PreventUnsavedChanges] },
  { path: 'notFound', component: NotFoundComponent },
  { path: '**', redirectTo: '' }

]);
