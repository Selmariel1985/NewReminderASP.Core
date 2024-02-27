using System.Reflection;
using System.Web.Mvc;
using log4net;
using NewReminderASP.Core.Provider;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.WebUI.Areas.AddressArea.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AddressController : Controller
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IAddressProvider _provider;

        public AddressController(IAddressProvider provider)
        {
            _provider = provider;
        }


        public ActionResult Index()
        {
            var tt = _provider.GetAddresses();
            return View(tt);
        }

        public ActionResult Details(int id)
        {
            var address = _provider.GetAddress(id);
            if (address == null) return HttpNotFound();
            return View(address);
        }

        public ActionResult Edit(int id)
        {
            var address = _provider.GetAddress(id);
            if (address == null) return HttpNotFound();
            return View(address);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Address address)
        {
            if (ModelState.IsValid)
            {
                _provider.UpdateAddress(address);
                return RedirectToAction("Index");
            }

            return View(address);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Address address)
        {
            if (ModelState.IsValid)
            {
                _provider.AddAddress(address);
                return RedirectToAction("Index");
            }

            return View(address);
        }

        public ActionResult Delete(int id)
        {
            var address = _provider.GetAddress(id);
            if (address == null) return HttpNotFound();
            return View(address);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _provider.DeleteAddress(id);
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