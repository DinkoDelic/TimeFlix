import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IMovie } from '../_models/IMovie';
import { IPagination } from '../_models/IPagination';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class MovieService {
  movies: IMovie[];

  constructor(private http: HttpClient) {}

  GetMovies() {
    return this.http.get<IPagination>(environment.url + 'Movie');
  }

  GetMovie(id:any) {
    return this.http.get<IMovie>(environment.url + 'Movie/' + id);
  }
}
