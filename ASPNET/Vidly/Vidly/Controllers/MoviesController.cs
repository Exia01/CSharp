using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random 
        public ActionResult Random() //Default or "Index"
        {
            // creating an instance of the movie model 
            var movie = new Movie() { Name = "Shrek!" };

            return View(movie); // The "View" is tied by name --> the Random method looks for the Random view
        }
    }
}