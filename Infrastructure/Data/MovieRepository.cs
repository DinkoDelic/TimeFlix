using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieContext _movieContext;
        public MovieRepository(MovieContext movieContext)
        {
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
            // Returns true if changes were saved successfully
            return await _movieContext.SaveChangesAsync() > 0;
        }


        public async Task<List<Movie>> GetAllMoviesAsync(UserParams userParams)
        {

            var movies = await _movieContext.Movies
                // Includes actors from movie in ActorsLink collection
                .Include(m => m.ActorsLink)
                .ThenInclude(a => a.Actor)
                // Includes directors from movie in DirectorsLink collection
                .Include(m => m.DirectorsLink)
                .ThenInclude(d => d.Director)
                // Includes writers from movie in WritersLink collection
                .Include(m => m.WritersLink)
                .ThenInclude(w => w.Writer)
                .OrderBy(m => m.Title)
                // Implementing pagination parameters with .Skip and .Take
                .Skip((userParams.CurrentPage - 1) * userParams.Offset)
                .Take(userParams.Offset)
                // Query data from multiple collections as individual queries for better performance
                // Doing it as a single query will give us a warning about potential performance hit
                .AsSplitQuery()
                .ToListAsync();


            return movies;
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
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
            
            return movie;
        }

        public Task<Movie> UpdateMovieByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> GetTotalMovieCount()
        {
            return await _movieContext.Movies.CountAsync();
        }

    }
}

