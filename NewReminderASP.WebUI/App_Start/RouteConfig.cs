using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                name: "LoginArea",
                url: "LoginArea/{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "NewReminderASP.WebUI.Areas.LoginArea.Controllers" }
            );

            // Map the area route for the RegisterArea (corrected URL pattern)
            routes.MapRoute(
                name: "RegisterArea",
                url: "RegisterArea/{controller}/{action}/{id}",
                defaults: new { controller = "Register", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "NewReminderASP.WebUI.Areas.RegisterArea.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "AccountsArea/{controller}/{action}/{id}",
                defaults: new { controller = "User", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "NewReminderASP.WebUI.Areas.AccountsArea.Controllers" }
            );
        }
    }
}




