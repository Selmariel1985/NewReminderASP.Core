using System.Reflection;
using System.Web.Mvc;
using log4net;
using NewReminderASP.Core.Provider;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.WebUI.Areas.PersonInfoArea.Controllers
{
    public class InfoController : Controller
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IPersonalInformationProvider _provider;


        public InfoController(IPersonalInformationProvider provider)
        {
            _provider = provider;
        }


        public ActionResult Index()
        {
            var tt = _provider.GetPersonalInfos();
            return View(tt);
        }

        public ActionResult Edit(string login)
        {
            var personalInfo = _provider.GetPersonalInfo(login);
            if (personalInfo == null) return HttpNotFound();
            return View(personalInfo);
        }

        // POST: User/Edit/5
        [HttpPost]

        public ActionResult Edit(PersonalInfo personalInfo)
        {
            if (ModelState.IsValid)
            {
                _provider.UpdatePersonalInfo(personalInfo);
                return RedirectToAction("Index");
            }

            return View(personalInfo);
        }
        public ActionResult Details(string login)
        {
            var personalInfo = _provider.GetPersonalInfo(login);
            if (personalInfo == null) return HttpNotFound();
            return View(personalInfo);
        }
        public ActionResult Create()
        {
            return View(new PersonalInfo());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string userLogin, PersonalInfo personalInfo)
        {
            if (ModelState.IsValid)
            {
                _provider.AddPersonalInfo(userLogin, personalInfo);
                return RedirectToAction("Index");
            }

            return View(personalInfo);
        }

        public ActionResult Delete(string login)
        {
            var personalInfo = _provider.GetPersonalInfo(login);
            if (personalInfo == null) return HttpNotFound();
            return View(personalInfo);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string login)
        {
            _provider.DeletePersonalInfo(login);
            return RedirectToAction("Index");
        }
    }
}