using System.Web.Mvc;

namespace NewReminderASP.WebUI.Areas.EventsArea
{
    public class EventsAreaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "EventsArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "EventsArea_default",
                "EventsArea/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}