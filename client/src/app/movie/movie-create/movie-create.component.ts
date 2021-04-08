
import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormArray,
  FormControl,
  Validators,
} from '@angular/forms';
import { GenreList } from 'src/app/helpers/genreList';
import { IMovie } from 'src/app/_models/IMovie';

@Component({
  selector: 'app-movie-create',
  templateUrl: './movie-create.component.html',
  styleUrls: ['./movie-create.component.scss'],
})
export class MovieCreateComponent implements OnInit {
  movie: IMovie;
  genreList;
  myForm: FormGroup;
  director: FormGroup;
  genre: FormGroup;
  actor: FormGroup;
  writer: FormGroup;

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
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
