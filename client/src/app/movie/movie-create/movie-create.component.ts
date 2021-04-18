import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormArray,
  FormControl,
  Validators,
} from '@angular/forms';
import { delay } from 'rxjs/operators';
import { GenreList } from 'src/app/helpers/genreList';
import { IImage } from 'src/app/_models/IImage';
import { IMovie } from 'src/app/_models/IMovie';
import { MovieService } from 'src/app/_services/movie.service';

@Component({
  selector: 'app-movie-create',
  templateUrl: './movie-create.component.html',
  styleUrls: ['./movie-create.component.scss'],
})
export class MovieCreateComponent implements OnInit {
  movie: IMovie;
  genreList;
  myForm: FormGroup;
  img?: IImage;

  constructor(private fb: FormBuilder, private movieService: MovieService) {}

  ngOnInit(): void {
    this.createForm();
    // Used for auto complete function when adding genres
    this.genreList = new GenreList();
    //this.getDogImage();
  }

  // Using form builder to create form
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

  createNew() {
    if (this.myForm.valid) {
      this.movie = Object.assign({}, this.myForm.value);
    }
    this.movie.genres = this.reduce(this.movie.genres);
    this.movie.directors = this.reduce(this.movie.directors);
    this.movie.writers = this.reduce(this.movie.writers);
    this.movie.actors = this.reduce(this.movie.actors);
    this.movieService.createMovie(this.movie).subscribe(
      (response) => {
        console.log(response);
      },
      (error) => {
        console.log(error);
      }
    );
  }

  // Removes duplicates from our form
  reduce(array: Array<any>) {
    const res = [];
    array.map(function (item: any) {
      const existItem = res.find((x) => x.name === item.name);
      if (!existItem) {
        res.push(item);
      }
    });
    return res;
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
  deleteGenre(i) {
    this.genreForms.removeAt(i);
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
    director
      .get('imageUrl')
      .setValue(this.img ? this.img.message : '../../../../assets/PlaceholderImage.png');

    this.directorForms.push(director);
  }
  deleteDirector(i) {
    this.directorForms.removeAt(i);
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
    writer
      .get('imageUrl')
      .setValue(this.img.message ?? '../../../../assets/PlaceholderImage.png');
    this.writerForms.push(writer);
  }
  deleteWriter(i) {
    this.writerForms.removeAt(i);
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
    actor
      .get('imageUrl')
      .setValue(this.img.message ?? '../../../../assets/PlaceholderImage.png');
    this.actorForms.push(actor);
  }
  deleteActor(i) {
    this.actorForms.removeAt(i);
  }
}
