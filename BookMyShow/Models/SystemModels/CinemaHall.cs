using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyShow.Models.SystemModels
{
    public class CinemaHall
    {
        [Column("CinemaHallId")]
        [Key]
        public int CinemaHallId { get; set; }
        public string Name { get; set; }
        public int TotalSeats { get; set; }

        [Required]
        [ForeignKey("Cinema")]
        public int CinemaId { get; set; }
        public virtual Cinema Cinema { get; set; }
    }
}
