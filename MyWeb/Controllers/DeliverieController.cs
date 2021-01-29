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
    public class DeliverieController : Controller
    {
        private SportContext db = new SportContext();

        // GET: Deliverie
        public ActionResult Index()
        {
            var deliveries = db.Deliveries.Include(d => d.Discipline).Include(d => d.Sportsman);
            return View(deliveries.ToList());
        }

        // GET: Deliverie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delivery delivery = db.Deliveries.Find(id);
            if (delivery == null)
            {
                return HttpNotFound();
            }
            return View(delivery);
        }

        // GET: Deliverie/Create
        public ActionResult Create()
        {
            ViewBag.DisciplineID = new SelectList(db.Disciplines, "DisciplineID", "Name");
            ViewBag.SportsmanID = new SelectList(db.Sportsmans, "SportsmanID", "SurName");
            return View();
        }

        // POST: Deliverie/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeliveryID,DisciplineID,SportsmanID")] Delivery delivery)
        {
            if (ModelState.IsValid)
            {
                db.Deliveries.Add(delivery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DisciplineID = new SelectList(db.Disciplines, "DisciplineID", "Name", delivery.DisciplineID);
            ViewBag.SportsmanID = new SelectList(db.Sportsmans, "SportsmanID", "SurName", delivery.SportsmanID);
            return View(delivery);
        }

        // GET: Deliverie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delivery delivery = db.Deliveries.Find(id);
            if (delivery == null)
            {
                return HttpNotFound();
            }
            ViewBag.DisciplineID = new SelectList(db.Disciplines, "DisciplineID", "Name", delivery.DisciplineID);
            ViewBag.SportsmanID = new SelectList(db.Sportsmans, "SportsmanID", "SurName", delivery.SportsmanID);
            return View(delivery);
        }

        // POST: Deliverie/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeliveryID,DisciplineID,SportsmanID")] Delivery delivery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(delivery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DisciplineID = new SelectList(db.Disciplines, "DisciplineID", "Name", delivery.DisciplineID);
            ViewBag.SportsmanID = new SelectList(db.Sportsmans, "SportsmanID", "SurName", delivery.SportsmanID);
            return View(delivery);
        }

        // GET: Deliverie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delivery delivery = db.Deliveries.Find(id);
            if (delivery == null)
            {
                return HttpNotFound();
            }
            return View(delivery);
        }

        // POST: Deliverie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Delivery delivery = db.Deliveries.Find(id);
            db.Deliveries.Remove(delivery);
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
