using System.Web.Mvc;
using System.Web.Routing;

namespace NewReminderASP.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Map the area route for the LoginArea
            routes.MapRoute(
                "LoginArea",
                "LoginArea/{controller}/{action}/{id}",
                new { controller = "Login", action = "Index", id = UrlParameter.Optional },
                new[] { "NewReminderASP.WebUI.Areas.LoginArea.Controllers" }
            );

            // Map the area route for the RegisterArea (corrected URL pattern)
            routes.MapRoute(
                "RegisterArea",
                "RegisterArea/{controller}/{action}/{id}",
                new { controller = "Register", action = "Index", id = UrlParameter.Optional },
                new[] { "NewReminderASP.WebUI.Areas.RegisterArea.Controllers" }
            );

            routes.MapRoute(
                "Default",
                "AccountsArea/{controller}/{action}/{id}",
                new { controller = "User", action = "Index", id = UrlParameter.Optional },
                new[] { "NewReminderASP.WebUI.Areas.AccountsArea.Controllers" }
            );
        }
    }
}