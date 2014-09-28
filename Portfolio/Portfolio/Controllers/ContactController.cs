using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Conact/

        [HttpGet]
        public ActionResult Index()
        {
            return View(new Models.Contact());
        }

        [HttpPost]
        public ActionResult Index(Models.Contact contact)
        {
            Models.ContactReportEntities db = new Models.ContactReportEntities();

            db.Contacts.Add(contact);

            db.SaveChanges();

            return RedirectToAction("ThankYou", "Contact");
        }

        public ActionResult ThankYou()
        {
            return View();
        }

    }
}
