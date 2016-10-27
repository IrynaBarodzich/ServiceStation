namespace MigrationTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chiefs",
                c => new
                    {
                        ChiefID = c.Int(nullable: false, identity: true),
                        ChiefName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ChiefID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
            CreateTable(
                "dbo.EmployeeChiefs",
                c => new
                    {
                        Employee_EmployeeID = c.Int(nullable: false),
                        Chief_ChiefID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_EmployeeID, t.Chief_ChiefID })
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.Chiefs", t => t.Chief_ChiefID, cascadeDelete: true)
                .Index(t => t.Employee_EmployeeID)
                .Index(t => t.Chief_ChiefID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeChiefs", "Chief_ChiefID", "dbo.Chiefs");
            DropForeignKey("dbo.EmployeeChiefs", "Employee_EmployeeID", "dbo.Employees");
            DropIndex("dbo.EmployeeChiefs", new[] { "Chief_ChiefID" });
            DropIndex("dbo.EmployeeChiefs", new[] { "Employee_EmployeeID" });
            DropTable("dbo.EmployeeChiefs");
            DropTable("dbo.Employees");
            DropTable("dbo.Chiefs");
        }
    }
}
