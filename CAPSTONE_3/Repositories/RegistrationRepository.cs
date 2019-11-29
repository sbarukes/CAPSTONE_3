using CAPSTONE_3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CAPSTONE_3.Repositories
{
    public class RegistrationRepository
    {
        RegistrationAppContext db = new RegistrationAppContext();

        public List<Registration> GetRegistrationsByStudent(Student st)
        {
            var regs = from r in db.Registrations
                       where r.Student.StudentId == st.StudentId
                       select r;
            var returnRegs = regs.Include(reg => reg.Course)
                .Include(reg => reg.Student).ToList();
            return returnRegs;
        }

        public List<Registration> GetRegistrationss()
        {
            var regs = from r in db.Registrations
                       select r;
            return regs.ToList();
        }

        public void CreateRegistration(Student st, Course co)
        {
            Registration reg = new Registration
            {
                Student = st,
                Course = co,
                DateRegistered = DateTime.Now
            };
            db.Registrations.Add(reg);
            db.SaveChanges();
        }

        public void DeleteRegistration(Registration reg)
        {
            
            db.Registrations.Remove(reg);
            db.SaveChanges();
        }

        public MainModel Get(Student st)
        {
            return Getter(st);
        }

        private MainModel Getter(Student st)
        {
            CourseRepository _c = new CourseRepository();
            RegistrationRepository _r = new RegistrationRepository();
            StudentRepository _s = new StudentRepository();
            var courses = _c.GetAll();
            var stu = _s.GetAll();
            var regs = _r.GetRegistrationsByStudent(st);

            foreach (var r in regs)
            {
                foreach (var c in courses.ToList())
                {
                    if (r.Course.CourseId == c.CourseId)
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