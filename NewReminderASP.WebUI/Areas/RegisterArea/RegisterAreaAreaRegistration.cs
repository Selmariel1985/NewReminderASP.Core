using System.Web.Mvc;

namespace NewReminderASP.WebUI.Areas.RegisterArea
{
    public class RegisterAreaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "RegisterArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "RegisterArea_default",
                "RegisterArea/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}