using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CGVBooking.DAL;

namespace CGVBooking.Controllers
{
    public class HomeController : Controller
    {
        private CGVDBContext db = new CGVDBContext();
        public ActionResult Index()
        {
            var filmDAO = new FilmDAO();
            return View(filmDAO.GetReleasedFilm());
        }
    }
}