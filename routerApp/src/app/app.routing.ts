import { TestComponent } from './test.component';
import { ArchiveComponent } from './archive.component';
import { HelloComponent } from './hello.component';
import { ArchivesComponent } from './archives.component';
import { Router, RouterModule } from '@angular/router';


export const routing = RouterModule.forRoot([

  { path: 'hola', component: HelloComponent },
  { path: 'test/:id', component: TestComponent },
]);
