import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import {
  AbstractControl,
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { error } from 'selenium-webdriver';
import { GenreList } from 'src/app/helpers/genreList';
import { IActor } from 'src/app/_models/IActor';
import { IDirector } from 'src/app/_models/IDirector';
import { IGenre } from 'src/app/_models/IGenre';
import { IImage } from 'src/app/_models/IImage';
import { IMovie } from 'src/app/_models/IMovie';
import { IWriter } from 'src/app/_models/IWriter';
import { MovieService } from 'src/app/_services/movie.service';

@Component({
  selector: 'app-movie-edit',
  templateUrl: './movie-edit.component.html',
  styleUrls: ['./movie-edit.component.scss'],
})
export class MovieEditComponent implements OnInit {
  movie?: IMovie;
  myForm: FormGroup;
  genreList;
  img: IImage;

  constructor(
    private movieService: MovieService,
    private activatedRoute: ActivatedRoute,
    private fb: FormBuilder
  ) {}

  async ngOnInit(): Promise<void> {
    // uses activatedRoute to grab id paramater from url
    this.movieService
      .getMovie(this.activatedRoute.snapshot.paramMap.get('movieid'))
      .subscribe(
        (response) => {
          this.movie = response;
        },
        (error) => {
          console.log(error);
        }
      );

    this.createForm();
    this.getDogImage();
    this.genreList = new GenreList();
  }

  // Using form builder to create form
  createForm() {
    this.myForm = this.fb.group({
      genres: new FormArray([]),
      directors: new FormArray([]),
      writers: new FormArray([]),
      actors: new FormArray([]),
    });
  }

  updateMovie() {
    if (this.myForm.valid) {
      this.genreForms.value.forEach((element) => {
        if (this.movie.genres.every((x) => x.name !== element.name)) {
          this.movie.genres.push(element);
        }
      });
      this.directorForms.value.forEach((element) => {
        if (this.movie.directors.every((x) => x.name !== element.name)) {
          this.movie.directors.push(element);
        }
      });
      this.writerForms.value.forEach((element) => {
        if (this.movie.writers.every((x) => x.name !== element.name)) {
          this.movie.writers.push(element);
        }
      });
      this.actorForms.value.forEach((element) => {
        if (this.movie.actors.every((x) => x.name !== element.name)) {
          this.movie.actors.push(element);
        }
      });

      this.movieService.updateMovie(this.movie).subscribe(
        (response) => {
          console.log(response);
        },
        (error) => {
          console.log(error);
        }
      );
    }
  }

  // Adding and removing genres
  get genreForms() {
    return this.myForm.get('genres') as FormArray;
  }

  addGenre() {
    const genre = this.fb.group({
      name: new FormControl('', Validators.required),
    });

    this.genreForms.push(genre);
  }
  deleteGenre(array: any[], i) {
    array.splice(i, 1);
  }
  deleteNewItem(array: FormArray, i) {
    array.removeAt(i);
  }

  // Adding and removing directors
  get directorForms() {
    return this.myForm.get('directors') as FormArray;
  }

  addDirector() {
    const director = this.fb.group({
      name: new FormControl('', Validators.required),
      imageUrl: new FormControl(),
    });
    this.getDogImage();
    director.get('imageUrl').setValue(this.img.message ?? '');

    this.directorForms.push(director);
  }
  deleteDirector(array: IDirector[], i) {
    array.splice(i, 1);
  }

  // Adding and removing writers
  get writerForms() {
    return this.myForm.get('writers') as FormArray;
  }

  addWriter() {
    const writer = this.fb.group({
      name: new FormControl('', Validators.required),
      imageUrl: new FormControl(),
    });
    this.getDogImage();
    writer.get('imageUrl').setValue(this.img.message ?? '');

    this.writerForms.push(writer);
  }
  deleteWriter(array: IWriter[], i) {
    array.splice(i, 1);
  }

  // Adding and removing actors
  get actorForms() {
    return this.myForm.get('actors') as FormArray;
  }

  addActor() {
    const actor = this.fb.group({
      name: new FormControl('', Validators.required),
      imageUrl: new FormControl(),
    });
    this.getDogImage();
    actor.get('imageUrl').setValue(this.img.message ?? '');

    this.actorForms.push(actor);
  }
  deleteActor(array: IActor[], i) {
    array.splice(i, 1);
  }

  // Gets random dog image for crew
  getDogImage() {
    this.movieService.GetDogImage().subscribe(
      (response) => {
        this.img = response.body;
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
