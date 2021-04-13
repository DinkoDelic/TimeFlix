import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IWriter } from 'src/app/_models/IWriter';
import { WriterService } from 'src/app/_services/writer.service';

@Component({
  selector: 'app-writer-detailed',
  templateUrl: './writer-detailed.component.html',
  styleUrls: ['./writer-detailed.component.scss']
})
export class WriterDetailedComponent implements OnInit {
  writer: IWriter;
  constructor(
    private writerService: WriterService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.getWriter();

  }

  getWriter() {
    this.writerService
      .getWriter(this.activatedRoute.snapshot.paramMap.get('writerid'))
      .subscribe(
        (response) => {
          this.writer = response;
        },
        (error) => {
          console.log(error);
        }
      );
  }

  navigateToMovie(id) {
    this.router.navigateByUrl('/movies/' + id);
  }

}
