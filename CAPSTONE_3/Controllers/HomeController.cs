using CAPSTONE_3.Models;
using CAPSTONE_3.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CAPSTONE_3.Controllers
{
    public class HomeController : Controller
    {
        CourseRepository _c = new CourseRepository();
        RegistrationRepository _r = new RegistrationRepository();
        StudentRepository _s = new StudentRepository();

        public ActionResult Index()
        {
            var model = Getter();
            return View(model);
        }

        private MainModel Getter()
        {
            var courses = _c.GetAll();
            var stu = _s.GetAll();
            var regs = _r.GetRegistrationsByStudent((Student)Session["currentUser"]);

            foreach(var r in regs)
            {
                foreach(var c in courses.ToList())
                {
                    if(r.Course.CourseId == c.CourseId)
                    {
                        courses.Remove(c);
                    }
                }
            }

            var model = new MainModel();
            model.Courses = courses;
            model.Registrations = regs;
            return model;
        }
    }
}