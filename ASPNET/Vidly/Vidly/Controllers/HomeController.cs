using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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
FileStreamResult	Represents the content of a file	File()
JavaScriptResult	Represent a JavaScript script.	JavaScript()
JsonResult	        Represent JSON that can be used in AJAX	Json()
RedirectResult	    Represents a redirection to a new URL	Redirect()
RedirectToRouteResult	    Represent another action of same or other controller	RedirectToRoute()
PartialViewResult	        Returns HTML	PartialView()
HttpUnauthorizedResult	    Returns HTTP 403 status	
*/
