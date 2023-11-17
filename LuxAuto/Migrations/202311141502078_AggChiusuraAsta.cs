namespace LuxAuto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AggChiusuraAsta : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Asta", "DataChiusuraAsta", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Asta", "DataChiusuraAsta");
        }
    }
}
