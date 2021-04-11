import { IMovie } from './IMovie';
import { IMovieShort } from './IMovieShort';

export interface IActor {
  id: number;
  name: string;
  imageUrl: string;
  movieList?: IMovie[];
}
