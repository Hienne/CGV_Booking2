using CGVBooking.DAL;
using CGVBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace CGVBooking.Controllers
{
    public class Booking2Controller : Controller
    {
        // GET: Booking2

        public CGVDBContext db = new CGVDBContext();
        public ActionResult Index()
        {
            var ticketBookings = db.TicketBookings.Include(t => t.Chair).Include(t => t.ShowTimes).Include(t => t.User);
            return View(ticketBookings.ToList());
        }

        public ActionResult Booking()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Booking(BookingModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ShowTimeDAO showTimeDAO = new ShowTimeDAO();
        //        ShowTimes showTime = showTimeDAO.getShowtime(1, 1);

        //        TicketBooking newtick = new TicketBooking();
        //        newtick.ShowTimesID = showTime.ShowTimesID;
        //        newtick.ChairID = model.ChairID;
        //        newtick.UserID = 1;

        //        db.TicketBookings.Add(newtick);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View("Booking");
        //}
    }
}