using CAPSTONE_3.Models;
using System;
using System.Collections.Generic;
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
            return regs.ToList();
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
    }
}