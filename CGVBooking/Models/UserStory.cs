using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CGVBooking.Models
{
    public class UserStory
    {
        public int TicketBookingID { get; set; }
        public string ChairName { get; set; }
        public DateTime ShowTimeDate { get; set; }
        public string FilmName { get; set; }
        public string FilmPoster { get; set; }
        public string TimeSlot { get; set; }
    }
}