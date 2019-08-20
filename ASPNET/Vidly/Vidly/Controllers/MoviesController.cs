using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        // db context declaration
        private ApplicationDbContext _context;

        //initializing in constructor
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }


        //GET /movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            ViewBag.Message = "Movies List";
            //the ? next to int makes it okay to be nullable, strings are passed as reference and it is nullable 
            if (!pageIndex.HasValue)//if it doesn't have value set to 1
            {
                pageIndex = 1;
            }
            if (string.IsNullOrEmpty(sortBy)) //null or empty. 
            {
                sortBy = "Name";
                var moviesSortedByName = _context.movies.OrderBy(m => m.Name);
                return View(moviesSortedByName);
            }
            var movies = _context.movies;
            return View(movies);
        }

        [Route("Movies/Details/{id}")]
        public ActionResult Details(int id)
        {
            ViewBag.Message = "Movie Detail";
            var movie = _context.movies;
            //because of the SingleOrDefault extension method, this will query the db 
            var foundMovie = movie.SingleOrDefault(c => c.Id == id);

            if (foundMovie != null)
            {
                return View(foundMovie);

            }
            else
            {
                return HttpNotFound();
            }
        }



        // GET: movies/edit/:id 
        public ActionResult Edit(int id)
        {
            return Content($"id: {id}");
        }

        // GET: movies/Random  
        //action result is a general action, has subtypes 
        public ActionResult Random() //Default or "Index" For the action if multiple returns are involved. WE can leave the name ActionResult
        {
            // creating an instance of the movie model 
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"},
            };
            var viewModel = new RandomMoviewViewModel
            {
                Movie = movie,
                Customers = customers,
            };
            //ViewData["Movie"] = movie; //creating a dictionary
            //ViewBag.Movie = movie; 
            //Methods above we have to remember to change it in the template
            return View(viewModel); // the "view" is tied by name --> the random method looks for the random view
                                    //return new ViewResult(); can also write like this


            //return HttpNotFound();
            //Here we can specify the following: "NameOfAction, Controller, arguments 
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "Name" });
            //passing anonymous object
        }

        [Route("Movies/Released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month) // use byte for month 
        {
            return Content($"{year}/{month}");
        }
    }
}

/*
There are different Types of action results in ASP.NET MVC. Each result has a different type of result format to view page.

Result Class	Description	Base Controller Method
ViewResult	    Represents HTML and markup.	View()
EmptyResult	    Represents No response.	
ContentResult	Represents string literal.	Content()
FileContentResult,
FilePathResult,
FileStreamResult	Represents the content of a file File()
JavaScriptResult	Represent a JavaScript script.	JavaScript()
JsonResult	        Represent JSON that can be used in AJAX	Json()
RedirectResult	    Represents a redirection to a new URL	Redirect()
RedirectToRouteResult	    Represent another action of same or other controller	RedirectToRoute()
PartialViewResult	        Returns HTML	PartialView()
HttpUnauthorizedResult	    Returns HTTP 403 status	
*/


//Attribute route constraints: https://devblogs.microsoft.com/aspnet/attribute-routing-in-asp-net-mvc-5/