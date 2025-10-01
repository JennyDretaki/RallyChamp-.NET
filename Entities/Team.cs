namespace RallyChampAPI.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Sponsor { get; set; } = string.Empty;
        public List<Result> Results { get; set; } = new List<Result>();
    }
}