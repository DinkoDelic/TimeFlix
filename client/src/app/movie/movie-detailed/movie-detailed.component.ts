import { Component, OnInit, TemplateRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IMovie } from 'src/app/_models/IMovie';
import { MovieService } from 'src/app/_services/movie.service';
import { BsModalService,BsModalRef } from 'ngx-bootstrap/modal';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-movie-detailed',
  templateUrl: './movie-detailed.component.html',
  styleUrls: ['./movie-detailed.component.scss'],
})
export class MovieDetailedComponent implements OnInit {
  movie: IMovie;
  modalRef: BsModalRef;
  url;
  constructor(
    private movieService: MovieService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private modalService: BsModalService,
    private sanitizer: DomSanitizer
  ) {}

  ngOnInit(): void {
    this.getMovie();
  }

  getMovie() {
    // uses activatedRoute to grab id paramater from url
    this.movieService
      .getMovie(this.activatedRoute.snapshot.paramMap.get('movieid'))
      .subscribe(
        (response) => {
          this.movie = response;
          // tells angular this url is safe to inject in DOM
          this.url =  this.sanitizer.bypassSecurityTrustResourceUrl(this.movie.trailerUrl);
        },
        (error) => {
          console.log(error);
        }
      );
  }

  deleteMovie(id) {
    return this.movieService.deleteMovie(id).subscribe(
      (response) => {
        console.log(response);
      },
      (error) => {
        console.log(error);
      }
    );
  }

  navigateToCrew(id, type: string) {
    if (type == 'actor') {
      this.router.navigateByUrl('crew/actors/' + id);
    } else if (type === 'writer') {
      this.router.navigateByUrl('crew/writers/' + id);
    } else {
      this.router.navigateByUrl('crew/directors/' + id);
    }
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }
 
  confirm(): void {
    this.deleteMovie(this.movie.movieId);
    this.modalRef.hide();
    this.router.navigateByUrl('/');
  }

  decline(): void {
    this.modalRef.hide();
  }
}
