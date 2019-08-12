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
        public ActionResult Random() //Default or "Index" For the action if multiple returns are involved. WE can leave the name ActionResult
        {
            // creating an instance of the movie model 
            var movie = new Movie() { Name = "Shrek!" };

            //return View(movie); // the "view" is tied by name --> the random method looks for the random view
            //return new ViewResult(); can also write like this

            return Content("Hello World");
        }
    }
}