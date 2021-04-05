import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IMovie } from 'src/app/_models/IMovie';
import { MovieService } from 'src/app/_services/movie.service';

@Component({
  selector: 'app-movie-detailed',
  templateUrl: './movie-detailed.component.html',
  styleUrls: ['./movie-detailed.component.scss']
})
export class MovieDetailedComponent implements OnInit {
  movie: IMovie;
  
  constructor(private movieService: MovieService, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    // uses activatedRoute to grab id paramater from url
    this.movieService.GetMovie(this.activatedRoute.snapshot.paramMap.get('movieid')).subscribe(response => {
      this.movie = response;
    }, error => {
      console.log(error);
    });
  }

}
