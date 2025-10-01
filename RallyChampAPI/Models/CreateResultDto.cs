namespace RallyChampAPI.Models
{
    public class CreateResultDto
    {
        public int RaceId { get; set; }
        public int TeamId { get; set; }
        public int Position { get; set; }
        public TimeSpan Time { get; set; }
    }
}