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
        private readonly Mapper _mapper;

        public MovieController(IMovieRepository movieRepo, Mapper mapper)
        {
            _mapper = mapper;
            _movieRepo = movieRepo;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<MovieDto>>> GetMovies([FromQuery] UserParams userParams)
        {
            var movies = new List<Movie>();

            // returns search results
            if (userParams.nameFilter != null)
            {
                movies = await _movieRepo.SearchMoviesByNameAsync(userParams);
                
            }
            //returns full movie collection
            else
            {
                movies = await _movieRepo.GetAllMoviesAsync(userParams);   
            }

            int movieCount = await _movieRepo.GetTotalMovieCount(userParams);

            if (movies == null)
                return NotFound(new ApiResponse(404));

            var moviesToReturn = _mapper.MapMovieToMovieDtoList(movies);



            return Ok(new Pagination<MovieDto>(moviesToReturn, userParams.CurrentPage, movieCount, userParams.Offset));
        }

        [HttpGet("{id}", Name = "GetMovie")]
        public async Task<ActionResult<MovieDto>> GetMovie(int id)
        {
            var movie = await _movieRepo.GetMovieByIdAsync(id);

            if (movie == null)
                return NotFound(new ApiResponse(404));

            // Because the mapper method takes in and returns list we have grab first item
            var movieToReturn = _mapper.MapMovieToMovieDtoList(new List<Movie> { movie }).First();

            return Ok(movieToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie(MovieDto movieToCreate)
        {
            var createdMovie = await _mapper.MapMovieDtoToMovie(movieToCreate);

            _movieRepo.Add(createdMovie);

            movieToCreate.MovieId = createdMovie.MovieId;

            if (await _movieRepo.SaveChangesAsync())
                return CreatedAtRoute("GetMovie", new { controller = "Movie", id = createdMovie.MovieId }, movieToCreate);

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

        [HttpPut]
        public async Task<IActionResult> UpdateMovie(MovieDto movieDto)
        {
            var movieToUpdate = await _movieRepo.GetMovieByIdAsync(movieDto.MovieId);

            if(movieToUpdate == null)
                return BadRequest(new ApiResponse(404));


            _movieRepo.Update(await _mapper.UpdateMovie(movieDto, movieToUpdate));

            if(await _movieRepo.SaveChangesAsync()) 
                return NoContent();
            
            return BadRequest("Failed to update movie");
        }

    }


}