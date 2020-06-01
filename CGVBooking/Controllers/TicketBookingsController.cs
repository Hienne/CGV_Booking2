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
    public class TicketBookingsController : Controller
    {
        private CGVDBContext db = new CGVDBContext();

        // GET: TicketBookings
        public ActionResult Index()
        {
            var ticketBookings = db.TicketBookings.Include(t => t.Chair).Include(t => t.ShowTimes).Include(t => t.User);
            return View(ticketBookings.ToList());
        }

        // GET: TicketBookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketBooking ticketBooking = db.TicketBookings.Find(id);
            if (ticketBooking == null)
            {
                return HttpNotFound();
            }
            return View(ticketBooking);
        }

        // GET: TicketBookings/Create
        public ActionResult Create()
        {
            ViewBag.ChairID = new SelectList(db.Chairs, "ChairID", "Name");
            ViewBag.ShowTimesID = new SelectList(db.ShowTimes, "ShowTimesID", "ShowTimesID");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name");
            return View();
        }

        // POST: TicketBookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TicketBookingID,ShowTimesID,ChairID,UserID")] TicketBooking ticketBooking)
        {
            if (ModelState.IsValid)
            {
                db.TicketBookings.Add(ticketBooking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChairID = new SelectList(db.Chairs, "ChairID", "Name", ticketBooking.ChairID);
            ViewBag.ShowTimesID = new SelectList(db.ShowTimes, "ShowTimesID", "ShowTimesID", ticketBooking.ShowTimesID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name", ticketBooking.UserID);
            return View(ticketBooking);
        }

        // GET: TicketBookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketBooking ticketBooking = db.TicketBookings.Find(id);
            if (ticketBooking == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChairID = new SelectList(db.Chairs, "ChairID", "Name", ticketBooking.ChairID);
            ViewBag.ShowTimesID = new SelectList(db.ShowTimes, "ShowTimesID", "ShowTimesID", ticketBooking.ShowTimesID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name", ticketBooking.UserID);
            return View(ticketBooking);
        }

        // POST: TicketBookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TicketBookingID,ShowTimesID,ChairID,UserID")] TicketBooking ticketBooking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticketBooking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChairID = new SelectList(db.Chairs, "ChairID", "Name", ticketBooking.ChairID);
            ViewBag.ShowTimesID = new SelectList(db.ShowTimes, "ShowTimesID", "ShowTimesID", ticketBooking.ShowTimesID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name", ticketBooking.UserID);
            return View(ticketBooking);
        }

        // GET: TicketBookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketBooking ticketBooking = db.TicketBookings.Find(id);
            if (ticketBooking == null)
            {
                return HttpNotFound();
            }
            return View(ticketBooking);
        }

        // POST: TicketBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TicketBooking ticketBooking = db.TicketBookings.Find(id);
            db.TicketBookings.Remove(ticketBooking);
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
