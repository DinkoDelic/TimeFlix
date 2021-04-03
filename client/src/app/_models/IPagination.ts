import { IMovie } from "./IMovie";

export interface IPagination {
    currentPage: number;
    offset: number;
    totalPages: number;
    data: [];
  }