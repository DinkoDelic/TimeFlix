using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Helpers;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IMovieRepository
    {
        void Add<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
        Task<List<Movie>> GetAllMoviesAsync(UserParams userParams);
        Task<Movie> GetMovieByIdAsync(int id);
        Task<List<Movie>> SearchMoviesByNameAsync(UserParams userParams);
        Task<int> GetTotalMovieCount(UserParams userParams);
    }
}