using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Review_vies.HelperClasses;
using Review_vies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http.Headers;

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

        public IActionResult Sample()
        {
            var movies = _sqlConnector.SearchMoviesByTitle("").OrderBy(x => Guid.NewGuid()).ToList().Take(5);
            return Json(movies);
        }

        public Movie GetMovieById(int id)
        {
            return _sqlConnector.GetMovieById(id);
        }

        public string GetPosters(string querystring)
        {
            try
            {
                
                string subscriptionKey = "3ba1335123a64ed8ba84daad45113e8e";
                var uriBase = "https://api.bing.microsoft.com/v7.0/images/search";
                var uriQuery = uriBase + "?q=" + Uri.EscapeDataString(querystring);

                var request = WebRequest.Create(uriQuery);
                request.Headers["Ocp-Apim-Subscription-Key"] = subscriptionKey;
                var response = (HttpWebResponse)request.GetResponseAsync().Result;
                string json = new StreamReader(response.GetResponseStream()).ReadToEnd();
                var results = JsonConvert.DeserializeObject<BingSearchResult>(json);
                var take5 = results.Value.Take(5).ToList();

                return JsonConvert.SerializeObject(take5);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IActionResult GetPosterThumbs(string querystring)
        {
            try
            {

                string subscriptionKey = "3ba1335123a64ed8ba84daad45113e8e";
                var uriBase = "https://api.bing.microsoft.com/v7.0/images/search";
                var uriQuery = uriBase + "?q=" + Uri.EscapeDataString(querystring);

                var request = WebRequest.Create(uriQuery);
                request.Headers["Ocp-Apim-Subscription-Key"] = subscriptionKey;
                var response = (HttpWebResponse)request.GetResponseAsync().Result;
                string json = new StreamReader(response.GetResponseStream()).ReadToEnd();
                var results = JsonConvert.DeserializeObject<BingSearchResult>(json);
                var take5 = results.Value.Take(5).ToList();

                var resultstring = string.Empty;
                foreach (var img in take5)
                {
                    resultstring = resultstring + "<br>" + "<img src='" + img.thumbnailUrl + "'/>";
                }
                return new ContentResult()
                {
                    Content = resultstring,
                    ContentType = "text/html",
                };
            }
            catch (Exception e)
            {
                return null;
            }
        }


    }
}