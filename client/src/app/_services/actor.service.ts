import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { UserParams } from '../helpers/userParams';
import { IActor } from '../_models/IActor';
import { IPagination } from '../_models/IPagination';

@Injectable({
  providedIn: 'root',
})
export class ActorService {
  actors: IActor[];

  constructor(private http: HttpClient) {}

  // Get paginated response
  getActors(userParams: UserParams) {
    let params = new HttpParams();
    if (userParams.currentPage !== 0) {
      params = params.append('currentPage', userParams.currentPage.toString());
    }
    // actors will be shown in sets of 6
    if (userParams.offset !== 0)
    {
      params = params.append('offset', '6');
    }

    if (userParams.nameFilter !== null) {
      params = params.append('nameFilter', userParams.nameFilter.toString());
    }

    return (
      this.http
        .get<IPagination>(environment.url + 'Crew/actor', {
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

  getActor(id) {
    return this.http.get<IActor>(environment.url + 'Crew/actor/' + id);
  }
}
