namespace LuxAuto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AggPrezzoAttuale : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Asta", "PrezzoAttuale", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Asta", "PrezzoAttuale");
        }
    }
}
