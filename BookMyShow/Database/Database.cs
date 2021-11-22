using BookMyShow.Database.ApplicationDbContext;
using BookMyShow.Models.SystemModels;
using System;


namespace BookMyShow.Database
{
    public class Database
    {
        private readonly ApplicationContext _applicationDbContext;
        public Database(ApplicationContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void FillDemoData()
        {
            
            addMovie("Movie 1 Title", "Movie 2 Desc", DateTime.Now.AddDays(-50));
            addMovie("Movie 2 Title", "Movie 3 Desc", DateTime.Now.AddDays(-90));
            addMovie("Movie 3 Title", "Movie 4 Desc", DateTime.Now.AddDays(-4));
            addMovie("Movie 4 Title", "Movie 5 Desc", DateTime.Now.AddDays(-120));
            addMovie("Movie 5 Title", "Movie 6 Desc", DateTime.Now.AddDays(-40));
           

            addCity("Delhi");
            addCity("Gurugram");


            addCinema( 1, "Cinema1");
            addCinemaHall(1, "Cinema 1 Hall 1", 10);
            addCinemaHall(1, "Cinema 1 Hall 2", 15);
            addCinemaHall(1, "Cinema 1 Hall 3", 20);

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
            addCinemaHall(4, "Cinema 4 Hall 2", 15);


            addCinema( 2, "Cinema5");
            addCinemaHall(5, "Cinema 5 Hall 1", 10);



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
