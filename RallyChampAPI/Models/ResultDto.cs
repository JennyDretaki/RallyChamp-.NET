namespace RallyChampAPI.Models
{
    public class ResultDto
    {
        public int Id { get; set; }
        public int RaceId { get; set; }
        public int TeamId { get; set; }
        public int Position { get; set; }
        public TimeSpan Time { get; set; }
    }
}