import { IActor } from "./IActor";
import { IDirector } from "./IDirector";
import { IWriter } from "./IWriter";

export interface IMovie {
  movieId: number;
  title: string;
  genre: string;
  storyline: string;
  ageRating: string;
  releaseDate: Date;
  duration: Date;
  writers?: IWriter[];
  actors?: IActor[];
  directors?: IDirector[];
}
