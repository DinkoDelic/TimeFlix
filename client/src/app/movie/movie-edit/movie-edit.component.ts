import { Component, OnInit } from '@angular/core';
import {
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { GenreList } from 'src/app/helpers/genreList';
import { IMovie } from 'src/app/_models/IMovie';
import { MovieService } from 'src/app/_services/movie.service';

@Component({
  selector: 'app-movie-edit',
  templateUrl: './movie-edit.component.html',
  styleUrls: ['./movie-edit.component.sass'],
})
export class MovieEditComponent implements OnInit {
  movie?: IMovie;
  genreList;
  myForm: FormGroup;
  director: FormGroup;
  genre: FormGroup;
  actor: FormGroup;
  writer: FormGroup;

  constructor(
    private fb: FormBuilder,
    private movieService: MovieService,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    // uses activatedRoute to grab id paramater from url
    this.movieService
      .GetMovie(this.activatedRoute.snapshot.paramMap.get('movieid'))
      .subscribe(
        (response) => {
          this.movie = response;
        },
        (error) => {
          console.log(error);
        }
      );
    this.createForm();
    this.genreList = new GenreList();
  }

  createForm() {
    this.myForm = this.fb.group({
      title: new FormControl('', Validators.required),
      duration: new FormControl('', Validators.required),
      plot: new FormControl(''),
      ageRating: new FormControl('PG-13', Validators.required),
      releaseDate: new FormControl('', Validators.required),
      genres: new FormArray([], Validators.required),
      directors: new FormArray([]),
      writers: new FormArray([]),
      actors: new FormArray([]),
    });
  }

  createNew() {
    if (this.myForm.valid) {
      this.movie = Object.assign({}, this.myForm.value);
    }
    console.log(this.movie);
  }

  // Adding and removing genres
  get genreForms() {
    return this.myForm.get('genres') as FormArray;
  }


  addGenre() {
    this.genre = this.fb.group({
      name: new FormControl('', Validators.required),
    });

    this.genreForms.push(this.genre);
  }
  deleteGenre(i) {
    this.genreForms.removeAt(i);
  }

  // Adding and removing directors
  get directorForms() {
    return this.myForm.get('directors') as FormArray;
  }

  addDirector() {
    this.director = this.fb.group({
      name: new FormControl('', Validators.required),
    });

    this.directorForms.push(this.director);
  }
  deleteDirector(i) {
    this.directorForms.removeAt(i);
  }

  // Adding and removing writers
  get writerForms() {
    return this.myForm.get('writers') as FormArray;
  }

  addWriter() {
    this.writer = this.fb.group({
      name: new FormControl('', Validators.required),
    });

    this.writerForms.push(this.writer);
  }
  deleteWriter(i) {
    this.writerForms.removeAt(i);
  }

  // Adding and removing actors
  get actorForms() {
    return this.myForm.get('actors') as FormArray;
  }

  addActor() {
    this.actor = this.fb.group({
      name: new FormControl('', Validators.required),
    });

    this.actorForms.push(this.actor);
  }
  deleteActor(i) {
    this.actorForms.removeAt(i);
  }
}
