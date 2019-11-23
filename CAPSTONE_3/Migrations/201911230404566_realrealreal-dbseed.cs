namespace CAPSTONE_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class realrealrealdbseed : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO COURSES (CourseName, Instructor) VALUES ('Intro To Politcs', 'Dave Mathews')");
            Sql("INSERT INTO COURSES (CourseName, Instructor) VALUES ('Intro To CS', 'Beth Parker')");
            Sql("INSERT INTO COURSES (CourseName, Instructor) VALUES ('Intro To Algebra', 'Beth Parker')");
            Sql("INSERT INTO COURSES (CourseName, Instructor) VALUES ('Intro To World History', 'Ariel Newgent')");
            Sql("INSERT INTO COURSES (CourseName, Instructor) VALUES ('Intro To US History', 'Ariel Newgent')");
            Sql("INSERT INTO COURSES (CourseName, Instructor) VALUES ('Intro To Chinese History', 'Ariel Newgent')");

            Sql("INSERT INTO STUDENTS (Username, Password, FirstName, LastName, Email, Phone, Address)" +
                " VALUES('arukes', 'Balrok34', 'Austin','Rukes','sbarukes@gmail.com','765-592-2466','1414 Hanball Lane Apt C')");
            Sql("INSERT INTO STUDENTS (Username, Password, FirstName, LastName, Email, Phone, Address)" +
                " VALUES('abool', 'Angel74', 'Abby','Rukes','arukes@gmail.com','111-111-111','1414 Hanball Lane Apt A')");
            Sql("INSERT INTO STUDENTS (Username, Password, FirstName, LastName, Email, Phone, Address)" +
                " VALUES('aint', 'Newb34', 'Austin','Newgent','sbarukes@gmail.com','111-111-111','1414 Hanball Lane Apt C')");
            Sql("INSERT INTO STUDENTS (Username, Password, FirstName, LastName, Email, Phone, Address)" +
                " VALUES('test1', 'test1', 'Austin','Rukes','sbarukes@gmail.com','111-111-111','1414 Hanball Lane Apt C')");
            Sql("INSERT INTO STUDENTS (Username, Password, FirstName, LastName, Email, Phone, Address)" +
                " VALUES('test2', 'test2', 'Austin','Rukes','sbarukes@gmail.com','111-111-111','1414 Hanball Lane Apt C')");
            Sql("INSERT INTO STUDENTS (Username, Password, FirstName, LastName, Email, Phone, Address)" +
                " VALUES('test3', 'test3', 'Austin','Rukes','sbarukes@gmail.com','111-111-111','1414 Hanball Lane Apt C')");
            Sql("INSERT INTO STUDENTS (Username, Password, FirstName, LastName, Email, Phone, Address)" +
                " VALUES('test4', 'test4', 'Austin','Rukes','sbarukes@gmail.com','111-111-111','1414 Hanball Lane Apt C')");
            Sql("INSERT INTO STUDENTS (Username, Password, FirstName, LastName, Email, Phone, Address)" +
                " VALUES('test5', 'test5', 'Austin','Rukes','sbarukes@gmail.com','111-111-111','1414 Hanball Lane Apt C')");
            Sql("INSERT INTO STUDENTS (Username, Password, FirstName, LastName, Email, Phone, Address)" +
                " VALUES('test6', 'test6', 'Austin','Rukes','sbarukes@gmail.com','111-111-111','1414 Hanball Lane Apt C')");
            Sql("INSERT INTO STUDENTS (Username, Password, FirstName, LastName, Email, Phone, Address)" +
                " VALUES('test7', 'test7', 'Austin','Rukes','sbarukes@gmail.com','111-111-111','1414 Hanball Lane Apt C')");
        }
        
        public override void Down()
        {
        }
    }
}
