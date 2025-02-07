import { SubscriptionComponent } from './subscription.component';
import { FormsModule } from '@angular/forms';
import { ContactFormComponent } from './contact-form.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent,
    ContactFormComponent,
    SubscriptionComponent
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
