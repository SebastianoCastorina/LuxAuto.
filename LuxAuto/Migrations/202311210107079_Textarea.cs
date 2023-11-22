namespace LuxAuto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Textarea : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ListaClienti", "Descrizione", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ListaClienti", "Descrizione");
        }
    }
}
