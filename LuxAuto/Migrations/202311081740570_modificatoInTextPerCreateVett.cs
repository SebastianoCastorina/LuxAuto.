namespace LuxAuto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificatoInTextPerCreateVett : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Autovettura", "DatiBase", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.Autovettura", "SpecificheTecniche", c => c.String(unicode: false, storeType: "text"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Autovettura", "SpecificheTecniche", c => c.String());
            AlterColumn("dbo.Autovettura", "DatiBase", c => c.String());
        }
    }
}
