using System.ComponentModel.DataAnnotations.Schema;

namespace FMP.Models
{
    public class NewCustomer
    {
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string Email { get; set; } = null!;
        public int PhoneNumber { get; set; }
        public string Password { get; set; } = null!;
        [NotMapped]
        public string Password2 { get; set; }
    }
}
