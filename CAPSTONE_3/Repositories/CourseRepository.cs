using CAPSTONE_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CAPSTONE_3.Repositories
{
    public class CourseRepository
    {
        RegistrationAppContext db = new RegistrationAppContext();

        public List<Course> GetAll()
        {
            var students = from c in db.Courses
                           select c;
            return students.ToList();
        }

        public List<CourseInstructorCount> CountCourses()
        {
            var courses = GetAll();
            var instructorCount =
                from c in courses
                group c by c.Instructor into insGroup
                select new CourseInstructorCount
                {
                    Instructor = insGroup.Key,
                    Count = insGroup.Count()
                };
            return instructorCount.ToList();
        }
    }
}