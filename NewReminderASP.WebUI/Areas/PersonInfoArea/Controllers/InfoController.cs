using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using log4net;
using NewReminderASP.Core.Provider;
using NewReminderASP.Domain.Entities;

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

        public ActionResult SignOut()
        {
            return SignOutAndRedirectToLogin("LoginArea");
        }

        public ActionResult Index(string orderBy, string sortOrder, int page = 1)
        {
            var personalInfo = _provider.GetPersonalInfos().AsQueryable();
            const int pageSize = 10;

            var paginatedPersonalInfo =
                DynamicSortAndPaginate(personalInfo, orderBy, sortOrder, page, pageSize).ToList();


            var totalPersonalInfo = personalInfo.Count();
            var totalPages = (int)Math.Ceiling((double)totalPersonalInfo / pageSize);

            ViewBag.OrderBy = orderBy;
            ViewBag.SortOrder = sortOrder;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(paginatedPersonalInfo);
        }


        public ActionResult Edit(int id)
        {
            var model = _provider.GetPersonalInfo(id);

            if (model == null || (!User.IsInRole("Admin") && model.Login != User.Identity.Name))
                return new HttpUnauthorizedResult();


            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PersonalInfo personalInfo)
        {
            if (ModelState.IsValid)
            {
                var existingPersonalInfos = _provider.GetPersonalInfo(personalInfo.UserID);
                if (existingPersonalInfos != null &&
                    (User.IsInRole("Admin") || existingPersonalInfos.Login == User.Identity.Name))
                {
                    _provider.UpdatePersonalInfo(personalInfo);
                    return RedirectToAction("Index");
                }

                return new HttpUnauthorizedResult();
            }


            return View(personalInfo);
        }


        public ActionResult Details(int id)
        {
            var personalInfo = _provider.GetPersonalInfo(id);
            if (personalInfo == null || (!User.IsInRole("Admin") && personalInfo.Login != User.Identity.Name))
                return new HttpUnauthorizedResult();

            return View(personalInfo);
        }


        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            var model = new PersonalInfo();
            model.Users = _userProvider.GetUsers();
            model.Login = User.Identity.Name;

            // Set UserID to the Id of the current user
            var currentUser = _userProvider.GetUserByLogin(User.Identity.Name);
            if (currentUser != null) model.UserID = currentUser.Id;

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonalInfo personalInfo)
        {
            if (ModelState.IsValid)
            {
                // Set UserID to the Id of the current user
                var currentUser = _userProvider.GetUserByLogin(User.Identity.Name);
                if (currentUser != null) personalInfo.UserID = currentUser.Id;

                _provider.AddPersonalInfo(personalInfo);

                return RedirectToAction("Index");
            }

            personalInfo.Users = _userProvider.GetUsers();
            return View(personalInfo);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateAdmin()
        {
            var model = new PersonalInfo();
            model.Users = _userProvider.GetUsers();

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAdmin(PersonalInfo personalInfo)
        {
            if (ModelState.IsValid)
            {
                _provider.AddPersonalInfo(personalInfo);

                return RedirectToAction("Index");
            }

            personalInfo.Users = _userProvider.GetUsers();
            return View(personalInfo);
        }


        public ActionResult Delete(int id)
        {
            var personalInfo = _provider.GetPersonalInfo(id);


            if (personalInfo == null || (!User.IsInRole("Admin") && personalInfo.Login != User.Identity.Name))
                return new HttpUnauthorizedResult();

            return View(personalInfo);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var personalInfo = _provider.GetPersonalInfo(id);


            if (personalInfo == null || (!User.IsInRole("Admin") && personalInfo.Login != User.Identity.Name))
                return new HttpUnauthorizedResult();

            _provider.DeletePersonalInfo(id);
            return RedirectToAction("Index");
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