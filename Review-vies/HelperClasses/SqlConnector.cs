using Review_vies.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Review_vies.HelperClasses
{
    public class SqlConnector
    {
        public string ConnectionString;

        public SqlConnector()
        {
            ConnectionString = "Data Source = reviewvies.database.windows.net; Initial Catalog = ReviewviesDB; User ID = reviewviesadmin; Password=reviewviest3!;";
        }


        public SqlConnector(string connString)
        {
            ConnectionString = connString;
        }        
        
        public Movie GetMovieById(int id)
        {
            try
            {
                Movie movie = null;
                using (var SqlConn = new SqlConnection(ConnectionString))
                {

                

                    SqlCommand cmd = new SqlCommand("dbo.SearchForMovieById");
                    cmd.Connection = SqlConn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@SomeId", SqlDbType.Int).Value = id;

                    SqlConn.Open();
                    var reader = cmd.ExecuteReader();
                    reader.Read();

                    movie = new Movie();
                    movie.Title = reader.GetFieldValue<string>(0);
                    movie.Year = reader.GetFieldValue<string>(1);
                    movie.Rating = reader.GetFieldValue<string>(2);
                    movie.Scale = reader.GetFieldValue<short>(3);
                    movie.Director = reader.GetFieldValue<string>(4);
                    movie.Id = reader.GetFieldValue<int>(5);
                    if (!reader.IsDBNull(6))
                    {
                        movie.Poster = reader.GetFieldValue<string>(6);
                    }


                    SqlConn.Close();
                }
                return movie;
            }
            catch (Exception e)
            {

                return new Movie
                {
                    Title = e.Message
                };
            }
        }

        public List<Movie> SearchMoviesByTitle(string searchterm)
        {
            //Return sql result searching the table by title
            try
            {
                var results = new List<Movie>();
                using (var SqlConn = new SqlConnection(ConnectionString))
                {
                    SqlConn.Open();
                    SqlCommand cmd = new SqlCommand("dbo.SearchForMovieByTitle");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = SqlConn;
                    cmd.Parameters.Add("@SomeTitle", SqlDbType.NVarChar).Value = searchterm;

                    var reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            var poster = String.Empty;
                            if (!reader.IsDBNull(6))
                            {
                                poster = reader.GetFieldValue<string>(6);
                            }



                            results.Add(new Movie
                            {
                                Title = reader.GetFieldValue<string>(0),
                                Year = reader.GetFieldValue<string>(1),
                                Rating = reader.GetFieldValue<string>(2),
                                Scale = reader.GetFieldValue<short>(3),
                                Director = reader.GetFieldValue<string>(4),
                                Id = reader.GetFieldValue<int>(5),
                                Poster = poster
                            });

                        }
                        SqlConn.Close();
                    }
                    else
                    {
                        SqlConn.Close();
                        return results;
                    }

                }
                return results;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        public int InsertMovieIntoTable(Movie movie)
        {
            try
            {
            
                using (var SqlConn = new SqlConnection(ConnectionString))
                {
                    SqlConn.Open();
                    SqlCommand cmd = new SqlCommand("dbo.AddMovie");
                    cmd.Connection = SqlConn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Director", SqlDbType.NVarChar).Value = movie.Director;
                    cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = movie.Title;
                    cmd.Parameters.Add("@Year", SqlDbType.NVarChar).Value = movie.Year;
                    cmd.Parameters.Add("@Scale", SqlDbType.SmallInt).Value = movie.Scale;
                    cmd.Parameters.Add("@Rating", SqlDbType.NVarChar).Value = movie.Rating;



                    var rowsaffected = cmd.ExecuteNonQuery();

                    SqlConn.Close();

                    if (rowsaffected == 1)
                    {
                        return rowsaffected;
                    }
                    else
                    {
                        return 400;
                    }
                }
            }
            catch (Exception e)
            {
                return 500;
            }

        }

        public bool VerifyMovieAsValid(Movie movie)
        {
            if (string.IsNullOrEmpty(movie.Title) ||
               string.IsNullOrEmpty(movie.Rating) ||
               string.IsNullOrEmpty(movie.Director) ||
               movie.Scale == 0)
            {
                return false;
            }

            return true;
        }

        public int VerifyAndInsertSubmittedMovie(Movie movie)
        {
            //Verify movie is ok
            if (VerifyMovieAsValid(movie))
            {
                try
                {
                    return InsertMovieIntoTable(movie);
                }
                catch (Exception e)
                {
                    //If something goes wrong
                    return 503;
                }
            }
            else
            {
                return 400;
            }

        }

    }
}
