import { IActor } from "./IActor";
import { IDirector } from "./IDirector";
import { IWriter } from "./IWriter";

export interface IMovie {
  movieId: number;
  title: string;
  genre: string;
  storyline: string;
  ageRating: string;
  releaseDate: string;
  duration: number;
  writers?: IWriter[];
  actors?: IActor[];
  directors?: IDirector[];
}
