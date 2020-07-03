using Hangfire_Poc.Attributes;
using Hangfire_Poc.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Hangfire_Poc.Controllers
{
    public partial class RegistrationController : Controller
    {
        [Authorize]
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        // GET: Registration/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Registration/Create
        public ActionResult Create()
        {
            return View(StaticConstants.RegistrationView);
        }

        // POST: Registration/Create
        [HttpPost]
        [Log]
        public ActionResult Create(Registration regModel)
        {
            try
            {
                return !ModelState.IsValid ? View(StaticConstants.RegistrationView, regModel) : (ActionResult)RedirectToAction(actionName: StaticConstants.Index, controllerName: StaticConstants.Home);
            }
            catch
            {
                return View();
            }
        }

        // GET: Registration/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Registration/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(StaticConstants.Index);
            }
            catch
            {
                return View();
            }
        }

        // GET: Registration/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Registration/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(StaticConstants.Index);
            }
            catch
            {
                return View();
            }
        }
      
       
        public JsonResult CheckUserName(string email)
        {
            List<string> studentUserList = new List<string> { "Manish@gmail.com", "Saurabh@gmail.com", "Akansha", "Ekta", "Rakesh", "Bhayia Jee" };

            bool result = studentUserList.Any(e=>e!=email);
            return Json(data: result, behavior: JsonRequestBehavior.AllowGet);
        }
    }
}
