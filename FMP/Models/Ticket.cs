using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMP.Models
{
    public class Ticket
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        [ForeignKey("Movie")]
        public int Movie_Id { get; set; }
        public virtual Movie Movie { get; set; }
        [Required]
        [ForeignKey("Customer")]
        public int Customer_Id { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
