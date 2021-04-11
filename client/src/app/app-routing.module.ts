import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';

// routing to our various components
const routes: Routes = [
  {path: '', component: HomeComponent},
  // Lazy loading for our components
  { path: 'crew', loadChildren: () => import('./crew/crew.module').then(m => m.CrewModule) },
  { path: 'movies', loadChildren: () => import('./movie/movies.module').then(m => m.MoviesModule) },
  // non existing paths get redirected to home page
  {path: '**', redirectTo: '', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
