import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { UserParams } from '../helpers/userParams';
import { IPagination } from '../_models/IPagination';
import { IDirector } from '../_models/IDirector';

@Injectable({
  providedIn: 'root',
})
export class DirectorService {
  directors: IDirector[];

  constructor(private http: HttpClient) {}

  // Get paginated response
  getDirectors(userParams: UserParams) {
    let params = new HttpParams();
    if (userParams.currentPage !== 0) {
      params = params.append('currentPage', userParams.currentPage.toString());
    }
    // directors will be shown in sets of 6
    params = params.append('offset', '6');

    if (userParams.nameFilter !== null) {
      params = params.append('nameFilter', userParams.nameFilter.toString());
    }

    return (
      this.http
        .get<IPagination>(environment.url + 'Crew/director', {
          observe: 'response',
          params,
        })
        // pipe serves as a wrapper for any rxjs operators
        .pipe(
          map((response) => {
            // returns the body of our request with the data in it
            return response.body;
          })
        )
    );
  }

  getDirector(id) {
    return this.http.get<IDirector>(environment.url + 'Crew/director/' + id);
  }
}
