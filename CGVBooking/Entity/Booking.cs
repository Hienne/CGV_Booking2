using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CGVBooking.Entity
{
    public class Booking
    {
        public int BookingID { get; set; }

        public string NameChair { get; set; }
        public int FareChair { get; set; }
        public string TypeChair { get; set; }
        public bool StatusChair { get; set; }

        public DateTime DateShowTime { get; set; }
        public string TimeSlot { get; set; }

        public string NameFilm { get; set; }
        public string PosterFilm { get; set; }
        public string TypeFilm { get; set; }
        public string RatedFilm { get; set; }
    }
}