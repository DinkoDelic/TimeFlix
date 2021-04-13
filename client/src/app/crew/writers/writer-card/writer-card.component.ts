import { Component, Input, OnInit } from '@angular/core';
import { IWriter } from 'src/app/_models/IWriter';

@Component({
  selector: 'app-writer-card',
  templateUrl: './writer-card.component.html',
  styleUrls: ['./writer-card.component.scss']
})
export class WriterCardComponent implements OnInit {
  @Input() writer: IWriter;
  constructor() { }

  ngOnInit(): void {
  }

}
