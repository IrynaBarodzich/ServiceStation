namespace MigrationTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Age : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chiefs", "ChiefAge", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Chiefs", "ChiefAge");
        }
    }
}
