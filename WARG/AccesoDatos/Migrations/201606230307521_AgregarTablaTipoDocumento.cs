namespace AccesoDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarTablaTipoDocumento : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoDocumento",
                c => new
                    {
                        TipoDocumentoID = c.Int(nullable: false, identity: true),
                        Documento = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TipoDocumentoID);
            
            AddColumn("dbo.RendicionDetalle", "TipoDocumentoID", c => c.Int(nullable: false));
            CreateIndex("dbo.RendicionDetalle", "TipoDocumentoID");
            AddForeignKey("dbo.RendicionDetalle", "TipoDocumentoID", "dbo.TipoDocumento", "TipoDocumentoID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RendicionDetalle", "TipoDocumentoID", "dbo.TipoDocumento");
            DropIndex("dbo.RendicionDetalle", new[] { "TipoDocumentoID" });
            DropColumn("dbo.RendicionDetalle", "TipoDocumentoID");
            DropTable("dbo.TipoDocumento");
        }
    }
}
