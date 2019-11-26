using CAPSTONE_3.Models;
using CAPSTONE_3.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CAPSTONE_3.Controllers
{
    public class LoginController : Controller
    {
        StudentRepository _student = new StudentRepository();

        // GET: Login
        public ActionResult Index()
        {
            ViewBag.LoginFail = Session["message"];
            return View();
        }

        [HttpPost]
        public ActionResult LoginCheck(LoginViewModel vm)
        {
            var lCheck = _student.LoginStudent(vm.UserName, vm.Password);
            if (lCheck)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Session["message"] = "Your username or password is incorrect";
                return RedirectToAction("Index", "Login");
            }
        }
    }
}