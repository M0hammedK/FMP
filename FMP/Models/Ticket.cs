using System;
using System.Collections.Generic;

namespace FMP.Models
{
    public partial class Ticket
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public DateTime Date { get; set; }
        public int MovieId { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Movie Movie { get; set; } = null!;
    }
}
