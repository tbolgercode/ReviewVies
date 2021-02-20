using Review_vies.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Review_vies.HelperClasses
{
    public class SqlConnector
    {
        SqlConnection _sqlConn = new SqlConnection("Data Source=reviewvies.database.windows.net;Initial Catalog=ReviewviesDB;User ID=reviewviesadmin;Password=reviewviest3!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public void PostMovie(Movie movie)
        {
            var movieId = InsertMovieIntoTable(movie);

            if (movieId == 0)
            {
                return;
            }

            movie.Id = movieId;

            return ;
        }


        public static Movie GetMovieById(int id)
        {

            //This will eventually be a sql call to get a movie's info by their id.
            if (id == 12345)
            {
                var movie = new Movie
                {
                    Id = 12345,
                    Actors = new List<string> { "Mark Wahlberg" },
                    Description = "A placeholder movie data",
                    Stars = 3,
                    Title = "Some Movie",
                    Rating = "PG",
                    Synopsis = "A placeholder for movie data",
                    Directors = new List<string> { "John Faverou", "Another Actor" }
                };
                return movie;

            }
            return null;
        }

        public int SearchMoviesByTitle(string searchterm)
        {
            //Return sql result searching the table by title
            return 12345;
        }

        public int InsertMovieIntoTable(Movie movie)
        {
            //Verify movie is ok
            if (VerifyMovieAsValid(movie))
            {
                return VerifyAndInsertSubmittedMovie(movie);
            }
            else
            {
                //If the movie wasn't valid return 400
                return 0;
            }
        }

        public bool VerifyMovieAsValid(Movie movie)
        {
            if (string.IsNullOrEmpty(movie.Title) ||
               string.IsNullOrEmpty(movie.Synopsis) ||
               string.IsNullOrEmpty(movie.Description) ||
               string.IsNullOrEmpty(movie.Rating) ||
               movie.Id == 0 ||
               movie.Stars == 0 ||
               movie.Actors.Count == 0 ||
               movie.Directors.Count == 0)
            {
                return false;
            }

            return true;
        }

        public int VerifyAndInsertSubmittedMovie(Movie movie)
        {
            //Verify movie is ok
            try
            {
                //Try to insert into sql
                return 12345;
            }
            catch (Exception e)
            {
                //If something goes wrong
                return 0;
            }

        }

    }
}
