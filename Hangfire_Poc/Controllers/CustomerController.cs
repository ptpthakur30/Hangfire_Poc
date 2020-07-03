using Hangfire_Poc.Business;
using Hangfire_Poc.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Hangfire_Poc.Controllers
{
    public class CustomerController : Controller
    {
        private IPersonBusiness personBusiness;
        public CustomerController()
        {
            personBusiness = new PersonBusiness();
        }
        public CustomerController(IPersonBusiness personBusiness)
        {
            this.personBusiness = personBusiness;
        }
        // GET: Customer
        public ActionResult Index()
        {
            List<Person> lstCust = personBusiness.GetPersonList();
            return View("~/Views/Customer/CustomerList.cshtml", lstCust);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
