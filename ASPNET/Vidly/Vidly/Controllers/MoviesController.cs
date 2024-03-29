﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
        //helps dispose of the connection??
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult Index(int? pageIndex, string sortBy)
        //the ? next to int makes it okay to be nullable, strings are passed as reference and it is nullable 
        {
            ViewBag.Message = "Movies List";
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (string.IsNullOrEmpty(sortBy)) //null or empty. 
            {
                sortBy = "Name";

                var moviesSortedByName = _context.movies.Include(m => m.Genre).OrderBy(m => m.Name);
                return View(moviesSortedByName);
            }
            var movies = _context.movies.Include(m => m.Genre);
            return View(movies);
        }


        public ActionResult New()
        {
            var genres = _context.genres.ToList();

            //below we initialize a new view model which enables us to combine the models
            var viewModel = new MovieGenreViewModel()
            {
                Genres = genres,
            };
            return View(viewModel); //Overriding the "New" view
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
          
            if (!ModelState.IsValid)
            {
                var pendingMovieModel = new MovieGenreViewModel(movie)
                {

                    Genres = _context.genres.ToList()
                };
                return View("New", pendingMovieModel);
            }
            movie.DateAdded = System.DateTime.Now;
            _context.movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Route("Movies/Movie/{id}")]
        public ActionResult Show(int id)
        {
            ViewBag.Message = "Movie Detail";
            var movie = _context.movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();

            }
            else
            {

                return View(movie);
            }
        }

        //[Route("Movies/Movie/{id}")] //try to fix to movies/id/edit instead
        public ActionResult Edit(int id)
        {
            ViewBag.Message = "Edit Movie";
            var movie = _context.movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();

            }
            else
            {
                var viewmodel = new MovieGenreViewModel(movie) //passing movie to constructor
                {

                    Genres = _context.genres.ToList(),

                };
                return View(viewmodel);
            }

        }

        [HttpPut]
        [Route("Movies/Movie/{id}")]
        public ActionResult Update(Movie movie)
        {
            var foundMovie = _context.movies.Single(m => m.Id == movie.Id);
            if (!ModelState.IsValid)
            {
                var pendingMovieModel = new MovieGenreViewModel(foundMovie)
                {

                    Genres = _context.genres.ToList()
                };
                return View("Edit", pendingMovieModel);
            }
            //can also use auto mapper, convention name tool
            foundMovie.Name = movie.Name;
            foundMovie.DateReleased = movie.DateReleased;
            foundMovie.NumberInStock = movie.NumberInStock;
            foundMovie.GenreId = movie.GenreId;

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
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