using RallyChampAPI.Models;

namespace RallyChampAPI.DataStores
{
    public class RallyChampDataStore
    {
        public List<TeamDto> Teams { get; set; }
        public List<RaceDto> Races { get; set; }
        public List<ResultDto> Results { get; set; }

        public static RallyChampDataStore Current { get; } = new RallyChampDataStore();

        private RallyChampDataStore()
        {
            // Teams
            Teams = new List<TeamDto>
            {
                new TeamDto { Id = 1, Name = "Nordic Thunder", Sponsor = "Arctic Energy" },
                new TeamDto { Id = 2, Name = "Desert Blaze", Sponsor = "SunTech" },
                new TeamDto { Id = 3, Name = "Rainstorm Racers", Sponsor = "HydroFuel" }
            };

            // Races
            Races = new List<RaceDto>
            {
                new RaceDto { Id = 1, Name = "Rally Finland", Date = new DateTime(2025, 07, 15), Location = "Jyväskylä" },
                new RaceDto { Id = 2, Name = "Rally Spain", Date = new DateTime(2025, 08, 20), Location = "Salou" },
                new RaceDto { Id = 3, Name = "Rally Portugal", Date = new DateTime(2025, 09, 10), Location = "Porto" }
            };

            // Results
            Results = new List<ResultDto>
            {
                new ResultDto { Id = 1, RaceId = 1, TeamId = 1, Position = 1, Time = new TimeSpan(1, 58, 32) },
                new ResultDto { Id = 2, RaceId = 1, TeamId = 2, Position = 2, Time = new TimeSpan(2, 0, 15) },
                new ResultDto { Id = 3, RaceId = 2, TeamId = 2, Position = 1, Time = new TimeSpan(1, 54, 42) },
                new ResultDto { Id = 4, RaceId = 2, TeamId = 3, Position = 2, Time = new TimeSpan(1, 59, 10) },
                new ResultDto { Id = 5, RaceId = 3, TeamId = 3, Position = 1, Time = new TimeSpan(2, 1, 10) }
            };
        }
    }
}