using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Review_vies.HelperClasses;
using Review_vies.Models;
using System;
using System.Collections.Generic;
using System.Net;

namespace Review_vies.Controllers
{
    public class ApiController : Controller
    {

        SqlConnector _sqlConnector = new SqlConnector("Data Source = tcp:reviewvies.database.windows.net; Initial Catalog = ReviewviesDB; User ID = reviewviesadmin; Password=reviewviest3!");

        [HttpGet]
        [HttpPost]
        public IActionResult GetMovie(int id)
        {
            var movie = _sqlConnector.GetMovieById(id);
            return Json(movie);
        }

        [HttpPost]
        public IActionResult PostMovie(Movie movie)
        {
            var response = _sqlConnector.VerifyAndInsertSubmittedMovie(movie);

            if (response == 0)
            {
                return Json(HttpStatusCode.InternalServerError);
            }
            
            return Json(response);
        }

        public IActionResult SearchByTitle(string searchterm)
        {
            var movies = _sqlConnector.SearchMoviesByTitle(searchterm);
            return Json(movies);
        }

        public Movie GetMovieById(int id)
        {
            return _sqlConnector.GetMovieById(id);
        }

    }
}