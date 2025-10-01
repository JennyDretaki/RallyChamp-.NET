namespace RallyChampAPI.Entities
{
    public class Result
    {
        public int Id { get; set; }
        public int RaceId { get; set; }
        public Race Race { get; set; } = null!;
        public int TeamId { get; set; }
        public Team Team { get; set; } = null!;
        public int Position { get; set; }
        public TimeSpan Time { get; set; }
    }
}