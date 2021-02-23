using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Review_vies.HelperClasses;
using Review_vies.Models;

namespace Review_vies.Controllers
{
    public class SearchController : Controller
    {
        SqlConnector _sqlConnector = new SqlConnector();
        public IActionResult Index(string searchterm)
        {
            if (string.IsNullOrEmpty(searchterm))
            {
                return View(new SearchViewModel
                {
                    Results = new List<Movie>()
                });
            }
            var results = _sqlConnector.SearchMoviesByTitle(searchterm);
            return View(new SearchViewModel
            {
                Results = results
            }); 
        }
    }
}