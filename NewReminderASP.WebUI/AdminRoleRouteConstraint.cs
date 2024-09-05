using System.Web;
using System.Web.Routing;

namespace NewReminderASP.WebUI
{
    /// <summary>
    /// Custom route constraint to check if the user is in the 'admin' role.
    /// </summary>
    public class AdminRoleRouteConstraint : IRouteConstraint
    {
        /// <summary>
        /// Determines if the user is in the 'admin' role.
        /// </summary>
        /// <param name="httpContext">The HTTP context of the request.</param>
        /// <param name="route">The route being evaluated.</param>
        /// <param name="parameterName">The name of the route parameter associated with the constraint.</param>
        /// <param name="values">The route values.</param>
        /// <param name="routeDirection">The direction of the route (incoming or outgoing).</param>
        /// <returns>True if the user is in the 'admin' role; otherwise, false.</returns>
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            // Check if the user is in the 'admin' role
            if (httpContext.User.IsInRole("admin"))
            {
                return true;
            }

            return false;
        }
    }
}