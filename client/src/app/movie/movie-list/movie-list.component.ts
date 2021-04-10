
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { IMovie } from '../../_models/IMovie';
import { MovieService } from '../../_services/movie.service';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { UserParams } from 'src/app/helpers/userParams';

@Component({
  selector: 'app-movie',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.scss']
})
export class MovieListComponent implements OnInit {
  movies: IMovie[];
  itemCount: number;
  userParam = new UserParams();
  @ViewChild('search', {static: false}) searchTerm: ElementRef;

  constructor(private movieService: MovieService) { }

  ngOnInit() {
    this.getMovies();
  }

  getMovies() {
    // We subscribe to observable of type IPagination
    this.movieService.getMovies(this.userParam).subscribe(response => {
      this.movies = response.data;
      this.userParam.offset = response.offset;
      this.userParam.currentPage = response.currentPage;
      this.itemCount = response.itemCount;
    }, error => {
      console.log(error);
    });
  }
  // Takes the value from search input and assigns it to userParams, then call getMovies with those params
  onSearch(){
    console.log(this.searchTerm.nativeElement.value);
    this.userParam.nameFilter = this.searchTerm.nativeElement.value;
    this.userParam.currentPage = 1;
    this.getMovies();
  }
  // Removes search name param and call getMovies without it
  onReset(){
    this.userParam.nameFilter = null;
    this.searchTerm.nativeElement.value = 'Search';
    console.log(this.searchTerm.nativeElement.value);
    this.getMovies();
  }

  pageChanged(event: any): void {
      this.userParam.currentPage = event.page;
      this.getMovies();
    }

}
