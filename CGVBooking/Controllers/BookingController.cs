using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;
using CGVBooking.Common;
using CGVBooking.DAL;
using CGVBooking.Models;

namespace CGVBooking.Controllers
{
    public class BookingController : BaseController
    {
        private CGVDBContext db = new CGVDBContext();
        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowTimesList(int id)
        {
            var dao = new FilmDAO();
            return View(dao.GetShowtimeList(id));
        }

        public ActionResult chairStatus(int filmID, int timeslotID)
        {
            var chairDAO = new ChairDAO();
            var filmDAO = new FilmDAO();
            var showtimeDAO = new ShowTimeDAO();
            var userDAO = new UserDAO();

            List<Chair> chair = db.Chairs.ToList();
            List<Chair> chairSelected = chairDAO.getChairSelected2(filmID, timeslotID).ToList();

            Film f = filmDAO.getFilmByID(filmID);
            ViewBag.film = f;

            ShowTimes s = showtimeDAO.getShowtime(filmID, timeslotID);
            ViewBag.showtime = s;

            TimeSlot t = showtimeDAO.getTimebyID(timeslotID);
            ViewBag.timeslot = t.Time;

            var userLogin = (UserLogin)Session[CommonConstants.USER_SESSION];
            ViewBag.userLogged = userDAO.getUserById(userLogin.UserID);

            foreach (var c in chair)
            {
                foreach(var cs in chairSelected)
                {
                    if(c.ChairID == cs.ChairID)
                    {
                        c.Status = true;
                    }
                }
            }

            ViewBag.chair = chair;

            return View();
        }


        [HttpPost]
        public ActionResult chairStatus(BookingModel model)
        {
            if (ModelState.IsValid)
            {
                ShowTimeDAO showTimeDAO = new ShowTimeDAO();
                ChairDAO chairDAO = new ChairDAO();
                UserDAO userDAO = new UserDAO();

                TicketBooking newtick = new TicketBooking();
                newtick.ShowTimesID = model.showTimeID;

                Chair chair = chairDAO.getChairIDByName(model.ChairName);
                newtick.ChairID = chair.ChairID;

                var userLogin = (UserLogin)Session[CommonConstants.USER_SESSION];
                newtick.UserID = userLogin.UserID;

                userDAO.Update(chair.Fare, userLogin.UserID);
                
                db.TicketBookings.Add(newtick);
                db.SaveChanges();
                
                return RedirectToAction("InforUser", "User");
            }

            return View("Login");
        }



    }
}