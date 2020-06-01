using CGVBooking.DAL;
using CGVBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CGVBooking.Controllers
{
    public class FilmController : Controller
    {
        private CGVDBContext db = new CGVDBContext();
        // GET: Film
        public ActionResult Index()
        {
            return View(db.Films.ToList());
        }

        public ActionResult Detail(int id)
        {

            var dao = new FilmDAO();
            return View(dao.getFilmByID(id));
        }

        public ActionResult UpcomingFilm()
        {
            var filmDAO = new FilmDAO();
            return View(filmDAO.GetUpcomingFilm());
        }

        public ActionResult ReleasedFilm()
        {
            var filmDAO = new FilmDAO();
            return View(filmDAO.GetReleasedFilm());
        }


    }
}