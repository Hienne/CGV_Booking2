using CGVBooking.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CGVBooking.DAL
{
    public class ShowTimeDAO
    {
        public CGVDBContext db = new CGVDBContext();

        public ShowtimeList GetShowTimes(int filmID, int timeslotID)
        {
            var filmDAO = new FilmDAO();
            List<ShowtimeList> showtimeLists = filmDAO.GetShowtimeList(filmID).ToList();

            var showtimeRecord = (from s in showtimeLists
                                  where s.TimeSlotID == timeslotID
                                  select new ShowtimeList
                                  {
                                      TimeSlot = s.TimeSlot,
                                      ShowtimeDate = s.ShowtimeDate
                                  }).FirstOrDefault();

            return showtimeRecord;
        }

        public ShowTimes getShowtime(int filmID, int timeslotID)
        {
            List<ShowTimes> showTimes = db.ShowTimes.ToList();

            foreach(var s in showTimes)
            {
                if (s.FilmID == filmID && s.TimeSlotID == timeslotID)
                    return s;
            }

            return null;
        }

        public TimeSlot getTimebyID(int timeslotID)
        {
            List<TimeSlot> timeSlots = db.TimeSlots.ToList();

            foreach(var t in timeSlots)
            {
                if (t.TimeSlotID == timeslotID)
                    return t;
            }

            return null;
        }
    }
}