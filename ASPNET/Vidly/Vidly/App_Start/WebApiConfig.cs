using System.Web.Http;
using Vidly.App_Start;
using Newtonsoft.Json.Serialization;
namespace Vidly
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            //config.Formatters.Add(new BrowserJsonFormatter());
            var settings = config.Formatters.JsonFormatter.SerializerSettings; //initializing settings
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Newtonsoft.Json.Formatting.Indented;
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}", //no action
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

//Setting up JSON Response: https://stackoverflow.com/questions/9847564/how-do-i-get-asp-net-web-api-to-return-json-instead-of-xml-using-chrome/13277616#13277616
