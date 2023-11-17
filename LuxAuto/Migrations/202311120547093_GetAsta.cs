namespace LuxAuto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GetAsta : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Asta", "PrezzoBase", c => c.Decimal(storeType: "money"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Asta", "PrezzoBase");
        }
    }
}
