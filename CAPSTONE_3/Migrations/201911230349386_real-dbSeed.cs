namespace CAPSTONE_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class realdbSeed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "DateCreated", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
