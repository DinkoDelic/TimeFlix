
import { Component, OnInit } from '@angular/core';
import { IMovie } from '../../_models/IMovie';
import { MovieService } from '../../_services/movie.service';

@Component({
  selector: 'app-movie',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.sass']
})
export class MovieListComponent implements OnInit {
  movies: IMovie[];
  offset: number;
  itemCount: number;

  constructor(private movieService: MovieService) { }

  ngOnInit() {
    this.movieService.GetMovies().subscribe(response => {
      this.movies = response.data;
      this.offset = response.offset;
      this.itemCount = response.itemCount;
    }, error => {
      console.log(error);
    });
  }

}
