using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CGVBooking.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Yêu cầu nhập tên tài khoản/email")]
        [DisplayName("Tài khoản")]
        public string Account { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
        [DisplayName("Mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [DisplayName("Nhớ mật khẩu")]
        public bool RememberMe { set; get; }
    }
}