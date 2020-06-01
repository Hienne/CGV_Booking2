using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CGVBooking.Models
{
    public class TimeSlot
    {
        public TimeSlot()
        {
            ShowTimes = new HashSet<ShowTimes>();
        }

        public int TimeSlotID { get; set; }
        
        public string Time { get; set; }

        public double FarePersent { get; set; }

        public virtual ICollection<ShowTimes> ShowTimes { get; set; }
    }
}