using CGVBooking.Entity;
using CGVBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace CGVBooking.DAL
{
    public class ChairDAO
    {
        public CGVDBContext db = new CGVDBContext();

        public Chair getChairSelected(int filmID, int timeslotID)
        {
            List<Film> films = db.Films.ToList();
            List<ShowTimes> showTimes = db.ShowTimes.ToList();
            List<TimeSlot> timeSlots = db.TimeSlots.ToList();
            List<TicketBooking> ticketBookings = db.TicketBookings.ToList();
            var chairSelected = (from s in showTimes
                                from f in films
                                from t in timeSlots
                                from ti in ticketBookings
                                where f.FilmID == filmID && t.TimeSlotID == timeslotID
                                      && s.ShowTimesID == t.TimeSlotID && s.FilmID == f.FilmID
                                      && ti.ShowTimesID == s.ShowTimesID
                                select new Chair
                                {
                                    ChairID = ti.ChairID,

                                }).FirstOrDefault();
            
            return chairSelected;
        }


        
        public IEnumerable<ChairStatus> setChairSelected(int filmID, int timeslotID)
        {
            List<Chair> chairs = db.Chairs.ToList();
            List<Film> films = db.Films.ToList();

            var chairStatusRecord = from c in chairs
                                    from f in films
                                    where f.FilmID == filmID
                                    select new ChairStatus
                                    {
                                        ChairID = c.ChairID,
                                        ChairName = c.Name,
                                        ChairFare = c.Fare,
                                        ChairType = c.Type,
                                        status = c.ChairID == getChairSelected(filmID, timeslotID).ChairID ? true : false
                                    };

            return chairStatusRecord;
        }

        public IEnumerable<Chair> getChairSelected2(int filmID, int timeslotID)
        {
            List<Film> films = db.Films.ToList();
            List<ShowTimes> showTimes = db.ShowTimes.ToList();
            List<TimeSlot> timeSlots = db.TimeSlots.ToList();
            List<TicketBooking> ticketBookings = db.TicketBookings.ToList();
            List<Chair> chairs = db.Chairs.ToList();

            var chairSelected = (from s in showTimes
                                 from c in chairs
                                 from f in films
                                 from t in timeSlots
                                 from ti in ticketBookings
                                 where f.FilmID == filmID && t.TimeSlotID == timeslotID
                                       && s.TimeSlotID == t.TimeSlotID && s.FilmID == f.FilmID
                                       && ti.ShowTimesID == s.ShowTimesID && c.ChairID == ti.ChairID
                                 select new Chair
                                 {
                                     ChairID = ti.ChairID,
                                     Name = c.Name,
                                     Fare = c.Fare,
                                     Type = c.Type,
                                     Status = true
                                 });

            return chairSelected;
        }

        public Chair getChairIDByName(string chairName)
        {
            return db.Chairs.SingleOrDefault(x => x.Name == chairName);
        }

    

    }
}