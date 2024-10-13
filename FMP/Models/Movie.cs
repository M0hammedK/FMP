using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMP.Models
{
    public class Movie
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Price { get; set; }
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss}")]
        public string? Movie_Duration { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Ticket> Tickets { get;}
    }
}
