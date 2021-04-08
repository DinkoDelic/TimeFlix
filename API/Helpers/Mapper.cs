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
        private readonly ICrewRepository<Genre> _genreRepo;

        public Mapper(ICrewRepository<Actor> actorRepo, ICrewRepository<Writer> writerRepo, ICrewRepository<Director> directorRepo, ICrewRepository<Genre> genreRepo)
        {
            _genreRepo = genreRepo;
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
                    Plot = m.Plot,
                    AgeRating = m.AgeRating,
                    ReleaseDate = m.ReleaseDate,
                    Duration = m.Duration,
                    // Check to see if the lists are included, if not assign null to property
                    Genres = m.GenresLink != null ? m.GenresLink.Select(a => a.Genre).ToList() : null,
                    Actors = m.ActorsLink != null ? m.ActorsLink.Select(a => a.Actor).ToList() : null,
                    Writers = m.WritersLink != null ? m.WritersLink.Select(w => w.Writer).ToList() : null,
                    Directors = m.DirectorsLink != null ? m.DirectorsLink.Select(d => d.Director).ToList() : null
                });
            }

            return moviesToReturn;
        }

        public async Task<Movie> MapMovieDtoToMovie(MovieDto dto)
        {
            var createdMovie = new Movie
            {
                Title = dto.Title,
                Plot = dto.Plot,
                AgeRating = dto.AgeRating,
                ReleaseDate = dto.ReleaseDate,
                Duration = dto.Duration
            };

            var genreList = new List<MovieGenre>();
            foreach (Genre g in dto.Genres)
            {
                genreList.Add(new MovieGenre
                {
                    Movie = createdMovie,
                    // Look if the genre with the same name is in db, if not create a new genre
                    Genre = await _genreRepo.FindByName(g.Name) ?? new Genre { Name = g.Name.Trim() }
                });
            }
            createdMovie.GenresLink = genreList;

            var writersList = new List<MovieWriter>();
            foreach (Writer w in dto.Writers)
            {
                writersList.Add(new MovieWriter
                {
                    Movie = createdMovie,
                    // Look if the writer with the same name is in db, if not create a new writer
                    Writer = await _writerRepo.FindByName(w.Name) ?? new Writer { Name = w.Name.Trim() }
                });
            }
            createdMovie.WritersLink = writersList;

            var actorList = new List<MovieActor>();
            foreach (Actor a in dto.Actors)
            {
                actorList.Add(new MovieActor
                {
                    Movie = createdMovie,
                    Actor = await _actorRepo.FindByName(a.Name) ?? new Actor { Name = a.Name.Trim() }
                });
            }
            createdMovie.ActorsLink = actorList;

            var directorList = new List<MovieDirector>();
            foreach (Director d in dto.Directors)
            {
                directorList.Add(new MovieDirector
                {
                    Movie = createdMovie,
                    Director = await _directorRepo.FindByName(d.Name) ?? new Director { Name = d.Name.Trim() }
                });
            }
            createdMovie.DirectorsLink = directorList;

            return createdMovie;
        }
    }
}