namespace LuxAuto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UltimaOfferta : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Asta", "UltimaOfferta", c => c.String());
            DropColumn("dbo.Asta", "PrezzoAttuale");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Asta", "PrezzoAttuale", c => c.String());
            DropColumn("dbo.Asta", "UltimaOfferta");
        }
    }
}
