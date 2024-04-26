using System;
using System.Web;
using System.Web.Routing;

namespace NewReminderASP.WebUI
{
    public class AdminRoleRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (httpContext.User.IsInRole("admin"))
            {
                return true;
            }

            return false;
        }
    }
}