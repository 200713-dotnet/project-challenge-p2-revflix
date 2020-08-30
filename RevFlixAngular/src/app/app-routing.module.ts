import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MoviesComponent } from './movies/movies.component';
import { SearchmenuComponent } from './searchmenu/searchmenu.component';
import { MovieDetailComponent } from './movie-detail/movie-detail.component';

const routes: Routes = [
  { path: '', redirectTo: '/search', pathMatch: 'full' },
  { path: 'search', component: SearchmenuComponent },
  { path: 'detail/:id', component: MovieDetailComponent},
  { path: 'movies', component: MoviesComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }