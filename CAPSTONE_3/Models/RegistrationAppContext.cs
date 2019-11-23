using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CAPSTONE_3.Models
{
    public class RegistrationAppContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Grades { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public RegistrationAppContext() : base("RegistrationAppDatabase")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<RegistrationAppContext>());
        }
    }
}