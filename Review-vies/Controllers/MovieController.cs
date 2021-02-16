using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Review_vies.Models;

namespace Review_vies.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index(int movieId)
        {
            return View(new MovieViewModel
            {
                Id = movieId
            }); ;
        }
    }
}