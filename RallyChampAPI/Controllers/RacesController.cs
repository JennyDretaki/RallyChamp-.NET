using Microsoft.AspNetCore.Mvc;
using RallyChampAPI.DataStores;
using RallyChampAPI.Models;
using AutoMapper;

namespace RallyChampAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacesController : ControllerBase
    {
        private readonly IMapper _mapper;

        public RacesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET: api/races
        [HttpGet]
        public ActionResult<IEnumerable<RaceDto>> GetRaces()
        {
            return Ok(RallyChampDataStore.Current.Races);
        }

        // GET: api/races/5
        [HttpGet("{id}")]
        public ActionResult<RaceDto> GetRace(int id)
        {
            var race = RallyChampDataStore.Current.Races.FirstOrDefault(r => r.Id == id);
            if (race == null) return NotFound();
            return Ok(race);
        }

        // POST: api/races
        [HttpPost]
        public ActionResult<RaceDto> CreateRace(CreateRaceDto raceDto)
        {
            var maxId = RallyChampDataStore.Current.Races.Max(r => r.Id);
            var newRace = new RaceDto
            {
                Id = maxId + 1,
                Name = raceDto.Name,
                Date = raceDto.Date,
                Location = raceDto.Location
            };
            RallyChampDataStore.Current.Races.Add(newRace);
            return CreatedAtAction(nameof(GetRace), new { id = newRace.Id }, newRace);
        }

        // PUT: api/races/5
        [HttpPut("{id}")]
        public IActionResult UpdateRace(int id, CreateRaceDto raceDto)
        {
            var race = RallyChampDataStore.Current.Races.FirstOrDefault(r => r.Id == id);
            if (race == null) return NotFound();
            race.Name = raceDto.Name;
            race.Date = raceDto.Date;
            race.Location = raceDto.Location;
            return NoContent();
        }

        // DELETE: api/races/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRace(int id)
        {
            var race = RallyChampDataStore.Current.Races.FirstOrDefault(r => r.Id == id);
            if (race == null) return NotFound();
            RallyChampDataStore.Current.Races.Remove(race);
            return NoContent();
        }
    }
}