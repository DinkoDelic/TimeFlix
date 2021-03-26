using System.Collections.Generic;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Core.Interfaces;
using API.DTO;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepo;

        public MovieController(IMovieRepository movieRepo)
        {
            _movieRepo = movieRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<MovieToReturnDto>>> GetMovies()
        {
            var movies = await _movieRepo.GetAllMoviesAsync();

            var moviesToReturn = new List<MovieToReturnDto>();

            foreach (Movie m in movies)
            {
                moviesToReturn.Add(new MovieToReturnDto
                {
                    MovieId = m.MovieId,
                    Title = m.Title,
                    Genre = m.Genre,
                    Storyline = m.Storyline,
                    AgeRating = m.AgeRating,
                    ReleaseDate = m.ReleaseDate,
                    Duration = m.Duration,
                    Actors = await _movieRepo.GetMovieActorsAsync(m.MovieId),
                    Writers = await _movieRepo.GetMovieWritersAsync(m.MovieId),
                    Directors = await _movieRepo.GetMovieDirectorsAsync(m.MovieId),
                });
            }

            return Ok(moviesToReturn);
        }

        [HttpGet("{id}", Name = "GetMovie")]
        public async Task<ActionResult<MovieToReturnDto>> GetMovie(int id)
        {
            var movie = await _movieRepo.GetMovieByIdAsync(id);

            if(movie == null)
                return NoContent();

            var movieToReturn = new MovieToReturnDto()
            {
                MovieId = movie.MovieId,
                Title = movie.Title,
                Genre = movie.Genre,
                Storyline = movie.Storyline,
                AgeRating = movie.AgeRating,
                ReleaseDate = movie.ReleaseDate,
                Duration = movie.Duration,
                Actors = await _movieRepo.GetMovieActorsAsync(movie.MovieId),
                Writers = await _movieRepo.GetMovieWritersAsync(movie.MovieId),
                Directors = await _movieRepo.GetMovieDirectorsAsync(movie.MovieId),
            };

            return Ok(movieToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie(MovieToReturnDto movieToCreate)
        {
            var createdMovie = new Movie()
            {
                Title = movieToCreate.Title,
                Genre = movieToCreate.Genre,
                Storyline = movieToCreate.Storyline,
                AgeRating = movieToCreate.AgeRating,
                ReleaseDate = movieToCreate.ReleaseDate,
                Duration = movieToCreate.Duration
            };
            
            var writersList = new List<MovieWriter>();
            foreach (string name in movieToCreate.Writers)
            {
                writersList.Add(new MovieWriter()
                {
                    Movie = createdMovie,
                    Writer = new Writer()
                    {
                        Name = name
                    }
                });
            }
            createdMovie.WritersLink = writersList;

            var actorsList = new List<MovieActor>();
            foreach (string name in movieToCreate.Actors)
            {
                actorsList.Add(new MovieActor()
                {
                    Movie = createdMovie,
                    Actor = new Actor()
                    {
                        Name = name
                    }
                });
            }
            createdMovie.ActorsLink = actorsList;

            var directorsLink = new List<MovieDirector>();
            foreach (string name in movieToCreate.Directors)
            {
                directorsLink.Add(new MovieDirector()
                {
                    Movie = createdMovie,
                    Director = new Director()
                    {
                        Name = name
                    }
                });
            }
            createdMovie.DirectorsLink = directorsLink;

            await _movieRepo.CreateMovieAsync(createdMovie);

            movieToCreate.MovieId = createdMovie.MovieId;

            return CreatedAtRoute("GetMovie", new { controller = "Movie", id = createdMovie.MovieId }, movieToCreate);
        }
    }
}