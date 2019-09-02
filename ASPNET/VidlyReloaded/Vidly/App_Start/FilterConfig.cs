using System.Web;
using System.Web.Mvc;

namespace Vidly
{
    //here we can register global filters
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //this filter redirects the user to an error page when the actions throws an exception
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
