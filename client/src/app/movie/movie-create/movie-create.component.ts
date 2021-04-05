import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';


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
      duration: ''
    });
  }

}
