import { IActor } from './IActor';
import { IDirector } from './IDirector';
import { IGenre } from './IGenre';
import { IWriter } from './IWriter';

export interface IMovie {
  movieId: number;
  title: string;
  genres?: IGenre[];
  plot: string;
  ageRating: string;
  releaseDate: Date;
  duration: number;
  trailerUrl: string;
  writers?: IWriter[];
  actors?: IActor[];
  directors?: IDirector[];
}
