import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { IMovie } from '../_models/IMovie';
import { IPagination } from '../_models/IPagination';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { UserParams } from '../helpers/userParams';

@Injectable({
  providedIn: 'root',
})
export class MovieService {
  movies: IMovie[];

  constructor(private http: HttpClient) {}

  GetMovies(userParams: UserParams) {
    let params = new HttpParams();
    if (userParams.currentPage !== 0)
    {
      params = params.append('currentPage', userParams.currentPage.toString());
    }
    if (userParams.offset !== 0)
    {
      params = params.append('offset', userParams.offset.toString());
    }
    if(userParams.nameFilter !== null)
    {
      params = params.append('nameFilter', userParams.nameFilter.toString());
    }

    return this.http.get<IPagination>(environment.url + 'Movie', {observe: 'response', params})
     // pipe serves as a wrapper for any rxjs operators
     .pipe(
      map(response => {
        // returns the body of our request with the data in it
        return response.body;
      })
    )
  }

  GetMovie(id:any) {
    return this.http.get<IMovie>(environment.url + 'Movie/' + id);
  }
}
