import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MovieCreateComponent } from './movie/movie-create/movie-create.component';
import { MovieDetailedComponent } from './movie/movie-detailed/movie-detailed.component';
import { MovieListComponent } from './movie/movie-list/movie-list.component';

// routing to our various components
const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'movie', component: MovieListComponent},
  {path: 'movie/:movieid', component: MovieDetailedComponent},
  {path: 'movie/create', component: MovieCreateComponent},
  // non existing paths get redirected to home page
  {path: '**', redirectTo: '', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
