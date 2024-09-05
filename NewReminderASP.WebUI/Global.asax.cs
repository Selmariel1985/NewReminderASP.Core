using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Autofac;
using Autofac.Integration.Mvc;
using log4net;
using log4net.Config;
using NewReminderASP.Dependencies.Container;

namespace NewReminderASP.WebUI
{
    /// <summary>
    ///     Entry point for the MVC application and handling of application-level events.
    /// </summary>
    public class MvcApplication : HttpApplication
    {
        /// <summary>
        ///     Handles the application start event and sets up the Autofac container and MVC configurations.
        /// </summary>
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new CommonModule());
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            XmlConfigurator.Configure();
        }

        /// <summary>
        ///     Handles post-authenticate request event and performs user authentication based on FormsAuthentication ticket.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            try
            {
                if (FormsAuthentication.CookiesSupported &&
                    Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    var ticket =
                        FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value);
                    if (ticket != null && !ticket.Expired)
                    {
                        var roles = ticket.UserData.Split(',');
                        HttpContext.Current.User = new GenericPrincipal(new FormsIdentity(ticket), roles);
                    }
                }

                // Skip authorization for a specific path
                if (HttpContext.Current.Request.Path.Contains("/RegisterArea/Register/Register"))
                    HttpContext.Current.SkipAuthorization = true;
            }
            catch (Exception ex)
            {
                // Log any errors that occur during authentication
                var log = LogManager.GetLogger(typeof(MvcApplication));
                log.Error("An error occurred in Application_PostAuthenticateRequest", ex);

                // Set response status in case of an internal server error
                Response.StatusCode = 500;
                Response.StatusDescription = "Internal Server Error";
            }
        }

        /// <summary>
        ///     Handles the session start event and initializes the 'LastActivity' session variable with the current time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Session_Start(object sender, EventArgs e)
        {
            Session["LastActivity"] = DateTime.UtcNow;
        }

        /// <summary>
        ///     Handles the acquire request state event and manages session timeout based on last activity time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session != null)
            {
                var lastActivity = Session["LastActivity"] as DateTime?;
                var sessionTimeoutMinutes = 25;
                if (lastActivity.HasValue && DateTime.UtcNow > lastActivity.Value.AddMinutes(sessionTimeoutMinutes))
                {
                    // Sign out the user and abandon the session if session timeout is exceeded
                    FormsAuthentication.SignOut();
                    Session.Abandon();
                }
                else if (lastActivity.HasValue &&
                         (DateTime.UtcNow - lastActivity.Value).TotalMinutes > sessionTimeoutMinutes)
                {
                    // Sign out the user and abandon the session if session timeout is exceeded
                    FormsAuthentication.SignOut();
                    Session.Abandon();
                }
                else
                {
                    // Update the 'LastActivity' with the current time if session is still active
                    Session["LastActivity"] = DateTime.UtcNow;
                }
            }
        }
    }
}