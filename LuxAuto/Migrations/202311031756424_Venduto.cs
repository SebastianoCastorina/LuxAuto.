namespace LuxAuto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Venduto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Autovettura", "HasVenduta", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Autovettura", "HasVenduta");
        }
    }
}
