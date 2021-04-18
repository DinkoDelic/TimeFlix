using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.Errors;
using API.Helpers;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CrewController : ControllerBase
    {
        private readonly ICrewRepository<Director> _directorRepo;
        private readonly ICrewRepository<Actor> _actorRepo;
        private readonly ICrewRepository<Writer> _writerRepo;
        public CrewController(ICrewRepository<Actor> actorRepo, ICrewRepository<Writer> writerRepo, ICrewRepository<Director> directorRepo)
        {
            _writerRepo = writerRepo;
            _actorRepo = actorRepo;
            _directorRepo = directorRepo;
        }

        // Actor requests
        //
        [HttpGet("actor")]
        public async Task<ActionResult<Pagination<Actor>>> GetActors([FromQuery] UserParams userParams)
        {
            var actors = new List<Actor>();
            // Search by name
            if(userParams.nameFilter != null)
            {
                actors = await _actorRepo.ListByNameAsync(userParams);
            }
            // Return all results
            else
            {
                actors = await _actorRepo.ListAllAsync(userParams);
            }

            var totalCount = await _actorRepo.GetTotalCountAsync(userParams);

            if(actors == null)
                return NotFound(new ApiResponse(404));

            return Ok(new Pagination<Actor>(actors, userParams.CurrentPage, totalCount, userParams.Offset));
        }
        [HttpGet("actor/{id}")]
        public async Task<ActionResult<CrewDto>> GetActor(int id)
        {
            var actor = await _actorRepo.GetActorByIdAsync(id);

             if(actor == null)
                return NotFound(new ApiResponse(404));

            var crewToReturn = new CrewDto() {
                Id = actor.Id,
                Name = actor.Name,
                ImageUrl = actor.ImageUrl,
                MovieList = actor.MoviesLink != null ? actor.MoviesLink.Select(m => m.Movie).ToList() : null
            };

            return Ok(crewToReturn);
        }

        
        //Writer requests
        //
        [HttpGet("writer")]
        public async Task<ActionResult<Pagination<Writer>>> GetWriters([FromQuery] UserParams userParams)
        {
           var writers = new List<Writer>();

            // Search by name
            if(userParams.nameFilter != null)
            {
                writers = await _writerRepo.ListByNameAsync(userParams);
            }

            // Return all results
            else
            {
                writers = await _writerRepo.ListAllAsync(userParams);
            }

            var totalCount = await _writerRepo.GetTotalCountAsync(userParams);

            if(writers == null)
                return NotFound(new ApiResponse(404));

            return Ok(new Pagination<Writer>(writers, userParams.CurrentPage, totalCount, userParams.Offset));
        }
        [HttpGet("writer/{id}")]
        public async Task<ActionResult<Writer>> GetWriter(int id)
        {
            var writer = await _writerRepo.GetWriterByIdAsync(id);
            
            if(writer == null)
                return NotFound(new ApiResponse(404));

           
            var crewToReturn = new CrewDto() {
                Id = writer.Id,
                Name = writer.Name,
                ImageUrl = writer.ImageUrl,
                MovieList = writer.MoviesLink != null ? writer.MoviesLink.Select(m => m.Movie).ToList() : null
            };

            return Ok(crewToReturn);
        }

        //Director requests
        //
         [HttpGet("director")]
        public async Task<ActionResult<Pagination<Director>>> GetDirectors([FromQuery]UserParams userParams)
        {
           var directors = new List<Director>();

            // Search by name
            if(userParams.nameFilter != null)
            {
                directors = await _directorRepo.ListByNameAsync(userParams);
            }

            // Return all results
            else
            {
                directors = await _directorRepo.ListAllAsync(userParams);
            }
            
            var totalCount = await _directorRepo.GetTotalCountAsync(userParams);

            if(directors == null)
                return NotFound(new ApiResponse(404));

            return Ok(new Pagination<Director>(directors, userParams.CurrentPage, totalCount, userParams.Offset));
        }
        [HttpGet("director/{id}")]
        public async Task<ActionResult<Director>> GetDirector(int id)
        {
            var director = await _directorRepo.GetDirectorByIdAsync(id);

            if(director == null)
                return NotFound(new ApiResponse(404));

            
            var crewToReturn = new CrewDto() {
                Id = director.Id,
                Name = director.Name,
                ImageUrl = director.ImageUrl,
                MovieList = director.MoviesLink != null ? director.MoviesLink.Select(m => m.Movie).ToList() : null
            };

            return Ok(crewToReturn);
        }
    }
}