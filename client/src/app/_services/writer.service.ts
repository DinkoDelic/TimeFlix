import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { UserParams } from '../helpers/userParams';
import { IPagination } from '../_models/IPagination';
import { IWriter } from '../_models/IWriter';

@Injectable({
  providedIn: 'root',
})
export class WriterService {
  writers: IWriter[];

  constructor(private http: HttpClient) {}

  // Get paginated response
  getWriters(userParams: UserParams) {
    let params = new HttpParams();
    if (userParams.currentPage !== 0) {
      params = params.append('currentPage', userParams.currentPage.toString());
    }
    // writers will be shown in sets of 6
    params = params.append('offset', '6');

    if (userParams.nameFilter !== null) {
      params = params.append('nameFilter', userParams.nameFilter.toString());
    }

    return (
      this.http
        .get<IPagination>(environment.url + 'Crew/writer', {
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

  getWriter(id) {
    return this.http.get<IWriter>(environment.url + 'Crew/writer/' + id);
  }
}
