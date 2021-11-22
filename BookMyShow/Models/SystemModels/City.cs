using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyShow.Models.SystemModels
{
    public class City
    {
        [Column("CityId")]
        [Key]
        public int CityId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
