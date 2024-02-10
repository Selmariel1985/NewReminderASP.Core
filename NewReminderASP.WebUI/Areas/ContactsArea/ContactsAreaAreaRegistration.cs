using System.Web.Mvc;

namespace NewReminderASP.WebUI.Areas.ContactsArea
{
    public class ContactsAreaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ContactsArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ContactsArea_default",
                "ContactsArea/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}