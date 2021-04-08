import { IActor } from './IActor';
import { IDirector } from './IDirector';
import { IGenre } from './IGenre';
import { IWriter } from './IWriter';

export interface IMovie {
  movieId: number;
  title: string;
  genre?: IGenre[];
  plot: string;
  ageRating: string;
  releaseDate: Date;
  duration: number;
  writers?: IWriter[];
  actors?: IActor[];
  directors?: IDirector[];
}
