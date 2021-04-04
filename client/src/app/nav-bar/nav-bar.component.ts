import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {


  Options = [
    {value: 'movie', label: 'Movie'},
    {value: 'actor', label: 'Actor'},
    {value: 'writer', label: 'Writer'},
    {value: 'director', label: 'Director'}
  ]

  constructor() { }

  ngOnInit(): void {
  }
  

}
