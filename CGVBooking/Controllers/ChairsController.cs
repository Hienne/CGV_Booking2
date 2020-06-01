using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CGVBooking.DAL;
using CGVBooking.Models;

namespace CGVBooking.Controllers
{
    public class ChairsController : Controller
    {
        private CGVDBContext db = new CGVDBContext();

        // GET: Chairs
        public ActionResult Index()
        {
            var chairDAO = new ChairDAO();
            var chairstatus = chairDAO.getChairSelected2(1, 1);
            return View(chairstatus.ToList());
        }

        // GET: Chairs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chair chair = db.Chairs.Find(id);
            if (chair == null)
            {
                return HttpNotFound();
            }
            return View(chair);
        }

        // GET: Chairs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Chairs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChairID,Name,Fare,Type,Status")] Chair chair)
        {
            if (ModelState.IsValid)
            {
                db.Chairs.Add(chair);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chair);
        }

        // GET: Chairs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chair chair = db.Chairs.Find(id);
            if (chair == null)
            {
                return HttpNotFound();
            }
            return View(chair);
        }

        // POST: Chairs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChairID,Name,Fare,Type,Status")] Chair chair)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chair).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chair);
        }

        // GET: Chairs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chair chair = db.Chairs.Find(id);
            if (chair == null)
            {
                return HttpNotFound();
            }
            return View(chair);
        }

        // POST: Chairs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chair chair = db.Chairs.Find(id);
            db.Chairs.Remove(chair);
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
