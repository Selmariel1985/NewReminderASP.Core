using System.Web.Mvc;
using System.Web.Routing;

namespace NewReminderASP.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

           



            routes.MapRoute(
                "LoginArea",
                "LoginArea/{controller}/{action}/{id}",
                new { controller = "Login", action = "Index", id = UrlParameter.Optional },
                new { isAdmin = new AdminRoleRouteConstraint() }
            );

            // Route for users with "admin" role
            routes.MapRoute(
                "AdminUser",
                "{controller}/{action}/{id}",
                new { controller = "User", action = "Index", id = UrlParameter.Optional },
                new { isAdmin = new AdminRoleRouteConstraint() }
            );



            routes.MapRoute(
                name: "EventDetails",
                url: "EventsArea/Event/Details/{userName}",
                defaults: new { controller = "Event", action = "Details" }
            );
        }
    }
}