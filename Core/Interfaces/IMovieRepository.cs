using System.Collections.Generic;
using System.Threading.Tasks;

using Core.Entities;

namespace Core.Interfaces
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllMoviesAsync();
        Task<Movie> GetMovieByIdAsync(int id);
        Task DeleteMovieByIdAsync(int id);
        Task CreateMovieAsync(Movie m);
        Task<Movie> UpdateMovieByIdAsync(int id);

        Task<List<string>> GetMovieActorsAsync(int id);
        Task<List<string>> GetMovieWritersAsync(int id);
        Task<List<string>> GetMovieDirectorsAsync(int id);
    }
}