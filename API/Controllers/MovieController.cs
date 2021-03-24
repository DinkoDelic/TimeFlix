using System.Collections.Generic;
using System.Linq;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly MovieContext _movieContext;
        public MovieController(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        [HttpGet]
        public ActionResult<List<Movie>> GetMovies()
        {
            var movies= _movieContext.Movies
                .ToList();
            
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovie(int id)
        {
            var movie= _movieContext.Movies.FirstOrDefault(m => m.Id == id);
            return Ok(movie);
        }
    }
}