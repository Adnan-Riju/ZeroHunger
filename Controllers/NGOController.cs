using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using System.Web.Security;
using ZeroHungerAssignment.DTO;
using ZeroHungerAssignment.EF;

namespace ZeroHungerAssignment.Controllers
{
    public class NGOController : Controller
    {
        // GET: NGO
        public ActionResult Index()
        {
            var db = new AssignmentEntities1();
            var data=db.Requests.Where(a=>a.Status=="").ToList();
            
            return View(data);




        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new AssignmentEntities1();
            var data = db.Requests.Find(id);
            return View(data);
        }


        [HttpPost]
        public ActionResult Edit(Request d)
        {
            var db = new AssignmentEntities1();
            var ex = db.Requests.Find(d.R_Id);
            ex.AssignEmployee = d.AssignEmployee;
            ex.Status = d.Status;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Confirm(int id)
        {
            var db = new AssignmentEntities1();
            var data = db.Requests.Find(id);
            return View(data);
        }


        [HttpPost]
        public ActionResult Confirm(Request d)
        {
            var db = new AssignmentEntities1();
            var ex = db.Requests.Find(d.R_Id);
            ex.AssignEmployee = d.AssignEmployee;
            ex.Status = d.Status;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CancelProduct(int id)
        {
            var db = new AssignmentEntities1();
            var ex = db.Requests.Find(id);
            db.Requests.Remove(ex);
            db.SaveChanges();
            return RedirectToAction("Index");
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

    }
}