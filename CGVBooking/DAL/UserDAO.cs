using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CGVBooking.Models;

namespace CGVBooking.DAL
{
    public class UserDAO
    {
        CGVDBContext db = null;
        public UserDAO()
        {
            db = new CGVDBContext();
        }

        public bool checkData(SignupModel model)
        {
            var listUser = db.Users.ToList();
            foreach(var x in listUser)
            {
                if (x.PhoneNumber == model.PhoneNumber || x.Email == model.Email)
                    return false;
            }
            return true;
        }

        public void Insert(SignupModel model)
        {
            User user = new User();
            user.Name = model.Name;
            user.Password = model.Password;
            user.PhoneNumber = model.PhoneNumber;
            user.Sex = model.Sex;
            user.Email = model.Email;
            user.BirthOfDate = model.BirthOfDate;
            user.Balance = model.Balance;

            db.Users.Add(user);
            db.SaveChanges();
           
        }

        public void Update(int giave, int userID)
        {
            var user = db.Users.Find(userID);
            user.Balance -= giave;
            db.SaveChanges();
           
        }

        public bool LoginByPhoneNumber(string userPhoneNumber, string Password)
        {
            var result = db.Users.Count(x => x.PhoneNumber == userPhoneNumber && x.Password == Password);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool LoginByEmail(string userEmail, string Password)
        {
            var result = db.Users.Count(x => x.Email == userEmail && x.Password == Password);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        

        public User getUserbyPhoneNumber(string userPhoneNumber)
        {
            return db.Users.SingleOrDefault(x => x.PhoneNumber == userPhoneNumber);
        }

        public User getUserByEmail(string email)
        {
            return db.Users.SingleOrDefault(x => x.Email == email);
        }
        
        public User getUserById(int UserID)
        {
            return db.Users.Find(UserID);
        }


        public List<UserStory> getUserStory(int userID)
        {
            
            List<Chair> chair = db.Chairs.ToList();
            List<Film> film = db.Films.ToList();
            List<ShowTimes> showtime = db.ShowTimes.ToList();
            List<TimeSlot> timeslot = db.TimeSlots.ToList();
            List<TicketBooking> ticketbooking = db.TicketBookings.ToList();

            var storyUserRecord = (
                                   from c in chair
                                   from f in film
                                   from s in showtime
                                   from ti in timeslot
                                   from ticket in ticketbooking
                                   where ticket.UserID == userID
                                   && c.ChairID == ticket.ChairID
                                   && s.ShowTimesID == ticket.ShowTimesID
                                   && ti.TimeSlotID == s.TimeSlotID
                                   && f.FilmID == s.FilmID
                                   select new UserStory
                                   {
                                       TicketBookingID = ticket.TicketBookingID,
                                       ChairName = c.Name,
                                       FilmName = f.Name,
                                       FilmPoster = f.Poster,
                                       ShowTimeDate = s.Date,
                                       TimeSlot = ti.Time
                                   }).ToList();
            return storyUserRecord;
        }

    }
}