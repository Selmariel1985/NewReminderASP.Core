using Autofac;
using Autofac.Integration.Mvc;
using log4net;
using log4net.Config;
using NewReminderASP.Dependencies.Container;
using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace NewReminderASP.WebUI
{
    public class MvcApplication : HttpApplication
    {

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





        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            try
            {
                if (FormsAuthentication.CookiesSupported && Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    var ticket = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value);
                    if (ticket != null && !ticket.Expired)
                    {
                        var roles = ticket.UserData.Split(',');
                        HttpContext.Current.User = new GenericPrincipal(new FormsIdentity(ticket), roles);
                    }
                }

                if (HttpContext.Current.Request.Path.Contains("/RegisterArea/Register/Register"))
                {
                    HttpContext.Current.SkipAuthorization = true;
                }
            }
            catch (Exception ex)
            {

                var log = LogManager.GetLogger(typeof(MvcApplication));
                log.Error("An error occurred in Application_PostAuthenticateRequest", ex);


                Response.StatusCode = 500;
                Response.StatusDescription = "Internal Server Error";
            }
        }

        

        protected void Session_Start(Object sender, EventArgs e)
        {
            Session["LastActivity"] = DateTime.UtcNow;
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session != null)
            {
                DateTime? lastActivity = Session["LastActivity"] as DateTime?;
                int sessionTimeoutMinutes = 25;  
                if (lastActivity.HasValue && DateTime.UtcNow > lastActivity.Value.AddMinutes(sessionTimeoutMinutes))
                {
                    FormsAuthentication.SignOut();
                    Session.Abandon();
                }
                else if (lastActivity.HasValue && (DateTime.UtcNow - lastActivity.Value).TotalMinutes > sessionTimeoutMinutes)
                {
                    FormsAuthentication.SignOut();
                    Session.Abandon();
                }
                else
                {
                    Session["LastActivity"] = DateTime.UtcNow;
                }
            }
        }
    }
}
       
    




















 