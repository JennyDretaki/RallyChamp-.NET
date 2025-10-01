namespace RallyChampAPI.Entities
{
    public class Race
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Location { get; set; } = string.Empty;
        public List<Result> Results { get; set; } = new List<Result>();
    }
}