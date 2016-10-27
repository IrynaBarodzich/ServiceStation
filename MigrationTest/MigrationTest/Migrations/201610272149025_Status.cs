namespace MigrationTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chiefs", "ChiefStatus", c => c.String());
            DropColumn("dbo.Chiefs", "ChiefAge");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Chiefs", "ChiefAge", c => c.Int(nullable: false));
            DropColumn("dbo.Chiefs", "ChiefStatus");
        }
    }
}
