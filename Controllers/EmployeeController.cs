using AutoMapper;
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
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            var db = new AssignmentEntities1();
            var data = db.Assigns.ToList();
          
            return View(Convert(data));
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Assign p)
        {
            if (ModelState.IsValid)
            {
                var db = new AssignmentEntities1();
                db.Assigns.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(p);
        }
        public AssignDTO Convert(Assign s)
        {
            var st = new AssignDTO()
            {
                R_Id = s.R_Id,
                EmpId = s.EmpId,
                Status = s.Status,
            };
            return st;
        }
        public Assign Convert(AssignDTO s)
        {
            var st = new Assign()
            {
                R_Id = s.R_Id,
                EmpId = s.EmpId,
                Status = s.Status,
            };
            return st;
        }
        public List<AssignDTO> Convert(List<Assign> students)
        {
            var sts = new List<AssignDTO>();
            foreach (var s in students)
            {
                sts.Add(Convert(s));
            }
            return sts;
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