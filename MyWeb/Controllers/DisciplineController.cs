using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyWeb.DAL;
using MyWeb.Models;

namespace MyWeb.Controllers
{
    public class DisciplineController : Controller
    {
        private SportContext db = new SportContext();

        // GET: Discipline
        public ActionResult Index()
        {
            return View(db.Disciplines.ToList());
        }

        // GET: Discipline/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discipline discipline = db.Disciplines.Find(id);
            if (discipline == null)
            {
                return HttpNotFound();
            }
            return View(discipline);
        }

        // GET: Discipline/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Discipline/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DisciplineID,Name,AgeGroup")] Discipline discipline)
        {
            if (ModelState.IsValid)
            {
                db.Disciplines.Add(discipline);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(discipline);
        }

        // GET: Discipline/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discipline discipline = db.Disciplines.Find(id);
            if (discipline == null)
            {
                return HttpNotFound();
            }
            return View(discipline);
        }

        // POST: Discipline/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DisciplineID,Name,AgeGroup")] Discipline discipline)
        {
            if (ModelState.IsValid)
            {
                db.Entry(discipline).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(discipline);
        }

        // GET: Discipline/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discipline discipline = db.Disciplines.Find(id);
            if (discipline == null)
            {
                return HttpNotFound();
            }
            return View(discipline);
        }

        // POST: Discipline/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Discipline discipline = db.Disciplines.Find(id);
            db.Disciplines.Remove(discipline);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
