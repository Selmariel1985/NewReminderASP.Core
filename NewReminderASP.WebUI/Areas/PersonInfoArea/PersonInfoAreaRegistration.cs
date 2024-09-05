using System.Web.Mvc;

namespace NewReminderASP.WebUI.Areas.PersonInfoArea
{
    public class PersonInfoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "PersonInfoArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "PersonInfoArea_default",
                "PersonInfoArea/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}