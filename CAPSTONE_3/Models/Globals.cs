using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CAPSTONE_3.Models
{
    public static class Globals
    {
        public static Student LoggedInUser = (Student)HttpContext.Current.Session["currentUser"];
    }
}