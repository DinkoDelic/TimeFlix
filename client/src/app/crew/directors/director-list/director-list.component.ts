import { animate, query, stagger, style, transition, trigger } from '@angular/animations';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { UserParams } from 'src/app/helpers/userParams';
import { IDirector } from 'src/app/_models/IDirector';
import { DirectorService } from 'src/app/_services/director.service';

@Component({
  selector: 'app-director-list',
  templateUrl: './director-list.component.html',
  styleUrls: ['./director-list.component.scss'],
  animations: [
    trigger('listAnimation', [
      transition('* => *', [
        query(
          ':enter',
          [
            style({
              transform: 'scale(0.7)',
              opacity: 0
            }),
            stagger(0, [
              // animate(
              //   '0.3s ease-out',
              //   style({ opacity: 0.5, //transform: 'scale(1.1)'
              // })
              // ),
              animate('0.3s ease'),
            ]),
          ],
          { optional: true }
        ),
      ]),
    ]),
  ],
})
export class DirectorListComponent implements OnInit {
  directors: IDirector[];
  itemCount: number;
  userParam = new UserParams();
  @ViewChild('search', {static: false}) searchTerm: ElementRef;

  constructor(private directorService: DirectorService) { }

  ngOnInit() {
    this.getDirectors();
  }

  getDirectors() {
    // We subscribe to observable of type IPagination
    this.directorService.getDirectors(this.userParam).subscribe(response => {
      this.directors = response.data;
      this.userParam.offset = response.offset;
      this.userParam.currentPage = response.currentPage;
      this.itemCount = response.itemCount;
    }, error => {
      console.log(error);
    });
  }
  // Takes the value from search input and assigns it to userParams, then call getMovies with those params
  onSearch(){
    this.userParam.nameFilter = this.searchTerm.nativeElement.value;
    this.userParam.currentPage = 1;
    this.getDirectors();
  }
  // Removes search name param and call getMovies without it
  onReset(){
    this.userParam.nameFilter = null;
    this.searchTerm.nativeElement.value = 'Search';
    console.log(this.searchTerm.nativeElement.value);
    this.getDirectors();
  }

  pageChanged(event: any): void {
      this.userParam.currentPage = event.page;
      this.getDirectors();
    }


}
