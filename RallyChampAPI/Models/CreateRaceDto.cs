namespace RallyChampAPI.Models
{
    public class CreateRaceDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Location { get; set; } = string.Empty;
    }
}