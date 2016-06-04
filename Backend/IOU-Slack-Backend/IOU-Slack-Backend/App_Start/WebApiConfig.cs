using System.Data.Entity;
using System.Web.Http;
using IOU_Slack_Backend.Context;

namespace IOU_Slack_Backend
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            // Default Web API routes
            config.Routes.MapHttpRoute("DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Set initializer for Entity Framework Database
            Database.SetInitializer<SystemDbContext>(
                new DropCreateDatabaseIfModelChanges<SystemDbContext>()
                );
        }
    }
}
