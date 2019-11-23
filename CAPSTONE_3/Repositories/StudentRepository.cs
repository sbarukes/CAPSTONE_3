using CAPSTONE_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CAPSTONE_3.Repositories
{
    public class StudentRepository : BaseStudentRepository
    {
        RegistrationAppContext db = new RegistrationAppContext();

        //Polymorphic
        public override void CreateStudent(Student st)
        {
            try
            {
                var check = from s in db.Students
                            where s.Username == st.Username
                            select s;
                if (check.Count() > 0)
                {
                    db.Students.Add(st);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Username is already in use, please select another");
                }
            }
            catch (Exception)
            {
                throw new Exception("New student was not created");
            }
        }
    }
}