using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Review_vies.Controllers
{
    public class SubmitController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("New");
        }

        public IActionResult New()
        {
            return View();
        }
    }
}