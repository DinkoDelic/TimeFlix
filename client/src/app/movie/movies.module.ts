import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MoviesRoutingModule } from './movies-routing.module';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { TypeaheadModule } from 'ngx-bootstrap/typeahead';
import { ModalModule } from 'ngx-bootstrap/modal';

import { MovieListComponent } from './movie-list/movie-list.component';
import { MovieDetailedComponent } from './movie-detailed/movie-detailed.component';
import { MovieCardComponent } from './movie-card/movie-card.component';
import { MovieEditComponent } from './movie-edit/movie-edit.component';
import { MovieCreateComponent } from './movie-create/movie-create.component';
import { MDBBootstrapModule } from 'angular-bootstrap-md';

@NgModule({
  declarations: [
    MovieListComponent,
    MovieDetailedComponent,
    MovieCardComponent,
    MovieEditComponent,
    MovieCreateComponent
  ],
  imports: [
    CommonModule,
    MoviesRoutingModule,
    PaginationModule.forRoot(),
    ReactiveFormsModule,
    BsDatepickerModule.forRoot(),
    TypeaheadModule.forRoot(),
    FormsModule,
    MDBBootstrapModule.forRoot(),
    ModalModule.forRoot()
  ]
})
export class MoviesModule { }
