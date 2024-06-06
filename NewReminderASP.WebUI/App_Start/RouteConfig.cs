using System.Web.Mvc;
using System.Web.Routing;

namespace NewReminderASP.WebUI
{
    public class RouteConfig
    {
        // Register custom routes for the application
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Ignore handling for AXD resource routes
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Default route for the application
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            // Route for the LoginArea with custom constraint for admin role
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

            // Route for Event details in the EventsArea
            routes.MapRoute(
                name: "EventDetails",
                url: "EventsArea/Event/Details/{userName}",
                defaults: new { controller = "Event", action = "Details" }
            );
        }
    }
}