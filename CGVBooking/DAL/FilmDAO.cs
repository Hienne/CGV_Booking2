using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CGVBooking.Models;

namespace CGVBooking.DAL
{
    public class FilmDAO
    {
        public CGVDBContext db = new CGVDBContext();

        public Film getFilmByID(int filmID)
        {
            List<Film> films = db.Films.ToList();

            var filmRecord = (from f in films
                             where f.FilmID == filmID
                             select new Film
                             {
                                 Name = f.Name,
                                 Director = f.Director,
                                 Actor = f.Actor,
                                 Poster = f.Poster,
                                 Type = f.Type,
                                 Description = f.Description,
                                 Language = f.Language,
                                 Trailer = f.Trailer,
                                 Rated = f.Rated,
                                 Time = f.Time,
                                 PremiereDate = f.PremiereDate
                             }).FirstOrDefault();
            return filmRecord;
        }

        public IEnumerable<ShowtimeList> GetShowtimeList(int filmID)
        {
            List<Film> films = db.Films.ToList();
            List<ShowTimes> showTimes = db.ShowTimes.ToList();
            List<TimeSlot> timeSlots = db.TimeSlots.ToList();

            var showTimeRecord = from s in showTimes
                                 from f in films
                                 from t in timeSlots
                                 where s.FilmID == f.FilmID && s.TimeSlotID == t.TimeSlotID && s.FilmID == filmID
                                 select new ShowtimeList
                                 {
                                     FilmId = f.FilmID,
                                     ShowtimeDate = s.Date,
                                     TimeSlot = t.Time,
                                     TimeSlotID = t.TimeSlotID
                                 };

            return showTimeRecord;
        }

        public List<Film> GetUpcomingFilm()
        {
            List<Film> films = db.Films.ToList();
            List<Film> upcomingFilms = new List<Film>();
            
            foreach(var f in films)
            {
                if(DateTime.Compare(f.PremiereDate, DateTime.Now) > 0)
                {
                    upcomingFilms.Add(f);
                }
            }

            return upcomingFilms;
        }

        public List<Film> GetReleasedFilm()
        {
            List<Film> films = db.Films.ToList();
            List<Film> releasedFilms = new List<Film>();

            foreach (var f in films)
            {
                if (DateTime.Compare(f.PremiereDate, DateTime.Now) <= 0)
                {
                    releasedFilms.Add(f);
                }
            }

            return releasedFilms;
        }
    }
}