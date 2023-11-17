namespace LuxAuto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelAsta : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Asta", "idAuto");
            AddForeignKey("dbo.Asta", "idAuto", "dbo.Autovettura", "idAuto");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Asta", "idAuto", "dbo.Autovettura");
            DropIndex("dbo.Asta", new[] { "idAuto" });
        }
    }
}
