using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMP.Models
{
    public class Customer
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Range(10, 120)]
        public int Age { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
