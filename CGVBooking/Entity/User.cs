using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CGVBooking.Models
{
    public class User
    {
        public User()
        {
            TicketBookings = new HashSet<TicketBooking>();
            UserImage = "~/Content/img/UploadImages/icon-profile-cgv.png";
        }

        //id người dùng
        public int UserID { get; set; }

        //tên người dùng
        [DisplayName("Tên tài khoản")]
        public string Name { get; set; }

        //số điện thoại người dùng
        [DisplayName("Số điện thoại")]
        public string PhoneNumber { get; set; }

        //mật khẩu người dùng
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }

        //email người dùng
        public string Email { get; set; }

        //ngày sinh người dùng
        [DataType(DataType.Date)]
        [DisplayName("Năm sinh")]
        public DateTime BirthOfDate { get; set; }

        //giới tính người dùng
        [DisplayName("Giới tính")]
        public string Sex { get; set; }

        //số dư tài khoản người dùng
        [DisplayName("Tài khoản")]
        public int Balance { get; set; }

        [DisplayName("Avata")]
        public string UserImage { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        public virtual ICollection<TicketBooking> TicketBookings { get; set; }
    }
}