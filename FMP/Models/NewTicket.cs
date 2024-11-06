namespace FMP.Models
{
    public class NewTicket
    {
        public int Price { get; set; }
        public DateTime Date { get; set; }
        public int MovieId { get; set; }
        public int CustomerId { get; set; }
    }
}
