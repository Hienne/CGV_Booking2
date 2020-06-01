using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CGVBooking.Models
{
    public class Chair
    {
        public Chair()
        {
            TicketBookings = new HashSet<TicketBooking>(); 
        }

        public int ChairID { get; set; }
        public string Name { get; set; }
        public int Fare { get; set; }
        public string Type { get; set; }
        public bool Status { get; set; }
        
        public virtual ICollection<TicketBooking> TicketBookings { get; set; }
    }
}