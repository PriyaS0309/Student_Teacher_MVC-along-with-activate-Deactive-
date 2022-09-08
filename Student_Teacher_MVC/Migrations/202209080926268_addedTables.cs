namespace Student_Teacher_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Teacher_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Teachers", t => t.Teacher_ID, cascadeDelete: true)
                .Index(t => t.Teacher_ID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Teacher_ID", "dbo.Teachers");
            DropIndex("dbo.Students", new[] { "Teacher_ID" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
        }
    }
}
