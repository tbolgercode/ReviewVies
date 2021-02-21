using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Review_vies.HelperClasses;
using Review_vies.Models;

namespace Review_vies.Controllers
{
    public class MovieController : Controller
    {
        SqlConnector _sqlConn = new SqlConnector();
        public IActionResult Index(int Id)
        {
            var movie = _sqlConn.GetMovieById(Id);
            return View(new MovieViewModel(movie));
        }
    }
}