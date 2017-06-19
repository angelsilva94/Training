import { SpinnerComponent } from './spinner.component';
import { PostService } from './posts/post.service';
import { NotFoundComponent } from './notFound.component';
import { PreventUnsavedChanges } from './users/PreventUnsavedChanges';

import { AddUserComponent } from './users/addUser.component';
import { UserService } from './users/users.service';
import { PostComponent } from './posts/posts.component';
import { UserComponent } from './users/users.component';
import { RouterModule, Routes } from '@angular/router';
import { routing } from './app.routing';
import { HomeComponent } from './home.component';
import { NavbarComponent } from './navbar.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { HttpModule, JsonpModule } from '@angular/http';
import { User } from 'app/users/user';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    UserComponent,
    PostComponent,
    AddUserComponent,
    NotFoundComponent,
    SpinnerComponent
  ],
  imports: [
    BrowserModule,
    routing,
    HttpModule,
    JsonpModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    UserService,
    PreventUnsavedChanges,
    PostService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
