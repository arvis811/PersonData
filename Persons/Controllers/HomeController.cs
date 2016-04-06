using Persons.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Persons.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Models.Person person)
        {
            using (PersonContext db = new PersonContext())
            {
                db.Persons.Add(person);
                db.SaveChanges();
                ViewBag.a = "Success";

                return View();
            }
        }
        public ActionResult ListAllPersons()
        {
            PersonContext db = new PersonContext();
            return View(db.Persons.ToList());
        }
        [HttpPost]
        public ActionResult Delete(FormCollection formCollection)
        {
            if (formCollection["id"] == null)
            {
                ViewBag.SelectToDelete = "Select what you need to delete.";
            }
            else
            {
                string[] ids = formCollection["Id"].Split(new char[] { ',' });
                foreach (string id in ids)
                {
                    using (PersonContext db = new PersonContext())
                    {
                        var person = db.Persons.Find(int.Parse(id));
                        try
                        {
                            db.Persons.Remove(person);
                            db.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }
            }
            return RedirectToAction("ListAllPersons");
        }
    }
}