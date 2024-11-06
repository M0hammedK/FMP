using System;
using System.Collections.Generic;

namespace FMP.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime Date { get; set; }
        public int Price { get; set; }
        public string? MovieDuration { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
