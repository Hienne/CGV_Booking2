using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CGVBooking.Models
{
    public class TicketBooking
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TicketBookingID { get; set; }
        
        public int ShowTimesID { get; set; }

        public int ChairID { get; set; }

        public int UserID { get; set; }

        public virtual User User { get; set; }
        public virtual ShowTimes ShowTimes { get; set; }
        public virtual Chair Chair { get; set; }
    }
}