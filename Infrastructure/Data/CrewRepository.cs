using System.Collections.Generic;
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

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _movieContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _movieContext.Set<T>().FindAsync(id);
        }

    }
}