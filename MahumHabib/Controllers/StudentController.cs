using MahumHabib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MahumHabib.Controllers
{
    public class StudentController : Controller
    {

        private ContextDb db = null;

        public StudentController()
        {
            db = new ContextDb();
        }

        public ActionResult Index(string search)
        {
            if (search != null)
            {
                Session["txt"] = search.ToString();
                return View(db.students.Where(x => x.Name.StartsWith(search)).ToList());
            }
            else
            {
                return View(db.students.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student s)
        {
            if (ModelState.IsValid)
            {
                db.students.Add(s);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View(db.students.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Student s)
        {
            db.Entry(s).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var data = db.students.Find(id);
            db.students.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            var data = db.students.Find(id);
            return View(data);
        }
    }
}