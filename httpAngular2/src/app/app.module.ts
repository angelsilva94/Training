import { ProfileComponent } from './profile.component';
import { ProfileService } from './profile.service';
import { PostService } from './post.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule, JsonpModule } from '@angular/http';

import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent,
    ProfileComponent

  ],
  imports: [
    BrowserModule,
    HttpModule,
    JsonpModule
  ],
  providers: [PostService, ProfileService],
  bootstrap: [AppComponent]
})
export class AppModule { }
