import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IDirector } from 'src/app/_models/IDirector';
import { DirectorService } from 'src/app/_services/director.service';

@Component({
  selector: 'app-director-detailed',
  templateUrl: './director-detailed.component.html',
  styleUrls: ['./director-detailed.component.scss']
})
export class DirectorDetailedComponent implements OnInit {
  director: IDirector;
  constructor(
    private directorService: DirectorService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.getDirector();

  }

  getDirector() {
    this.directorService
      .getDirector(this.activatedRoute.snapshot.paramMap.get('directorid'))
      .subscribe(
        (response) => {
          this.director = response;
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
