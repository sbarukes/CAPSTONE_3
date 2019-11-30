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
            db.Database.ExecuteSqlCommand($"INSERT INTO Registrations(Course_CourseId, Student_StudentId) VALUES({co.CourseId}, {st.StudentId})");
            //Registration reg = new Registration();
            //reg.Student = st;
            //reg.Course = co;
            //reg.DateRegistered = DateTime.Now;
            //db.Registrations.Add(reg);
            //db.SaveChanges();
        }

        public void DeleteRegistration(int regId)
        {
            db.Database.ExecuteSqlCommand($"DELETE FROM Registrations WHERE RegistrationId = {regId}");
            //var deleter = GetRegistrationss().Where(x => x.RegistrationId == regId).FirstOrDefault();
            //db.Registrations.Remove(deleter);
            //db.SaveChanges();
        }

        public MainModel Get(Student st)
        {
            return Getter(st);
        }

        public void TempDelete()
        {
            
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
                    if (r.Course.CourseName == c.CourseName)
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