using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CGVBooking.Models
{
    public class ShowTimes
    {
        public ShowTimes()
        {
            TicketBookings = new HashSet<TicketBooking>();
        }

        public int ShowTimesID { get; set; }

        public int FilmID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int TimeSlotID { get; set; }

        public int CinemaRoom { get; set; }

        public virtual TimeSlot TimeSlot { get; set; }
        
        public Film Film { get; set; }

        public virtual ICollection<TicketBooking> TicketBookings { get; set; }
    }
}