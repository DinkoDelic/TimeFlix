using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.Helpers;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieContext _movieContext;
        private readonly Mapper _mapper;
        public MovieRepository(MovieContext movieContext, Mapper mapper)
        {
            _mapper = mapper;
            _movieContext = movieContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _movieContext.Add(entity);
        }

        public void Remove<T>(T entity) where T : class
        {
            _movieContext.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            // Method returns number of changes made, if higher then 0 return true 
            return await _movieContext.SaveChangesAsync() > 0;
        }


        public async Task<PaginatedList<MovieDto>> GetAllMoviesAsync(UserParams userParams)
        {
            int moviesCount = await _movieContext.Movies.CountAsync();

            var movies = await _movieContext.Movies
                .Include(m => m.ActorsLink)
                // Includes actors from movie in ActorsLink collection
                .ThenInclude(a => a.Actor)

                .Include(m => m.DirectorsLink)
                // Includes directors from movie in DirectorsLink collection
                .ThenInclude(d => d.Director)

                .Include(m => m.WritersLink)
                // Includes writers from movie in WritersLink collection
                .ThenInclude(w => w.Writer)
                .OrderBy(m => m.Title)
                .Skip((userParams.CurrentPage - 1) * userParams.Offset)
                .Take(userParams.Offset)
                // Query data from multiple collections as individual queries for better performance
                // Doing it as a single query will give us a warning about potential performance hit in terminal
                .AsSplitQuery()
                .ToListAsync();

            var moviesToReturn = _mapper.MapMovieToMovieDtoList(movies);

            return new PaginatedList<MovieDto>(moviesToReturn, userParams.CurrentPage, moviesCount, userParams.Offset);
        }

        public async Task<MovieDto> GetMovieByIdAsync(int id)
        {
            var movie = await _movieContext.Movies
                .Include(m => m.ActorsLink)
                .ThenInclude(a => a.Actor)
                .Include(m => m.DirectorsLink)
                .ThenInclude(d => d.Director)
                .Include(m => m.WritersLink)
                .ThenInclude(w => w.Writer)
                .OrderBy(m => m.Title)
                .AsSplitQuery()
                .FirstOrDefaultAsync(m => m.MovieId == id);
            
            if(movie == null)
                return null;

            // Mapper method takes in and returns Lists but
            // we only need the first item for single instance Get
            var movieToReturn = _mapper.MapMovieToMovieDtoList(new List<Movie>(){movie}).First();

            return movieToReturn;
        }

        public Task<Movie> UpdateMovieByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

    }
}

