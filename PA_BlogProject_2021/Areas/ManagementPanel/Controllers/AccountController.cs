using PA_BlogProject_2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PA_BlogProject_2021.Areas.ManagementPanel.Controllers
{
    
    public class AccountController : Controller
    {
        BlogProjeContext db = new BlogProjeContext();

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string Name, string Email, string Password)
        {
            Users user = new Users();
            if (!String.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(Email) && !String.IsNullOrEmpty(Password))
            {
                user.UserName = Name;
                user.Email = Email;
                user.Password = Password;
                user.IsActive = true;
                user.RegisterDate = DateTime.Now;
                foreach (var item in db.Roles)
                {
                    if (item.RolName == "User")
                    {
                        user.RolId = item.RolId;
                    }
                }
                db.Users.Add(user);
                db.SaveChanges();


            }

            else
            {
                return View("Veriler boş geldi");
            }

            return RedirectToAction("Login", "Account");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Email, string Password)
        {
            Users user = db.Users.FirstOrDefault(u => u.Password == Password && u.Email == Email);
            if (user == null)
            {
                return RedirectToAction("Login");
            }
            if (user.RolId == 1)
            {
                Session["RolId"] = user.RolId;
                Session["KullanıcıAdı"] = user.UserName; //Session benim verdiğim değeri taşıyan bir key ve ben bu anahtara bir isim veriyorum bu isime de bir değer atıyorum 
                return RedirectToAction("Index", "Blogs", new { area = "ManagementPanel" });//ManagementPanel içindeki Blog controllera gitmen gerekiyor.
            }
            else
            {
                Session["RolId"] = user.RolId;
                Session["KullanıcıAdı"] = user.UserName; //Session benim verdiğim değeri taşıyan bir key ve ben bu anahtara bir isim veriyorum bu isime de bir değer atıyorum 
                return RedirectToAction("Index", "Home",new { area = "" });
            }

        }

        public ActionResult Logout()
        {
            Session.Clear(); // Sistemde varolan kullanıcıyı sessiondan çıkarabiliyorsun
            return RedirectToAction("Login");
        }
    }
}