import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { UserParams } from 'src/app/helpers/userParams';
import { IWriter } from 'src/app/_models/IWriter';
import { WriterService } from 'src/app/_services/writer.service';

@Component({
  selector: 'app-writer-list',
  templateUrl: './writer-list.component.html',
  styleUrls: ['./writer-list.component.scss']
})
export class WriterListComponent implements OnInit {
  writers: IWriter[];
  itemCount: number;
  userParam = new UserParams();
  @ViewChild('search', {static: false}) searchTerm: ElementRef;

  constructor(private writerService: WriterService) { }

  ngOnInit() {
    this.getWriters();
  }

  getWriters() {
    // We subscribe to observable of type IPagination
    this.writerService.getWriters(this.userParam).subscribe(response => {
      this.writers = response.data;
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
    this.getWriters();
  }
  // Removes search name param and call getMovies without it
  onReset(){
    this.userParam.nameFilter = null;
    this.searchTerm.nativeElement.value = 'Search';
    console.log(this.searchTerm.nativeElement.value);
    this.getWriters();
  }

  pageChanged(event: any): void {
      this.userParam.currentPage = event.page;
      this.getWriters();
    }

}
