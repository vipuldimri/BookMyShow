using System.Collections.Generic;
using System;
namespace BookMyShow.Models.DTOModels
{
    public class CinemaOutPutDTO
    {
        public int CinemaId { get; set; }
        public string Name { get; set; }
        public List<CinemaHallOutPutDTO> CinemaHalls { get; set; }

        public CinemaOutPutDTO()
        {
            CinemaHalls = new List<CinemaHallOutPutDTO>();
        }
    }

    public class CinemaHallOutPutDTO
    {
        public int CinemaHallId { get; set; }
        public string Name { get; set; }
        public List<ShowOutPutDTO> Shows { get; set; }

        public CinemaHallOutPutDTO()
        {
            Shows = new List<ShowOutPutDTO>();
        }

    }

    public class ShowOutPutDTO 
    {
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }
}
