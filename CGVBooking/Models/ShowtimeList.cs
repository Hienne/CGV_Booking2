using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CGVBooking.Models
{
    public class ShowtimeList
    {
        public int FilmId { get; set; }

        
        public DateTime ShowtimeDate { get; set; }

        public string TimeSlot { get; set; }
        public int TimeSlotID { get; set; }
    }
}