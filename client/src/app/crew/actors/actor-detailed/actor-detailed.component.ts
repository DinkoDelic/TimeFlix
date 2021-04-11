import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { error } from 'selenium-webdriver';
import { IActor } from 'src/app/_models/IActor';
import { IMovie } from 'src/app/_models/IMovie';
import { ActorService } from 'src/app/_services/actor.service';

@Component({
  selector: 'app-actor-detailed',
  templateUrl: './actor-detailed.component.html',
  styleUrls: ['./actor-detailed.component.scss'],
})
export class ActorDetailedComponent implements OnInit {
  actor: IActor;
  constructor(
    private actorService: ActorService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.getActor();

  }

  getActor() {
    this.actorService
      .getActor(this.activatedRoute.snapshot.paramMap.get('actorid'))
      .subscribe(
        (response) => {
          this.actor = response;
        },
        (error) => {
          console.log(error);
        }
      );
  }

  getImage() {
    return this.actor.imageUrl ?? '../../../../assets/PlaceholderImage.png';
  }

  navigateToMovie(id) {
    this.router.navigateByUrl('/movies/' + id);
  }
}
