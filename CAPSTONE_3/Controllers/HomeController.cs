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
        RegistrationRepository _r = new RegistrationRepository();
        CourseRepository _c = new CourseRepository();

        public ActionResult Index()
        {
            _r.TempDelete();
            var model = _r.Get(Globals.LoggedInUser);
            return View(model);
        }
        
        public ActionResult Delete(int regId)
        {
            _r.DeleteRegistration(regId);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Add(int cId)
        {
            var user = Globals.LoggedInUser;
            var course = _c.GetAll().Where(x => x.CourseId == cId).FirstOrDefault();
            _r.CreateRegistration(user, course);
            return RedirectToAction("Index", "Home");
        }

    }
}