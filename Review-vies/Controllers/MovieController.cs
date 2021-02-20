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
        
        public IActionResult Index(int Id)
        {
            var moviestring = JsonConvert.SerializeObject(SqlConnector.GetMovieById(Id));

            return View(JsonConvert.DeserializeObject<MovieViewModel>(moviestring)); ;
        }
    }
}