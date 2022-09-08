namespace Student_Teacher_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedIsActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "IsActive", c => c.Boolean(nullable: false));
            DropColumn("dbo.Teachers", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "IsActive", c => c.Boolean(nullable: false));
            DropColumn("dbo.Students", "IsActive");
        }
    }
}
