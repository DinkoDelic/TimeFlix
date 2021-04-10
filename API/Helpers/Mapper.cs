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
                    // Check to see if the lists are included, if not assign null
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
                MovieId = dto.MovieId,
                Title = dto.Title,
                Plot = dto.Plot,
                AgeRating = dto.AgeRating,
                ReleaseDate = dto.ReleaseDate,
                Duration = dto.Duration
            };

            var genreList = new List<MovieGenre>();
            foreach (Genre g in dto.Genres)
            {
                var genreToAdd = await _genreRepo.FindByNameAsync(g.Name);

                genreList.Add(new MovieGenre
                {
                    Movie = createdMovie,
                    // Look if the genre with the same name is in db, if not create a new genre
                    Genre = genreToAdd != null ? genreToAdd : new Genre { Name = g.Name.Trim() }
                });
            }
            createdMovie.GenresLink = genreList;

            var writersList = new List<MovieWriter>();
            foreach (Writer w in dto.Writers)
            {
                var writerToAdd = await _writerRepo.FindByNameAsync(w.Name);

                writersList.Add(new MovieWriter
                {
                    Movie = createdMovie,
                    // Look if the writer with the same name is in db, if not create a new writer
                    Writer = writerToAdd ?? new Writer { Name = w.Name.Trim(), ImageUrl = w.ImageUrl }
                });
            }
            createdMovie.WritersLink = writersList;

            var actorList = new List<MovieActor>();
            foreach (Actor a in dto.Actors)
            {
                var actorToAdd = await _actorRepo.FindByNameAsync(a.Name);
                actorList.Add(new MovieActor
                {
                    Movie = createdMovie,
                    Actor = actorToAdd ?? new Actor { Name = a.Name.Trim(), ImageUrl = a.ImageUrl }
                });
            }
            createdMovie.ActorsLink = actorList;

            var directorList = new List<MovieDirector>();
            foreach (Director d in dto.Directors)
            {
                var directorToAdd = await _directorRepo.FindByNameAsync(d.Name);
                directorList.Add(new MovieDirector
                {
                    Movie = createdMovie,
                    Director = directorToAdd ?? new Director { Name = d.Name.Trim(), ImageUrl = d.ImageUrl }
                });
            }
            createdMovie.DirectorsLink = directorList;

            return createdMovie;
        }

        public async Task<Movie> UpdateMovie(MovieDto dto, Movie movieToUpdate)
        {

            var genreList = new List<MovieGenre>();
            foreach (Genre g in dto.Genres)
            {
                var genreToAdd = await _genreRepo.FindByNameAsync(g.Name);

                genreList.Add(new MovieGenre
                {
                    Movie = movieToUpdate,
                    // Look if the genre with the same name is in db, if not create a new genre
                    Genre = genreToAdd != null ? genreToAdd : new Genre { Name = g.Name.Trim() }
                });
            }
            movieToUpdate.GenresLink = genreList;

            var writersList = new List<MovieWriter>();
            foreach (Writer w in dto.Writers)
            {
                var writerToAdd = await _writerRepo.FindByNameAsync(w.Name);

                writersList.Add(new MovieWriter
                {
                    Movie = movieToUpdate,
                    // Look if the writer with the same name is in db, if not create a new writer
                    Writer = writerToAdd ?? new Writer { Name = w.Name.Trim(), ImageUrl = w.ImageUrl }
                });
            }
            movieToUpdate.WritersLink = writersList;

            var actorList = new List<MovieActor>();
            foreach (Actor a in dto.Actors)
            {
                var actorToAdd = await _actorRepo.FindByNameAsync(a.Name);
                actorList.Add(new MovieActor
                {
                    Movie = movieToUpdate,
                    Actor = actorToAdd ?? new Actor { Name = a.Name.Trim(), ImageUrl = a.ImageUrl }
                });
            }
            movieToUpdate.ActorsLink = actorList;

            var directorList = new List<MovieDirector>();
            foreach (Director d in dto.Directors)
            {
                var directorToAdd = await _directorRepo.FindByNameAsync(d.Name);
                directorList.Add(new MovieDirector
                {
                    Movie = movieToUpdate,
                    Director = directorToAdd ?? new Director { Name = d.Name.Trim(), ImageUrl = d.ImageUrl }
                });
            }
            movieToUpdate.DirectorsLink = directorList;

            return movieToUpdate;
        }
    }
}