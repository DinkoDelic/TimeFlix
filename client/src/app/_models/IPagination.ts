import { IMovie } from "./IMovie";

export interface IPagination {
    currentPage: number;
    offset: number;
    itemCount: number;
    totalPages: number;
    data: [];
  }