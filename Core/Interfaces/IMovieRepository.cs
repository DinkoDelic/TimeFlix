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

        Task<bool> SaveChangesAsync();

        Task<List<Actor>> GetMovieActorsAsync(int id);
        Task<List<Writer>> GetMovieWritersAsync(int id);
        Task<List<Director>> GetMovieDirectorsAsync(int id);
    }
}