using Autofac;
using Autofac.Integration.Mvc;
using log4net;
using log4net.Config;
using NewReminderASP.Dependencies.Container;
using System;
using System.Diagnostics;
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
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                if (authTicket != null && !authTicket.Expired)
                {
                    var identity = new FormsIdentity(authTicket);
                    string[] roles = authTicket.UserData.Split(',');

                    GenericPrincipal newUser = new GenericPrincipal(identity, roles);
                    HttpContext.Current.User = Thread.CurrentPrincipal = newUser;

                    // Проверяем истечение времени неактивности
                    if ((DateTime.Now - authTicket.IssueDate).TotalMinutes > 1)
                    {
                        FormsAuthentication.SignOut();
                        FormsAuthentication.RedirectToLoginPage();
                        Debug.WriteLine("Session expired. Logging out user.");
                    }
                }
            }
        }

    }
}