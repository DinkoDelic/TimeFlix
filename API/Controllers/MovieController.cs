using System.Collections.Generic;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Core.Interfaces;
using API.DTO;
using API.Errors;
using API.Helpers;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepo;
        private readonly ICrewRepository<Actor> _actorRepo;
        private readonly ICrewRepository<Writer> _writerRepo;
        private readonly ICrewRepository<Director> _directorRepo;
        private readonly Mapper _mapper;

        public MovieController(IMovieRepository movieRepo, ICrewRepository<Actor> actorRepo, ICrewRepository<Writer> writerRepo, ICrewRepository<Director> directorRepo,
        Mapper mapper)
        {
            _mapper = mapper;
            _directorRepo = directorRepo;
            _writerRepo = writerRepo;
            _actorRepo = actorRepo;
            _movieRepo = movieRepo;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<MovieDto>>> GetMovies([FromQuery]UserParams userParams)
        {
            var movies = await _movieRepo.GetAllMoviesAsync(userParams);

             if (movies == null)
                return NotFound(new ApiResponse(404));
           
            return Ok(movies);
        }

        [HttpGet("{id}", Name = "GetMovie")]
        public async Task<ActionResult<MovieDto>> GetMovie(int id)
        {
            var movie = await _movieRepo.GetMovieByIdAsync(id);

            if (movie == null)
                return NotFound(new ApiResponse(404));

            return Ok(movie);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie(MovieDto movieToCreate)
        {
            var createdMovie = await _mapper.MapMovieDtoToMovie(movieToCreate);
           
            _movieRepo.Add(createdMovie);

            var movieToReturn = _mapper.MapMovieToMovieDtoList(new List<Movie>() {createdMovie});

            if (await _movieRepo.SaveChangesAsync())
                return CreatedAtRoute("GetMovie", new { controller = "Movie", id = createdMovie.MovieId }, movieToReturn);

            return BadRequest("Failed to create movie");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movieToDelete = await _movieRepo.GetMovieByIdAsync(id);
            if (movieToDelete == null)
                return BadRequest(new ApiResponse(404));

            _movieRepo.Remove(movieToDelete);

            if (await _movieRepo.SaveChangesAsync())
                return NoContent();

            return BadRequest("Failed to delete a movie");
        }
    }


}