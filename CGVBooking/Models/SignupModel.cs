using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CGVBooking.Models
{
    public class SignupModel
    {
        [Required(ErrorMessage = "Họ tên chưa nhập")]
        [DisplayName("Tên")]
        [MinLength(2, ErrorMessage = "Họ tên phải ít nhât 2 ký tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Số điện thoại chưa nhập")]
        [DisplayName("Số điện thoại")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^0\d{9,10}", ErrorMessage = "Số điện thoại không đúng định dạng")]
        [MinLength(10, ErrorMessage = "Số điện thoại phải ít nhất 10 số")]
        [MaxLength(11, ErrorMessage = "Số điện thoại phải tối đa 11 số")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email chưa nhập")]
        [DisplayName("Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email không đúng định dạng")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mật khẩu chưa nhập")]
        [DisplayName("Mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Xác nhận mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu chưa xác nhận")]
        [Compare("Password", ErrorMessage = "Mật khẩu không khớp")]
        public string ConfirmPassword { get; set; }
        
        [Required(ErrorMessage = "Ngày sinh chưa nhập")]
        [DisplayName("Ngày sinh")]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "01-01-1960", "01-01-2015", 
            ErrorMessage = "Ngày sinh phải từ 01-01-1960 đến 01-01-2015")]
        public DateTime BirthOfDate { get; set; }

        [Required(ErrorMessage = "Giới tính chưa chọn")]
        [DisplayName("Giới tính")]
        public string Sex { get; set; }

        public int Balance { get; set; }
    }
}