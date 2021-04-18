import { animate, style, transition, trigger } from '@angular/animations';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  animations: [
    trigger('entryAnim', [
      transition('void => *', [
        style({
          opacity: 0,
          transform: 'scale(0.5)'
        }),
        animate('0.5s ease-in-out', style({transform: 'scale(1.1)', opacity: 0.8})),
        animate('0.2s ease-out')
      ])
    ])
  ]
})
export class HomeComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
