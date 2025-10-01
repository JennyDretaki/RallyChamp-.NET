using Microsoft.AspNetCore.Mvc;
using RallyChampAPI.DataStores;
using RallyChampAPI.Models;
using AutoMapper;

namespace RallyChampAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IMapper _mapper;

        public TeamsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET: api/teams
        [HttpGet]
        public ActionResult<IEnumerable<TeamDto>> GetTeams()
        {
            return Ok(RallyChampDataStore.Current.Teams);
        }

        // GET: api/teams/5
        [HttpGet("{id}")]
        public ActionResult<TeamDto> GetTeam(int id)
        {
            var team = RallyChampDataStore.Current.Teams.FirstOrDefault(t => t.Id == id);
            if (team == null) return NotFound();
            return Ok(team);
        }

        // POST: api/teams
        [HttpPost]
        public ActionResult<TeamDto> CreateTeam(CreateTeamDto teamDto)
        {
            var maxId = RallyChampDataStore.Current.Teams.Max(t => t.Id);
            var newTeam = new TeamDto
            {
                Id = maxId + 1,
                Name = teamDto.Name,
                Sponsor = teamDto.Sponsor
            };
            RallyChampDataStore.Current.Teams.Add(newTeam);
            return CreatedAtAction(nameof(GetTeam), new { id = newTeam.Id }, newTeam);
        }

        // PUT: api/teams/5
        [HttpPut("{id}")]
        public IActionResult UpdateTeam(int id, CreateTeamDto teamDto)
        {
            var team = RallyChampDataStore.Current.Teams.FirstOrDefault(t => t.Id == id);
            if (team == null) return NotFound();
            team.Name = teamDto.Name;
            team.Sponsor = teamDto.Sponsor;
            return NoContent();
        }

        // DELETE: api/teams/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTeam(int id)
        {
            var team = RallyChampDataStore.Current.Teams.FirstOrDefault(t => t.Id == id);
            if (team == null) return NotFound();
            RallyChampDataStore.Current.Teams.Remove(team);
            return NoContent();
        }
    }
}