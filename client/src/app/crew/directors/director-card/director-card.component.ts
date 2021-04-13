import { Component, Input, OnInit } from '@angular/core';
import { IDirector } from 'src/app/_models/IDirector';

@Component({
  selector: 'app-director-card',
  templateUrl: './director-card.component.html',
  styleUrls: ['./director-card.component.scss']
})
export class DirectorCardComponent implements OnInit {
  @Input() director: IDirector;
  constructor() { }

  ngOnInit(): void {
  }


}
