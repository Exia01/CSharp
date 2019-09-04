using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Vidly.Controllers
{

    [AllowAnonymous] //this will enable access to everyone regardless of status
    public class HomeController : Controller
    {
        [OutputCache(Duration = 50, Location = OutputCacheLocation.Server, VaryByParam ="*")]// caches the page, faster rendering set to 50secs
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