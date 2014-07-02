using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prueba.Models;

namespace prueba.Controllers
{
    public class AlumnoController : Controller
    {
        private pruebaContext db = new pruebaContext();

        //
        // GET: /Alumno/

        public ActionResult Index()
        {
            return View(db.alumnoes.ToList());
        }

        //
        // GET: /Alumno/Details/5

        public ActionResult Details(int id = 0)
        {
            alumno alumno = db.alumnoes.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        //
        // GET: /Alumno/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Alumno/Create

        [HttpPost]
        public ActionResult Create(alumno alumno)
        {
            if (ModelState.IsValid)
            {
                db.alumnoes.Add(alumno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alumno);
        }

        //
        // GET: /Alumno/Edit/5

        public ActionResult Edit(int id = 0)
        {
            alumno alumno = db.alumnoes.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        //
        // POST: /Alumno/Edit/5

        [HttpPost]
        public ActionResult Edit(alumno alumno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alumno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alumno);
        }

        //
        // GET: /Alumno/Delete/5

        public ActionResult Delete(int id = 0)
        {
            alumno alumno = db.alumnoes.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        //
        // POST: /Alumno/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            alumno alumno = db.alumnoes.Find(id);
            db.alumnoes.Remove(alumno);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}