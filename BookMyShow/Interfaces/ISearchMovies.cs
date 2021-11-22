using BookMyShow.Models.DTOModels;
using BookMyShow.Models.SystemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyShow.Interfaces
{
    public interface ISearchMovies
    {
        List<Movie> GetMoviesByCity(int cityId);
        List<CinemaOutPutDTO> GetCinemaByMovie(int movieId);
    }
}
