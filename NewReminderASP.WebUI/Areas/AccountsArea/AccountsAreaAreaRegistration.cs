using System.Web.Mvc;

namespace NewReminderASP.WebUI.Areas.AccountsArea
{
    public class AccountsAreaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "AccountsArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AccountsArea_default",
                "AccountsArea/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "NewReminderASP.WebUI.Areas.AccountsArea.Controllers" }
            );
        }
    }
}