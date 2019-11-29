namespace CAPSTONE_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reg_seed : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Registrations (Course_CourseId, Student_StudentId) VALUES (25,13)");
            Sql("INSERT INTO Registrations (Course_CourseId, Student_StudentId) VALUES (27,13)");
            Sql("INSERT INTO Registrations (Course_CourseId, Student_StudentId) VALUES (28,13)");

            Sql("INSERT INTO Registrations (Course_CourseId, Student_StudentId) VALUES (25,3)");
            Sql("INSERT INTO Registrations (Course_CourseId, Student_StudentId) VALUES (27,3)");
            Sql("INSERT INTO Registrations (Course_CourseId, Student_StudentId) VALUES (29,3)");
            Sql("INSERT INTO Registrations (Course_CourseId, Student_StudentId) VALUES (30,3)");

            Sql("INSERT INTO Registrations (Course_CourseId, Student_StudentId) VALUES (30,6)");
            Sql("INSERT INTO Registrations (Course_CourseId, Student_StudentId) VALUES (29,6)");
            Sql("INSERT INTO Registrations (Course_CourseId, Student_StudentId) VALUES (25,6)");
        }
        
        public override void Down()
        {
        }
    }
}
