namespace CAPSTONE_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBSeed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "DateCreated", c => c.DateTime(nullable: false));


        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
