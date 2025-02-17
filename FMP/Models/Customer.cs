﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMP.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string Email { get; set; } = null!;
        public int PhoneNumber { get; set; }
        public string Password { get; set; } = null!;
        [NotMapped]
        public string Password2 { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
