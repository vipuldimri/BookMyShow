using BookMyShow.Database.ApplicationDbContext;
using BookMyShow.Interfaces;
using BookMyShow.Models.DTOModels;
using BookMyShow.Models.SystemModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections.Generic;
using System.Linq;

namespace BookMyShow.Implementations
{
    public class SearchMovies : ISearchMovies
    {
        private readonly ApplicationContext _applicationContext;
        private readonly ILoggerManager _logger;
        public SearchMovies(ApplicationContext applicationContext, ILoggerManager logger)
        {
            _applicationContext = applicationContext;
            _logger = logger;
        }

        public List<Movie> GetMoviesByCity(int cityId)
        {
            return _applicationContext.Show
                              .Where(x => x.CinemaHall.Cinema.CityId == cityId)
                              .Select(x => x.Movie).Distinct().ToList();
        }

        public List<CinemaOutPutDTO> GetCinemaByMovie(int movieId)
        {
            var shows = _applicationContext.Show.Where(x => x.MovieId == movieId )
                                                .Include(x => x.CinemaHall)
                                                .ThenInclude(x => x.Cinema);
            return GetCinemaHallOutPut(shows);
        }

        private List<CinemaOutPutDTO> GetCinemaHallOutPut(IIncludableQueryable<Show , Cinema> shows)
        {
            Dictionary<int, CinemaOutPutDTO> cinemaDic = new Dictionary<int, CinemaOutPutDTO>();
            foreach (var show in shows)
            {
                var cinemaHall = show.CinemaHall;
                var cinema = show.CinemaHall.Cinema;

                if (cinemaDic.ContainsKey(cinema.CinemaId))
                {
                    var c = cinemaDic[cinema.CinemaId];
                    CinemaHallOutPutDTO h = null;
                    if (c.CinemaHalls.Any(x => x.CinemaHallId == show.CinemaHallId))
                    {
                        h = c.CinemaHalls.SingleOrDefault(x => x.CinemaHallId == show.CinemaHallId);
                    }
                    else
                    {
                        h = new CinemaHallOutPutDTO()
                        {
                            CinemaHallId = show.CinemaHallId,
                            Name = show.CinemaHall.Name
                        };
                    }


                    var s = new ShowOutPutDTO()
                    {
                        Date = show.Date,
                        StartTime = show.StartTime,
                        EndTime = show.EndTime
                    };

                    h.Shows.Add(s);
                }
                else
                {
                    var c = new CinemaOutPutDTO()
                    {
                        CinemaId = cinema.CinemaId,
                        Name = cinema.Name
                    };

                    var h = new CinemaHallOutPutDTO()
                    {
                        CinemaHallId = show.CinemaHallId,
                        Name = show.CinemaHall.Name
                    };

                    var s = new ShowOutPutDTO()
                    {
                        Date = show.Date,
                        StartTime = show.StartTime,
                        EndTime = show.EndTime
                    };

                    h.Shows.Add(s);
                    c.CinemaHalls.Add(h);
                    cinemaDic.Add(cinema.CinemaId, c);
                }
            }



            return cinemaDic.Select(x => x.Value).ToList();
        }
    }
}
