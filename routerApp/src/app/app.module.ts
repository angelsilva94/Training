import { archivesRouting } from './archives/archives.routing';
import { TestComponent } from './test.component';
import { ArchiveComponent } from './archive.component';
import { HelloComponent } from './hello.component';
import { routing } from './app.routing';
import { ArchivesComponent } from './archives.component';
import { RouterModule, Routes } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';


@NgModule({
  declarations: [
    AppComponent,
    ArchivesComponent,
    HelloComponent,
    ArchiveComponent,
    TestComponent
  ],
  imports: [
    BrowserModule,
    archivesRouting,
    routing

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
