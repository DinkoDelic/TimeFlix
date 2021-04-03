import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IMovie } from '../_models/IMovie';
import { IPagination } from '../_models/IPagination';
import { MovieService } from '../_services/movie.service';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.sass']
})
export class MovieComponent implements OnInit {
  Movies: IMovie[];

  constructor(private movieService: MovieService, private http: HttpClient) { }

  ngOnInit() {
    this.http.get('https://localhost:5001/Movie?offset=2')
    .subscribe((response: IPagination) => {
      this.Movies = response.data;
    }, error => {
      console.log(error);
    });
  }

}
