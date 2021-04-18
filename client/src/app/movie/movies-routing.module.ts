import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MovieCreateComponent } from './movie-create/movie-create.component';
import { MovieDetailedComponent } from './movie-detailed/movie-detailed.component';
import { MovieEditComponent } from './movie-edit/movie-edit.component';
import { MovieListComponent } from './movie-list/movie-list.component';

const routes: Routes = [
  { path: '', component: MovieListComponent },
  { path: 'create', component: MovieCreateComponent },
  { path: ':movieid', component: MovieDetailedComponent },
  { path: ':movieid/edit', component: MovieEditComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MoviesRoutingModule {}
