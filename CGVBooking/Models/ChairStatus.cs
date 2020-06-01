using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CGVBooking.Models
{
    public class ChairStatus
    {
        public int ChairID { get; set; }
        public string ChairName { get; set; }
        public int ChairFare { get; set; }
        public string ChairType { get; set; }
        public bool status { get; set; }
    }
}