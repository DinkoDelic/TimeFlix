import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ActorDetailedComponent } from './actors/actor-detailed/actor-detailed.component';
import { ActorListComponent } from './actors/actor-list/actor-list.component';

const routes: Routes = [
  { path: 'actors', component: ActorListComponent },
  { path: 'actors/:actorid', component: ActorDetailedComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CrewRoutingModule {}
