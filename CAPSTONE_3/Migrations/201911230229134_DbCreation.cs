namespace CAPSTONE_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Byte(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        CourseName = c.String(),
                        Description = c.String(),
                        Instructor = c.String(),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        RegistrationId = c.Byte(nullable: false, identity: true),
                        DateRegistered = c.DateTime(nullable: false),
                        Course_CourseId = c.Byte(),
                        Student_StudentId = c.Byte(),
                    })
                .PrimaryKey(t => t.RegistrationId)
                .ForeignKey("dbo.Courses", t => t.Course_CourseId)
                .ForeignKey("dbo.Students", t => t.Student_StudentId)
                .Index(t => t.Course_CourseId)
                .Index(t => t.Student_StudentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Byte(nullable: false, identity: true),
                        DateRegistered = c.DateTime(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Registrations", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.Registrations", "Course_CourseId", "dbo.Courses");
            DropIndex("dbo.Registrations", new[] { "Student_StudentId" });
            DropIndex("dbo.Registrations", new[] { "Course_CourseId" });
            DropTable("dbo.Students");
            DropTable("dbo.Registrations");
            DropTable("dbo.Courses");
        }
    }
}
