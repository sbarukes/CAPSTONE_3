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
                if (check.Count() == 0)
                {
                    db.Students.Add(st);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Username is already in use, please select another");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("New student was not created" + ": " + ex.Message);
            }
        }

        public List<Student> GetAll()
        {
            var students = from s in db.Students
                           select s;
            return students.ToList();
        }

        public bool LoginStudent(string username, string password)
        {
            var check = from s in db.Students
                        where s.Username == username
                        && s.Password == password
                        select s;
            if(check.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void UpdateStudentAccount(Student st)
        {
            var check = from s in db.Students
                        where s.Username == st.Username
                        && s.Password == st.Password
                        select s;

            foreach(var student in check)
            {
                student.Username = st.Username;
                student.Password = st.Password;
            }

            db.SaveChanges();
        }
    }
}