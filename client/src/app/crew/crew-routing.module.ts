import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ActorDetailedComponent } from './actors/actor-detailed/actor-detailed.component';
import { ActorListComponent } from './actors/actor-list/actor-list.component';
import { DirectorDetailedComponent } from './directors/director-detailed/director-detailed.component';
import { DirectorListComponent } from './directors/director-list/director-list.component';
import { WriterDetailedComponent } from './writers/writer-detailed/writer-detailed.component';
import { WriterListComponent } from './writers/writer-list/writer-list.component';

const routes: Routes = [
  { path: 'actors', component: ActorListComponent },
  { path: 'actors/:actorid', component: ActorDetailedComponent },
  { path: 'writers', component: WriterListComponent },
  { path: 'writers/:writerid', component: WriterDetailedComponent },
  { path: 'directors', component: DirectorListComponent },
  { path: 'directors/:directorid', component: DirectorDetailedComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CrewRoutingModule {}
