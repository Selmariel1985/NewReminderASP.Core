using log4net;
using NewReminderASP.Core.Provider;
using NewReminderASP.Domain.Entities;
using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace NewReminderASP.WebUI.Areas.PersonInfoArea.Controllers
{
    public class InfoController : BaseController
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IPersonalInformationProvider _provider;
        private readonly IUserProvider _userProvider;

        public InfoController(IPersonalInformationProvider provider, IUserProvider userProvider)
        {
            _provider = provider;
            _userProvider = userProvider;
        }


        public ActionResult Index(string orderBy, string sortOrder, int page = 1)
        {
            var personalInfo = _provider.GetPersonalInfos().AsQueryable();
            const int pageSize = 10;

            var paginatedPersonalInfo = DynamicSortAndPaginate(personalInfo, orderBy, sortOrder, page, pageSize).ToList();


            int totalPersonalInfo = personalInfo.Count();
            int totalPages = (int)Math.Ceiling((double)totalPersonalInfo / pageSize);

            ViewBag.OrderBy = orderBy;
            ViewBag.SortOrder = sortOrder;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(paginatedPersonalInfo);
        }

      

        public ActionResult Edit(string login)
        {
            var personalInfo = _provider.GetPersonalInfo(login);
            if (personalInfo == null)
            {
               
                personalInfo = new PersonalInfo { Login = login }; 
            }
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
            var model = new PersonalInfo();
            model.Users = _userProvider.GetUsers();

            return View(model);
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
            personalInfo.Users = _userProvider.GetUsers();
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
            try
            {
                _provider.DeletePersonalInfo(login);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.Error("Error deleting personal information", ex);
                ModelState.AddModelError(string.Empty, "Ошибка при удалении персональной информации.");
                return View(_provider.GetPersonalInfo(login));
            }
        }
        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    if (!filterContext.ExceptionHandled)
        //    {
        //        _logger.Error("An unhandled exception occurred", filterContext.Exception);
        //        filterContext.Result = new ViewResult
        //        {
        //            ViewName = "Error"
        //        };
        //        filterContext.ExceptionHandled = true;
        //    }
        //}
    }
}