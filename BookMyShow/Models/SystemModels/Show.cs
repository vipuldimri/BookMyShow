using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyShow.Models.SystemModels
{
    public class Show
    {
        [Column("ShowId")]
        [Key]
        public int ShowId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        [ForeignKey("CinemaHall")]
        public int CinemaHallId { get; set; }
        public virtual CinemaHall CinemaHall { get; set; }

        [Required]
        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
