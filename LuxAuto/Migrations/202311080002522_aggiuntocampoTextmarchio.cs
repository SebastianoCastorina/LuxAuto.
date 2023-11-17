namespace LuxAuto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aggiuntocampoTextmarchio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Marchio", "BreveStoria", c => c.String(unicode: false, storeType: "text"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Marchio", "BreveStoria");
        }
    }
}
