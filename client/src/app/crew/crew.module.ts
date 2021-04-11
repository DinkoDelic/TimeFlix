import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CrewRoutingModule } from './crew-routing.module';
import { ActorListComponent } from './actors/actor-list/actor-list.component';
import { ActorDetailedComponent } from './actors/actor-detailed/actor-detailed.component';
import { ActorCardComponent } from './actors/actor-card/actor-card.component';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { WriterListComponent } from './writers/writer-list/writer-list.component';
import { WriterCardComponent } from './writers/writer-card/writer-card.component';
import { WriterDetailedComponent } from './writers/writer-detailed/writer-detailed.component';

@NgModule({
  declarations: [
    ActorListComponent,
    ActorDetailedComponent,
    ActorCardComponent,
    WriterListComponent,
    WriterCardComponent,
    WriterDetailedComponent,
  ],
  imports: [CommonModule, CrewRoutingModule, PaginationModule.forRoot()],
})
export class CrewModule {}
