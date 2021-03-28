using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<ActionResult<IReadOnlyList<Actor>>> GetActors()
        {
            var actors = await _actorRepo.ListAllAsync();

            return Ok(actors);
        }
        [HttpGet("actor/{id}")]
        public async Task<ActionResult<Actor>> GetActor(int id)
        {
            var actor = await _actorRepo.GetByIdAsync(id);

            return Ok(actor);
        }

        
        //Writer requests
        //
        [HttpGet("writer")]
        public async Task<ActionResult<IReadOnlyList<Writer>>> GetWriters()
        {
            var writers = await _writerRepo.ListAllAsync();

            return Ok(writers);
        }
        [HttpGet("writer/{id}")]
        public async Task<ActionResult<Writer>> GetWriter(int id)
        {
            var writer = await _writerRepo.GetByIdAsync(id);

            return Ok(writer);
        }

        //Director requests
        //
         [HttpGet("director")]
        public async Task<ActionResult<IReadOnlyList<Director>>> GetDirectors()
        {
            var directors = await _directorRepo.ListAllAsync();

            return Ok(directors);
        }
        [HttpGet("director/{id}")]
        public async Task<ActionResult<Director>> GetDirector(int id)
        {
            var director = await _directorRepo.GetByIdAsync(id);

            return Ok(director);
        }
    }
}