using Microsoft.AspNetCore.Mvc;
using RallyChampAPI.DataStores;
using RallyChampAPI.Models;
using AutoMapper;

namespace RallyChampAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        private readonly IMapper _mapper;

        public ResultsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET: api/results
        [HttpGet]
        public ActionResult<IEnumerable<ResultDto>> GetResults()
        {
            return Ok(RallyChampDataStore.Current.Results);
        }

        // GET: api/results/5
        [HttpGet("{id}")]
        public ActionResult<ResultDto> GetResult(int id)
        {
            var result = RallyChampDataStore.Current.Results.FirstOrDefault(r => r.Id == id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST: api/results
        [HttpPost]
        public ActionResult<ResultDto> CreateResult(CreateResultDto resultDto)
        {
            var maxId = RallyChampDataStore.Current.Results.Max(r => r.Id);
            var newResult = new ResultDto
            {
                Id = maxId + 1,
                RaceId = resultDto.RaceId,
                TeamId = resultDto.TeamId,
                Position = resultDto.Position,
                Time = resultDto.Time
            };
            RallyChampDataStore.Current.Results.Add(newResult);
            return CreatedAtAction(nameof(GetResult), new { id = newResult.Id }, newResult);
        }

        // PUT: api/results/5
        [HttpPut("{id}")]
        public IActionResult UpdateResult(int id, CreateResultDto resultDto)
        {
            var result = RallyChampDataStore.Current.Results.FirstOrDefault(r => r.Id == id);
            if (result == null) return NotFound();
            result.RaceId = resultDto.RaceId;
            result.TeamId = resultDto.TeamId;
            result.Position = resultDto.Position;
            result.Time = resultDto.Time;
            return NoContent();
        }

        // DELETE: api/results/5
        [HttpDelete("{id}")]
        public IActionResult DeleteResult(int id)
        {
            var result = RallyChampDataStore.Current.Results.FirstOrDefault(r => r.Id == id);
            if (result == null) return NotFound();
            RallyChampDataStore.Current.Results.Remove(result);
            return NoContent();
        }
    }
}