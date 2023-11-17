namespace LuxAuto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Asta",
                c => new
                    {
                        idAsta = c.Int(nullable: false, identity: true),
                        idAuto = c.Int(),
                    })
                .PrimaryKey(t => t.idAsta);
            
            CreateTable(
                "dbo.Offerta",
                c => new
                    {
                        idOfferta = c.Int(nullable: false, identity: true),
                        OffertaFatta = c.Decimal(storeType: "money"),
                        DataOfferta = c.DateTime(storeType: "date"),
                        idUser = c.Int(),
                        idAuto = c.Int(),
                        idAsta = c.Int(),
                    })
                .PrimaryKey(t => t.idOfferta)
                .ForeignKey("dbo.Asta", t => t.idAsta)
                .ForeignKey("dbo.Autovettura", t => t.idAuto)
                .ForeignKey("dbo.User", t => t.idUser)
                .Index(t => t.idUser)
                .Index(t => t.idAuto)
                .Index(t => t.idAsta);
            
            CreateTable(
                "dbo.Autovettura",
                c => new
                    {
                        idAuto = c.Int(nullable: false, identity: true),
                        NomeModello = c.String(),
                        Foto = c.String(),
                        DatiBase = c.String(),
                        Colore = c.String(),
                        Chilometraggio = c.String(),
                        AnnoImmatricolazione = c.String(),
                        Potenza = c.String(),
                        Città = c.String(),
                        Carburante = c.String(),
                        Prezzo = c.Decimal(storeType: "money"),
                        SpecificheTecniche = c.String(),
                        idMarchio = c.Int(),
                        HasAsta = c.Boolean(),
                        HasEpoca = c.Boolean(),
                        Foto1 = c.String(),
                        Foto2 = c.String(),
                        Foto3 = c.String(),
                        Foto4 = c.String(),
                        Foto5 = c.String(),
                        Foto6 = c.String(),
                    })
                .PrimaryKey(t => t.idAuto)
                .ForeignKey("dbo.Marchio", t => t.idMarchio)
                .Index(t => t.idMarchio);
            
            CreateTable(
                "dbo.Marchio",
                c => new
                    {
                        idMarchio = c.Int(nullable: false, identity: true),
                        NomeMarchio = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.idMarchio);
            
            CreateTable(
                "dbo.OptionalAuto",
                c => new
                    {
                        idOptInAuto = c.Int(nullable: false, identity: true),
                        idAuto = c.Int(),
                        idOptional = c.Int(),
                    })
                .PrimaryKey(t => t.idOptInAuto)
                .ForeignKey("dbo.Autovettura", t => t.idAuto)
                .ForeignKey("dbo.Optional", t => t.idOptional)
                .Index(t => t.idAuto)
                .Index(t => t.idOptional);
            
            CreateTable(
                "dbo.Optional",
                c => new
                    {
                        idOptional = c.Int(nullable: false, identity: true),
                        NomeOptional = c.String(),
                    })
                .PrimaryKey(t => t.idOptional);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        idUser = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cognome = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Indirizzo = c.String(),
                        Ruolo = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.idUser);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Offerta", "idUser", "dbo.User");
            DropForeignKey("dbo.OptionalAuto", "idOptional", "dbo.Optional");
            DropForeignKey("dbo.OptionalAuto", "idAuto", "dbo.Autovettura");
            DropForeignKey("dbo.Offerta", "idAuto", "dbo.Autovettura");
            DropForeignKey("dbo.Autovettura", "idMarchio", "dbo.Marchio");
            DropForeignKey("dbo.Offerta", "idAsta", "dbo.Asta");
            DropIndex("dbo.OptionalAuto", new[] { "idOptional" });
            DropIndex("dbo.OptionalAuto", new[] { "idAuto" });
            DropIndex("dbo.Autovettura", new[] { "idMarchio" });
            DropIndex("dbo.Offerta", new[] { "idAsta" });
            DropIndex("dbo.Offerta", new[] { "idAuto" });
            DropIndex("dbo.Offerta", new[] { "idUser" });
            DropTable("dbo.User");
            DropTable("dbo.Optional");
            DropTable("dbo.OptionalAuto");
            DropTable("dbo.Marchio");
            DropTable("dbo.Autovettura");
            DropTable("dbo.Offerta");
            DropTable("dbo.Asta");
        }
    }
}
