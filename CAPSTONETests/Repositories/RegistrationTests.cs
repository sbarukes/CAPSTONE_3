using Microsoft.VisualStudio.TestTools.UnitTesting;
using CAPSTONE_3.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationApp.Tests
{
    [TestClass()]
    public class RegistrationTests
    {
        [TestMethod()]
        public void GetAllCoursesTest()
        {
            CourseRepository _c = new CourseRepository();
            var test = _c.GetAll().ToList();
            Assert.IsTrue(test.Count > 0);
        }
    }
}