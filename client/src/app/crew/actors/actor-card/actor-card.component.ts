import { Component, Input, OnInit } from '@angular/core';
import { IActor } from 'src/app/_models/IActor';

@Component({
  selector: 'app-actor-card',
  templateUrl: './actor-card.component.html',
  styleUrls: ['./actor-card.component.scss']
})
export class ActorCardComponent implements OnInit {
  @Input() actor: IActor;
  imageUrl: string;
  constructor() { }

  ngOnInit(): void {
    this.imageUrl = this.actor.imageUrl ?? '../../../../assets/PlaceholderImage.png';
  }

}
