namespace AccesoDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfiguracionInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MotivoGasto",
                c => new
                    {
                        MotivoID = c.Int(nullable: false, identity: true),
                        Motivo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MotivoID);
            
            CreateTable(
                "dbo.RendicionDetalle",
                c => new
                    {
                        RendicionDetalleID = c.Int(nullable: false, identity: true),
                        NumeroRendicion = c.Int(nullable: false),
                        MotivoID = c.Int(nullable: false),
                        FECHA_GASTO = c.DateTime(nullable: false),
                        SECUENCIA = c.Int(nullable: false),
                        TIPO_DOCTO = c.String(),
                        NUMERO_DOCTO = c.String(),
                        RAZON_SOCIAL = c.String(),
                        GLOSA = c.String(),
                        MONTO_LINEA = c.Double(nullable: false),
                        Rendicion_Id = c.Int(),
                    })
                .PrimaryKey(t => t.RendicionDetalleID)
                .ForeignKey("dbo.MotivoGasto", t => t.MotivoID, cascadeDelete: true)
                .ForeignKey("dbo.Rendicion", t => t.Rendicion_Id)
                .Index(t => t.MotivoID)
                .Index(t => t.Rendicion_Id);
            
            CreateTable(
                "dbo.Rendicion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumeroRendicion = c.Int(nullable: false),
                        FICHA_EMPLEADO = c.String(nullable: false),
                        FECHA_RENDICION_INI = c.DateTime(nullable: false),
                        FECHA_RENDICION_FIN = c.DateTime(nullable: false),
                        FONDO_INICIAL = c.Double(nullable: false),
                        TOTAL_GASTADO = c.Double(nullable: false),
                        ESTADO_PLANILLA = c.String(nullable: false),
                        FECHA_CAMBIO_ESTADO = c.DateTime(nullable: false),
                        FECHA_CREACION = c.DateTime(nullable: false),
                        GLOSA_GASTOS = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RendicionDetalle", "Rendicion_Id", "dbo.Rendicion");
            DropForeignKey("dbo.RendicionDetalle", "MotivoID", "dbo.MotivoGasto");
            DropIndex("dbo.RendicionDetalle", new[] { "Rendicion_Id" });
            DropIndex("dbo.RendicionDetalle", new[] { "MotivoID" });
            DropTable("dbo.Rendicion");
            DropTable("dbo.RendicionDetalle");
            DropTable("dbo.MotivoGasto");
        }
    }
}
