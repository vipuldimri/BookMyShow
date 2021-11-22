
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyShow.Models.SystemModels
{
    public class Cinema
    {
        [Column("CinemaId")]
        [Key]
        public int CinemaId { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        [ForeignKey("City")]
        public int CityId { get; set; }
        public virtual City City { get; set; }
    }
}
