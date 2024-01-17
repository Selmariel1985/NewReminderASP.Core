using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Autofac;
using Autofac.Integration.Mvc;
using log4net.Config;
using NewReminderASP.Dependencies.Container;

namespace NewReminderASP.WebUI
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            // Создание контейнера Autofac
            var builder = new ContainerBuilder();

            // Регистрация модулей
            builder.RegisterModule(new CommonModule());

            // Регистрация контроллеров
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Сборка контейнера
            var container = builder.Build();

            // Установка Autofac в качестве резолвера зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            XmlConfigurator.Configure();
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            if (FormsAuthentication.CookiesSupported)
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                    try
                    {
                        //Получение билета пользователя из куки
                        var ticket = FormsAuthentication.Decrypt(
                            Request.Cookies[FormsAuthentication.FormsCookieName].Value);

                        // Создание GenericPrincipal и присваивание его HttpContext.User
                        if (ticket != null && !ticket.Expired)
                        {
                            var roles = ticket.UserData.Split(',');
                            HttpContext.Current.User = new GenericPrincipal(
                                new FormsIdentity(ticket), roles);
                        }
                    }
                    catch (Exception ex)
                    {
                        //логирование или обработка ошибки
                    }
        }
    }
}