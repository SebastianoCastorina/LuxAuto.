namespace LuxAuto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Datetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Offerta", "DataOfferta", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Offerta", "DataOfferta", c => c.DateTime(storeType: "date"));
        }
    }
}
