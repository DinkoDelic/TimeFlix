using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<bool> SaveChangesAsync()
        {   
            if(await _movieContext.SaveChangesAsync() > 1)
                return true;

            return false;
        }

        public async Task CreateMovieAsync(Movie movieToCreate)
        {
            _movieContext.Movies.Add(movieToCreate);
            await _movieContext.SaveChangesAsync();
        }

        public async Task DeleteMovieByIdAsync(int id)
        {
            var movieToDelete = await _movieContext.Movies.FirstAsync(m => m.MovieId == id);
            if(movieToDelete != null)
                _movieContext.Movies.Remove(movieToDelete);
            await _movieContext.SaveChangesAsync();
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            var movies = await _movieContext.Movies.ToListAsync();
           
            return movies;
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movie= await _movieContext.Movies.FirstOrDefaultAsync(m => m.MovieId == id);
            return movie;
        }

        public Task<Movie> UpdateMovieByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Actor>> GetMovieActorsAsync(int id)
        {
            var actors= await _movieContext.MoviesActors.Where(m => m.MovieId == id).Select(m => m.Actor).ToListAsync();

            return actors;
        }

        public async Task<List<Writer>> GetMovieWritersAsync(int id)
        {
            var writers= await _movieContext.MoviesWriters.Where(m => m.MovieId == id).Select(m => m.Writer).ToListAsync();

            return writers;
        }

        public async Task<List<Director>> GetMovieDirectorsAsync(int id)
        {
            var directors= await _movieContext.MoviesDrectors.Where(m => m.MovieId == id).Select(m => m.Director).ToListAsync();

            return directors;
        }
    }
}

