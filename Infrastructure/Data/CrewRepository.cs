using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class CrewRepository<T> : ICrewRepository<T> where T : Crew
    {
        private readonly MovieContext _movieContext;
        public CrewRepository(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task<List<T>> ListAllAsync(UserParams userParams)
        {
            return await _movieContext.Set<T>()
                .OrderBy(x => x.Name)
                .Skip((userParams.CurrentPage - 1) * userParams.Offset)
                .Take(userParams.Offset)
                .ToListAsync();
        }


        public async Task<List<T>> ListByNameAsync(string name)
        {
            return await _movieContext.Set<T>().Where(x => x.Name.ToLower().Contains(name.ToLower())).ToListAsync();
        }

        public async Task<T> FindByNameAsync(string name)
        {
            var objectToReturn = await _movieContext.Set<T>().Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefaultAsync();

            if (objectToReturn != null)
                return objectToReturn;

            return null;
        }

        public async Task<int> GetTotalCountAsync(UserParams userParams)
        {
            if (userParams.nameFilter != null)
                return await _movieContext.Set<T>()
                    .Where(m => m.Name.ToLower().Contains(userParams.nameFilter.ToLower()))
                    .CountAsync();
            else
                return await _movieContext.Set<T>().CountAsync();
        }

        public async Task<Actor> GetActorByIdAsync(int id)
        {
            return await _movieContext.Set<Actor>()
                .Include(a => a.MoviesLink)
                .ThenInclude(a => a.Movie)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Writer> GetWriterByIdAsync(int id)
        {
            return await _movieContext.Set<Writer>().Include(a => a.MoviesLink).ThenInclude(a => a.Movie).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Director> GetDirectorByIdAsync(int id)
        {
            return await _movieContext.Set<Director>().Include(a => a.MoviesLink).ThenInclude(a => a.Movie).FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}