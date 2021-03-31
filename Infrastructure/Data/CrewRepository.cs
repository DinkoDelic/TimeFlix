using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<List<T>> ListAllAsync()
        {
            return await _movieContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _movieContext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetByNameAsync(string name)
        {
            return await _movieContext.Set<T>().Where(x => x.Name.ToLower().Contains(name.ToLower())).ToListAsync();
        }

    }
}