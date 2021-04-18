import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CrewRoutingModule } from './crew-routing.module';
import { PaginationModule } from 'ngx-bootstrap/pagination';

import { ActorListComponent } from './actors/actor-list/actor-list.component';
import { ActorDetailedComponent } from './actors/actor-detailed/actor-detailed.component';
import { ActorCardComponent } from './actors/actor-card/actor-card.component';
import { WriterListComponent } from './writers/writer-list/writer-list.component';
import { WriterCardComponent } from './writers/writer-card/writer-card.component';
import { WriterDetailedComponent } from './writers/writer-detailed/writer-detailed.component';
import { DirectorListComponent } from './directors/director-list/director-list.component';
import { DirectorCardComponent } from './directors/director-card/director-card.component';
import { DirectorDetailedComponent } from './directors/director-detailed/director-detailed.component';

@NgModule({
  declarations: [
    ActorListComponent,
    ActorDetailedComponent,
    ActorCardComponent,
    WriterListComponent,
    WriterCardComponent,
    WriterDetailedComponent,
    DirectorListComponent,
    DirectorCardComponent,
    DirectorDetailedComponent,
  ],
  imports: [CommonModule, CrewRoutingModule, PaginationModule.forRoot()],
})
export class CrewModule {}
