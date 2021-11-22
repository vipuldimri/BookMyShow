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
                var cinemaHallDb = show.CinemaHall;
                var cinemaDb = show.CinemaHall.Cinema;

                if (cinemaDic.ContainsKey(cinemaDb.CinemaId))
                {
                    var cinema = cinemaDic[cinemaDb.CinemaId];
                    CinemaHallOutPutDTO cinemaHall = null;
                    if (cinema.CinemaHalls.Any(x => x.CinemaHallId == show.CinemaHallId))
                    {
                        cinemaHall = cinema.CinemaHalls.SingleOrDefault(x => x.CinemaHallId == show.CinemaHallId);
                    }
                    else
                    {
                        cinemaHall = new CinemaHallOutPutDTO()
                        {
                            CinemaHallId = show.CinemaHallId,
                            Name = show.CinemaHall.Name
                        };
                    }


                    var showOutput = new ShowOutPutDTO()
                    {
                        Date = show.Date,
                        StartTime = show.StartTime,
                        EndTime = show.EndTime
                    };

                    cinemaHall.Shows.Add(showOutput);
                }
                else
                {
                    var cinema = new CinemaOutPutDTO()
                    {
                        CinemaId = cinemaDb.CinemaId,
                        Name = cinemaDb.Name
                    };

                    var cinemaHall = new CinemaHallOutPutDTO()
                    {
                        CinemaHallId = show.CinemaHallId,
                        Name = show.CinemaHall.Name
                    };

                    var showOutput = new ShowOutPutDTO()
                    {
                        Date = show.Date,
                        StartTime = show.StartTime,
                        EndTime = show.EndTime
                    };

                    cinemaHall.Shows.Add(showOutput);
                    cinema.CinemaHalls.Add(cinemaHall);
                    cinemaDic.Add(cinemaDb.CinemaId, cinema);
                }
            }



            return cinemaDic.Select(x => x.Value).ToList();
        }
    }
}
