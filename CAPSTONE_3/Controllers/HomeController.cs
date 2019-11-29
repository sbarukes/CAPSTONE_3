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

        public ActionResult Index()
        {
            var model = _r.Get((Student)Session["currentUser"]);
            return View(model);
        }

        //Abstracts the logic from PublicGet
        
    }
}