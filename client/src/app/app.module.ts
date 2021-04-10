import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import { MovieCreateComponent } from './movie/movie-create/movie-create.component';
import { AppRoutingModule } from './app-routing.module';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { TypeaheadModule } from 'ngx-bootstrap/typeahead';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { MovieListComponent } from './movie/movie-list/movie-list.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { MovieCardComponent } from './movie/movie-card/movie-card.component';
import { MovieDetailedComponent } from './movie/movie-detailed/movie-detailed.component';
import { HomeComponent } from './home/home.component';
import { MovieEditComponent } from './movie/movie-edit/movie-edit.component';



@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    NavBarComponent,
    MovieListComponent,
    MovieCardComponent,
    MovieDetailedComponent,
    HomeComponent,
    MovieCreateComponent,
    MovieEditComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MDBBootstrapModule.forRoot(),
    HttpClientModule,
    PaginationModule.forRoot(),
    BrowserAnimationsModule,
    ReactiveFormsModule,
    BsDatepickerModule.forRoot(),
    TypeaheadModule.forRoot(),
    FormsModule
  ],
  providers: [
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
