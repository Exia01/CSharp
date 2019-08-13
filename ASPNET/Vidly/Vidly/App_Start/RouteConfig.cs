using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        //routes need to be defined from the most specific to the most generic
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //// this is also known as convention based routes
            //routes.MapRoute(
            //    "MoviesByReleaseDate", // name 
            //    "movies/released/{year}/{month}", // URL
            //    new { controller = "Movies", action = "ByReleaseDate" },// Optional params
            //    new { year = @"\d{4}", month = @"\d{2}" }//constrains of 4 digits and 2 respectively using regex with @ as verbatim string?
            //    );

            //using attribute routing below 
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}", // Rule --> nameOfController/nameOfAction/idOfAction
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional } //ID optional
            );
        }
    }
}
