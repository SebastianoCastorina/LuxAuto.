namespace LuxAuto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ListaClientifull2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ListaClienti",
                c => new
                    {
                        idCliente = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cognome = c.String(),
                        Email = c.String(),
                        NumeroTelefono = c.String(),
                    })
                .PrimaryKey(t => t.idCliente);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ListaClienti");
        }
    }
}
