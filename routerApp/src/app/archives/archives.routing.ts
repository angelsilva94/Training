import { ArchiveComponent } from './../archive.component';
import { ArchivesComponent } from './../archives.component';

import { Router, RouterModule } from '@angular/router';



export const archivesRouting = RouterModule.forChild([
  { path: '', component: ArchivesComponent},
  { path: 'arch/:year/:month', component: ArchiveComponent },

]);
