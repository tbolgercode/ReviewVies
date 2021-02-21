using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Review_vies.Models
{
    public class MovieViewModel: Movie
    {
        public MovieViewModel(Movie movie)
        {
            Id = movie.Id;
            Title = movie.Title;
            Director = movie.Director;
            Year = movie.Year;
            Rating = movie.Rating;
            Scale = movie.Scale;
        }

    }
}
