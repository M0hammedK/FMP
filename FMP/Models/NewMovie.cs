namespace FMP.Models
{
    public class NewMovie
    {
        public string Title { get; set; } = null!;
        public DateTime Date { get; set; }
        public int Price { get; set; }
        public string? MovieDuration { get; set; }
        public string? Description { get; set; }
    }
}
