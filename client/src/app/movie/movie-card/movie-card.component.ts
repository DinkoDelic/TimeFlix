import { Component, Input, OnInit } from '@angular/core';
import { IMovie } from 'src/app/_models/IMovie';

@Component({
  selector: 'app-movie-card',
  templateUrl: './movie-card.component.html',
  styleUrls: ['./movie-card.component.sass']
})
export class MovieCardComponent implements OnInit {
  @Input() movie: IMovie;

  constructor() { }

  ngOnInit(): void {
  }

}
