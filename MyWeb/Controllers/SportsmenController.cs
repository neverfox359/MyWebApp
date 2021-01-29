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
    public class SportsmenController : Controller
    {
        private SportContext db = new SportContext();

        // GET: Sportsmen
        public ActionResult Index()
        {
            return View(db.Sportsmans.ToList());
        }

        // GET: Sportsmen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sportsman sportsman = db.Sportsmans.Find(id);
            if (sportsman == null)
            {
                return HttpNotFound();
            }
            return View(sportsman);
        }

        // GET: Sportsmen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sportsmen/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SportsmanID,SurName,Name,BirthDay")] Sportsman sportsman)
        {
            if (ModelState.IsValid)
            {
                db.Sportsmans.Add(sportsman);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sportsman);
        }

        // GET: Sportsmen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sportsman sportsman = db.Sportsmans.Find(id);
            if (sportsman == null)
            {
                return HttpNotFound();
            }
            return View(sportsman);
        }

        // POST: Sportsmen/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SportsmanID,SurName,Name,BirthDay")] Sportsman sportsman)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sportsman).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sportsman);
        }

        // GET: Sportsmen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sportsman sportsman = db.Sportsmans.Find(id);
            if (sportsman == null)
            {
                return HttpNotFound();
            }
            return View(sportsman);
        }

        // POST: Sportsmen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sportsman sportsman = db.Sportsmans.Find(id);
            db.Sportsmans.Remove(sportsman);
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
