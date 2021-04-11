using System.Collections.Generic;
using System.Threading.Tasks;
using API.Helpers;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ICrewRepository<T> where T:Crew
    {
        Task<List<T>> ListAllAsync(UserParams userParams);
        Task<List<T>> ListByNameAsync(string name);
        Task<T> FindByNameAsync(string name);
        Task<int> GetTotalCountAsync(UserParams userParams);
        Task<Actor> GetActorByIdAsync(int id);
        Task<Writer> GetWriterByIdAsync(int id);
        Task<Director> GetDirectorByIdAsync(int id);
    }
}