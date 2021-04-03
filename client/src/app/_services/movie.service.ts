import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IMovie } from '../_models/IMovie';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagination } from '../_models/IPagination';

@Injectable({
  providedIn: 'root',
})
export class MovieService {
  url: string = "https://localhost:5001/";
  movies: IMovie[];

  constructor(private http: HttpClient) {}

  GetMovies() {
    return this.http.get(this.url + 'Movie')
      .subscribe((response:IPagination) => {
        return response.data;
      }, error => {
        console.log(error);
      });
  }
}
