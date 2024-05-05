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


            // Route for other users
            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Event", action = "Index", id = UrlParameter.Optional }
            );
            //routes.MapRoute(
            //    name: "EventAsAnonymous",
            //    url: "Login/EventAsAnonymous",
            //    defaults: new { controller = "Login", action = "EventAsAnonymous" }
            //);
        }
    }
}