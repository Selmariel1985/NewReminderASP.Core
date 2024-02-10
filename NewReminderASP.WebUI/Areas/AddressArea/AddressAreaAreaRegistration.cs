using System.Web.Mvc;

namespace NewReminderASP.WebUI.Areas.AddressArea
{
    public class AddressAreaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AddressArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AddressArea_default",
                "AddressArea/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}