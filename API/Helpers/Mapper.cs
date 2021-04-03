using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using Core.Entities;
using Core.Interfaces;

namespace API.Helpers
{

    public class Mapper
    {
        private readonly ICrewRepository<Actor> _actorRepo;
        private readonly ICrewRepository<Writer> _writerRepo;
        private readonly ICrewRepository<Director> _directorRepo;
        public Mapper(ICrewRepository<Actor> actorRepo, ICrewRepository<Writer> writerRepo, ICrewRepository<Director> directorRepo)
        {
            _directorRepo = directorRepo;
            _writerRepo = writerRepo;
            _actorRepo = actorRepo;
        }

        public List<MovieDto> MapMovieToMovieDtoList(List<Movie> movies)
        {
            var moviesToReturn = new List<MovieDto>();
            
            foreach (Movie m in movies)
            {
                moviesToReturn.Add(new MovieDto
                {
                    MovieId = m.MovieId,
                    Title = m.Title,
                    Genre = m.Genre,
                    Storyline = m.Storyline,
                    AgeRating = m.AgeRating,
                    ReleaseDate = m.ReleaseDate,
                    Duration = m.Duration,
                    Actors = m.ActorsLink.Select(a => a.Actor).ToList(),
                    Writers = m.WritersLink.Select(w => w.Writer).ToList(),
                    Directors = m.DirectorsLink.Select(d => d.Director).ToList()
                });
            }
           
            return moviesToReturn;
        }

        public async Task<Movie> MapMovieDtoToMovie(MovieDto dto)
        {
            var createdMovie = new Movie
            {
                Title = dto.Title,
                Genre = dto.Genre,
                Storyline = dto.Storyline,
                AgeRating = dto.AgeRating,
                ReleaseDate = dto.ReleaseDate,
                Duration = dto.Duration
            };

            var writersList = new List<MovieWriter>();
            foreach (Writer w in dto.Writers)
            {
                 writersList.Add(new MovieWriter
                {
                    Movie = createdMovie,
                    Writer = await _writerRepo.GetByIdAsync(w.Id) ?? new Writer { Name = w.Name.Trim() }
                });
            }
            createdMovie.WritersLink = writersList;

            var actorList = new List<MovieActor>();
            foreach (Actor a in dto.Actors)
            {
                 actorList.Add(new MovieActor
                {
                    Movie = createdMovie,
                    Actor = await _actorRepo.GetByIdAsync(a.Id) ?? new Actor { Name = a.Name.Trim() }
                });
            }
            createdMovie.ActorsLink = actorList;

            var directorList = new List<MovieDirector>();
            foreach (Director d in dto.Directors)
            {
                directorList.Add(new MovieDirector
                {
                    Movie = createdMovie,
                    Director = await _directorRepo.GetByIdAsync(d.Id) ?? new Director { Name = d.Name.Trim() }
                });
            }
            createdMovie.DirectorsLink = directorList;

            return createdMovie;
        }
    }
}