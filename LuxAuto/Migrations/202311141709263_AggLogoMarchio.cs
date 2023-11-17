namespace LuxAuto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AggLogoMarchio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Marchio", "Logo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Marchio", "Logo");
        }
    }
}
