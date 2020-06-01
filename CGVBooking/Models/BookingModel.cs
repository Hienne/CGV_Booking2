using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CGVBooking.Models
{
    public class BookingModel
    {
        //public IEnumerable<ChairStatus> chairs { get; set; }
        //public ShowtimeList showtime { get; set; }
        //public Film film { get; set; }

        public int showTimeID { get; set; }
        public string ChairName { get; set; }
        public int userID { get; set; }
        public string payment { get; set; }
    }
}