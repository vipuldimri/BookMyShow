using BookMyShow.Database.ApplicationDbContext;
using BookMyShow.Models.SystemModels;
using System;

using System.Linq;
namespace BookMyShow.Database
{  
    /// <summary>
   /// Dummy data populate
   /// </summary>
    public class Database
    {
        private readonly ApplicationContext _applicationDbContext;
        public Database(ApplicationContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void FillDemoData()
        {
            
            if (_applicationDbContext.Cinema.Any())
            {
                return;
            }

            addMovie("Movie 1 Title", "Movie 2 Desc", DateTime.Now.AddDays(-50));
            addMovie("Movie 2 Title", "Movie 3 Desc", DateTime.Now.AddDays(-90));
            addMovie("Movie 3 Title", "Movie 4 Desc", DateTime.Now.AddDays(-4));
            addMovie("Movie 4 Title", "Movie 5 Desc", DateTime.Now.AddDays(-120));
            addMovie("Movie 5 Title", "Movie 6 Desc", DateTime.Now.AddDays(-40));
           

            addCity("Delhi");
            addCity("Gurugram");


            addCinema( 1, "Cinema1");
            addCinemaHall(1, "Cinema 1 Hall 1", 10);
            addCinemaHallSeats(1, 1);
            addCinemaHallSeats(1, 2);
            addCinemaHallSeats(1, 3);
            addCinemaHallSeats(1, 4);
            addCinemaHallSeats(1, 5);

            addCinemaHall(1, "Cinema 1 Hall 2", 15);
            addCinemaHallSeats(2, 1);
            addCinemaHallSeats(2, 2);
            addCinemaHallSeats(2, 3);
            addCinemaHallSeats(2, 4);
            addCinemaHallSeats(2, 5);


            addCinemaHall(1, "Cinema 1 Hall 3", 20);
            addCinemaHallSeats(3, 1);
            addCinemaHallSeats(3, 2);
            addCinemaHallSeats(3, 3);
            addCinemaHallSeats(3, 4);
            addCinemaHallSeats(3, 5);


            addCinema( 1, "Cinema2");
            addCinemaHall(2, "Cinema 2 Hall 1", 10);
            addCinemaHall(2, "Cinema 2 Hall 2", 15);
            addCinemaHall(2, "Cinema 2 Hall 3", 20);

            addCinema( 2, "Cinema3");
            addCinemaHall(3, "Cinema 3 Hall 1", 10);
            addCinemaHall(3, "Cinema 3 Hall 2", 15);
            addCinemaHall(3, "Cinema 3 Hall 3", 20);

            addCinema( 2, "Cinema4");
            addCinemaHall(4, "Cinema 4 Hall 1", 10);
            addCinemaHallSeats(10, 1);
            addCinemaHallSeats(10, 3);


            addCinemaHall(4, "Cinema 4 Hall 2", 15);
            addCinemaHallSeats(11, 1);
            addCinemaHallSeats(11, 2);
            addCinemaHallSeats(11, 3);


            addCinema( 2, "Cinema5");
            addCinemaHall(5, "Cinema 5 Hall 1", 10);
            addCinemaHallSeats(12, 1);
            addCinemaHallSeats(12, 2);
            addCinemaHallSeats(12, 3);

            addShows(1, 1, DateTime.Now.AddDays(1), DateTime.Now.AddDays(1), DateTime.Now.AddDays(1).AddHours(2));
            addShows(1, 1, DateTime.Now.AddDays(1), DateTime.Now.AddDays(1).AddHours(3), DateTime.Now.AddDays(1).AddHours(5));

            addShows(2, 4, DateTime.Now.AddDays(1), DateTime.Now.AddDays(1), DateTime.Now.AddDays(1).AddHours(2));
            addShows(3, 7, DateTime.Now.AddDays(1), DateTime.Now.AddDays(1).AddHours(3), DateTime.Now.AddDays(1).AddHours(5));

            addShows(2, 10, DateTime.Now.AddDays(1), DateTime.Now.AddDays(1), DateTime.Now.AddDays(1).AddHours(2));
            addShows(3, 12, DateTime.Now.AddDays(1), DateTime.Now.AddDays(1).AddHours(3), DateTime.Now.AddDays(1).AddHours(5));
        }

        private void addShows(int movieId, int cinemaHallId, DateTime date , DateTime startTime , DateTime endTime)
        {
            Show newShow = new Show()
            {
                MovieId  = movieId,
                CinemaHallId =  cinemaHallId,
                Date = date,
                StartTime = startTime,
                EndTime  = endTime
            };
            _applicationDbContext.Show.Add(newShow);
            _applicationDbContext.SaveChanges();
        }

        private void addCity(string name)
        {
            City newCity = new City()
            {
                Name = name,
            };
            _applicationDbContext.City.Add(newCity);
            _applicationDbContext.SaveChanges();
        }

        private void addCinema(int cityId ,  string name)
        {
            Cinema newCinema = new Cinema()
            {
                CityId =  cityId,
                Name = name
            };
            _applicationDbContext.Cinema.Add(newCinema);
            _applicationDbContext.SaveChanges();
        }

        private void addCinemaHall(int cinemaId, string name, int totalSeats)
        {
            CinemaHall newCinemaHall = new CinemaHall()
            {
                CinemaId = cinemaId,
                Name = name,
                TotalSeats =  totalSeats
            };
            _applicationDbContext.CinemaHall.Add(newCinemaHall);
            _applicationDbContext.SaveChanges();
        }

        private void addCinemaHallSeats(int cinemaHallId, int SeatNo)
        {
            CinemaHallSeat newCinemaHallSeat = new CinemaHallSeat()
            {
                CinemaHallId =  cinemaHallId,
                SeatNo = SeatNo,
                SeatType = 1
            };
            _applicationDbContext.CinemaHallSeat.Add(newCinemaHallSeat);
            _applicationDbContext.SaveChanges();
        }

        private void addMovie(string title , string description ,  DateTime releaseDate)
        {
            Movie newMovie = new Movie()
            {
                Description = description,
                ReleaseDate = releaseDate,
                Title = title
            };
            _applicationDbContext.Movie.Add(newMovie);
            _applicationDbContext.SaveChanges();
        }
    }
}
