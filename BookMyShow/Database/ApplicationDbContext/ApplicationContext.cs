using BookMyShow.Models.SystemModels;
using Microsoft.EntityFrameworkCore;

namespace BookMyShow.Database.ApplicationDbContext
{
    public class ApplicationContext: DbContext
    {
       public ApplicationContext(DbContextOptions options) : base(options)
       {
       }

       public DbSet<Cinema> Cinema { get; set; }
       public DbSet<CinemaHall> CinemaHall { get; set; }
       public DbSet<CinemaHallSeat> CinemaHallSeat { get; set; }
       public DbSet<Movie> Movie { get; set; }
       public DbSet<User> User { get; set; }
       public DbSet<Show> Show { get; set; }
       public DbSet<City> City { get; set; }
       public DbSet<Booking> Booking { get; set; }
       public DbSet<ShowSeat> ShowSeat { get; set; }
    }
}
