using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ZeroHungerAssignment.DTO;
using ZeroHungerAssignment.EF;

namespace ZeroHungerAssignment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }




        [HttpPost]
        public ActionResult SignUp(User obj)
        {

            var db = new AssignmentEntities1();
            db.Users.Add(obj);
            db.SaveChanges();
            return RedirectToAction("Login");
            
          
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }




        [HttpPost]
        public ActionResult Login(User objuser)
        {

            // if (ModelState.IsValid)
            {
                using (AssignmentEntities1 db = new AssignmentEntities1())
                {
                    var obj = db.Users.Where(a => a.UserName.Equals(objuser.UserName)
                    && a.Password.Equals(objuser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        if (obj.Role == "Admin")
                        {
                            return RedirectToAction("NGO", "Index");
                        }
                        else if (obj.Role == "Employee")
                        {
                            return RedirectToAction("Employee", "Index");
                        }
                        else if (obj.Role == "Restaurant")
                        {
                            return RedirectToAction("Restaurant", "Index");
                        }
                       
                    
                   
                    }


                }

            }
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }


        public UserDTO Convert(User u)
        {
            var us = new UserDTO()
            {
                Id = u.Id,
                Name = u.Name,
                UserName = u.UserName,
                Role = u.Role,
                Password = u.Password,


            };
            return us;
        }
        public User Convert(UserDTO u)
        {
            var us = new User()
            {
                Id = u.Id,
                Name = u.Name,
                UserName = u.UserName,
                Role = u.Role,
                Password = u.Password,
                

            };
            return us;
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("SignUp", "Home");
        }
    }
}