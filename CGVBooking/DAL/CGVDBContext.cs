using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CGVBooking.Models;
using CGVBooking.Entity;

namespace CGVBooking.DAL
{
    public class CGVDBContext : DbContext
    {
        public CGVDBContext() : base("CGVDBContext")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Chair> Chairs { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<TicketBooking> TicketBookings { get; set; }
        public DbSet<ShowTimes> ShowTimes { get; set; }
    }
}