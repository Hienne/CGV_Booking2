using CGVBooking.Common;
using CGVBooking.DAL;
using CGVBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CGVBooking.Common;
using System.Net;
using System.Data.Entity;
using System.IO;

namespace CGVBooking.Controllers
{
    public class UserController : Controller
    {
        private CGVDBContext db = new CGVDBContext();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        public ActionResult Login()
        {
            
            return View();
        }

        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            Session.Clear();

            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var resultByPhoneNum = dao.LoginByPhoneNumber(model.Account, model.Password);
                var resultByEmail = dao.LoginByEmail(model.Account, model.Password);

                if (resultByPhoneNum || resultByEmail)
                {
                    
                    var userSession = new UserLogin();
                    var user = resultByEmail == true ? dao.getUserByEmail(model.Account) : dao.getUserbyPhoneNumber(model.Account);
                    userSession.UserID = user.UserID;
                    userSession.UserName = user.Name;

                    Session.Add(CommonConstants.USER_SESSION, userSession);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không thành công");
                }
            }

            return View("Login");
        }

        public ActionResult Signup()
        {
            return View();
        }
        

        [HttpPost]
        public ActionResult Signup(SignupModel model)
        {
            var dao = new UserDAO();
            if (ModelState.IsValid)
            {
                if (dao.checkData(model))
                {
                    model.Balance = 100;
                    dao.Insert(model);
                    TempData["SignupSuccess"] = "Đăng kí thành công, bạn có thể đăng nhập ngay bây giờ.";
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng ký không thành công, số điện thoại hoặc email đã tồn tại");
                }

            }

            return View("Signup");
        }

        public ActionResult InforUser()
        {
            return View();
        }

        public ActionResult AccountInfor(int userID)
        {
            var userDAO = new UserDAO();
            var user = userDAO.getUserById(userID);
            return View(user);
        }

        public ActionResult StoryUser(int userID)
        {
            var userDAO = new UserDAO();
            
            return View(userDAO.getUserStory(userID));
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var u = db.Users.Find(user.UserID);

                if(user.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(user.ImageUpload.FileName);
                    string extenstion = Path.GetExtension(user.ImageUpload.FileName);
                    fileName = fileName + extenstion;


                    //user.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/img/UploadImages/"), fileName));
                    u.ImageUpload = user.ImageUpload;
                    u.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Uploads/"), fileName));
                    u.UserImage = "~/Uploads/" + fileName;

                    //u.ImageUpload = user.ImageUpload;
                    //string fileName = Path.GetFileName(u.ImageUpload.FileName);
                    //string filePath = "~/Uploads/" + fileName;
                    //u.ImageUpload.SaveAs(Server.MapPath(filePath));

                    //u.UserImage = filePath;

                }
                
                u.Sex = user.Sex;
                u.Name = user.Name;
                
                db.SaveChanges();

                return RedirectToAction("InforUser");
            }
            return View(user);
        }
    }
}