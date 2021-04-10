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

        public void Update<T>(T entity) where T : class
        {
            _movieContext.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            // Returns true if changes were saved successfully
            return await _movieContext.SaveChangesAsync() > 0;
        }


        public async Task<List<Movie>> GetAllMoviesAsync(UserParams userParams)
        {
            var movies = await _movieContext.Movies
                .Include(m => m.GenresLink)
                .ThenInclude(m => m.Genre)
                .OrderBy(m => m.Title)
                // Implementing pagination parameters with .Skip and .Take
                .Skip((userParams.CurrentPage - 1) * userParams.Offset)
                .Take(userParams.Offset)
                .ToListAsync();

            return movies;
        }

        public async Task<List<Movie>> SearchMoviesByNameAsync(UserParams userParams)
        {
            var movies = await _movieContext.Movies
               .Include(m => m.GenresLink)
               .ThenInclude(m => m.Genre)
               .Where(m => m.Title.ToLower().Contains(userParams.nameFilter.ToLower()))
               .OrderBy(m => m.Title)
               // Implementing pagination parameters with .Skip and .Take
               .Skip((userParams.CurrentPage - 1) * userParams.Offset)
               .Take(userParams.Offset)
               .ToListAsync();

            return movies;
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movie = await _movieContext.Movies
                .Include(m => m.GenresLink)
                .ThenInclude(m => m.Genre)
                .Include(m => m.ActorsLink)
                .ThenInclude(a => a.Actor)
                .Include(m => m.DirectorsLink)
                .ThenInclude(d => d.Director)
                .Include(m => m.WritersLink)
                .ThenInclude(w => w.Writer)
                .OrderBy(m => m.Title)
                // Query data from multiple collections as individual queries for better performance
                // Doing it as a single query will give us a warning about potential performance hit
                .AsSplitQuery()
                .FirstOrDefaultAsync(m => m.MovieId == id);

            return movie;
        }


        public async Task<int> GetTotalMovieCount(UserParams userParams)
        {
            if (userParams.nameFilter != null)
                return await _movieContext.Movies
                    .Where(m => m.Title.ToLower().Contains(userParams.nameFilter.ToLower()))
                    .CountAsync();
            else
                return await _movieContext.Movies.CountAsync();
        }

    }
}

