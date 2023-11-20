using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHungerAssignment.EF;
using ZeroHungerAssignment.DTO;
using System.Web.Security;

namespace ZeroHungerAssignment.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        public ActionResult Index()
        {
            User loggedInUser = (User)Session["logged"];


            if (loggedInUser != null && loggedInUser.Role == "Admin")
            {

                ViewBag.name = loggedInUser.Name;
                ViewBag.id = loggedInUser.Id;
            }
            var db = new AssignmentEntities1();
            var data = db.Requests.ToList();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Request, RequestDTO>();
            });
            var mapper = new Mapper(config);
            var data2 = mapper.Map<List<RequestDTO>>(data);
            return View(Convert(data));

        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Request p)
        {
            if (ModelState.IsValid)
            {
                var db=new AssignmentEntities1();
                db.Requests.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index"); 
            }

            return View(p);
        }
        public RequestDTO Convert(Request s)
        {
            var st = new RequestDTO()
            {
                RestaurantId=s.RestaurantId,
                R_Id=s.R_Id,
                R_Name = s.R_Name,
                IteamName = s.IteamName,
                Quantity = s.Quantity,
                AssignEmployee = s.AssignEmployee,
               
                ExDate = s.ExDate,
                Location = s.Location,
                
            };
            return st;
        }
        public Request Convert(RequestDTO s)
        {
            var st = new Request()
            {
                RestaurantId = s.RestaurantId,
                R_Id = s.R_Id,
                R_Name = s.R_Name,
                IteamName = s.IteamName,
                Quantity = s.Quantity,
                AssignEmployee = s.AssignEmployee,
                Status = s.Status,
                ExDate = s.ExDate,
                Location = s.Location,
            };
            return st;
        }
        public List<RequestDTO> Convert(List<Request> students)
        {
            var sts = new List<RequestDTO>();
            foreach (var s in students)
            {
                sts.Add(Convert(s));
            }
            return sts;
        }
        public ActionResult History()
        {
            var db = new AssignmentEntities1();
            var data = db.Requests.ToList();
            return View(data);

        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("SignUp", "Home");
        }

        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult AssignEmpl()
        {
            var db = new AssignmentEntities1();
            var data = db.Requests.ToList();
            return View(data);

        }
        
    }

}