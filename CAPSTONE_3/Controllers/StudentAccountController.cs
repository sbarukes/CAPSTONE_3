﻿using CAPSTONE_3.Models;
using CAPSTONE_3.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CAPSTONE_3.Controllers
{
    public class StudentAccountController : Controller
    {
        StudentRepository _student = new StudentRepository();
        // GET: StudentAccount
        public ActionResult Index()
        {
            ViewBag.AccountCreateFail = Session["error"];
            return View();
        }

        public ActionResult _Update()
        {
            return View(Globals.LoggedInUser);
        }

        [HttpPost]
        public ActionResult Update(Student st)
        {
            _student.UpdateStudentAccount(st);
            Globals.LoggedInUser = _student.GetAll().Where(x => x.Username == st.Username).FirstOrDefault();
            return RedirectToAction("_Update", "StudentAccount");
        }

        [HttpPost]
        public ActionResult Create(Student st)
        {
            try
            {
                _student.CreateStudent(st);
                return RedirectToAction("index", "Login");
            }
            catch(Exception ex)
            {
                Session["error"] = ex.Message;
                return RedirectToAction("Index", "StudentAccount");
            }
        }
    }
}