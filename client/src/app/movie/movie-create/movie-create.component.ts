import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormArray } from '@angular/forms';


@Component({
  selector: 'app-movie-create',
  templateUrl: './movie-create.component.html',
  styleUrls: ['./movie-create.component.sass']
})
export class MovieCreateComponent implements OnInit {
  myFrom: FormGroup;
  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.myFrom = this.fb.group({
      title: '',
      plot: '',
      ageRating: '',
      releaseDate: '',
      duration: '',
      directors: this.fb.array([]),
      writers: this.fb.array([]),
      actors: this.fb.array([])
    });
  }

  get directorForms() {
    return this.myFrom.get('directors') as FormArray;
  }

  addDirector() {
    const director = this.fb.group({
      name: []
    });

    this.directorForms.push(director);
  }
  deleteDirector(i) {
    this.directorForms.removeAt(i);
  }


}
