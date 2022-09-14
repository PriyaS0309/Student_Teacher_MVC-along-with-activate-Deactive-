namespace Student_Teacher_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedTables : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Students", name: "T_ID", newName: "Teacher_ID");
            RenameIndex(table: "dbo.Students", name: "IX_T_ID", newName: "IX_Teacher_ID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Students", name: "IX_Teacher_ID", newName: "IX_T_ID");
            RenameColumn(table: "dbo.Students", name: "Teacher_ID", newName: "T_ID");
        }
    }
}
