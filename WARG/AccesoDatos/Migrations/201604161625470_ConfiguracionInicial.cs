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
                        idMotivo = c.Int(nullable: false, identity: true),
                        Motivo = c.Int(nullable: false),
                        RendicionDetalle_RendicionDetalleID = c.Int(),
                    })
                .PrimaryKey(t => t.idMotivo)
                .ForeignKey("dbo.RendicionDetalle", t => t.RendicionDetalle_RendicionDetalleID)
                .Index(t => t.RendicionDetalle_RendicionDetalleID);
            
            CreateTable(
                "dbo.RendicionDetalle",
                c => new
                    {
                        RendicionDetalleID = c.Int(nullable: false, identity: true),
                        NumeroPlanilla = c.Int(nullable: false),
                        FECHA_GASTO = c.DateTime(nullable: false),
                        CONCEPTO_ITEM = c.String(nullable: false),
                        SECUENCIA = c.Int(nullable: false),
                        TIPO_DOCTO = c.String(),
                        NUMERO_DOCTO = c.String(),
                        RAZON_SOCIAL = c.String(),
                        GLOSA = c.String(),
                        MONTO_LINEA = c.Double(nullable: false),
                        Rendicion_RendicionID = c.Int(),
                    })
                .PrimaryKey(t => t.RendicionDetalleID)
                .ForeignKey("dbo.Rendicion", t => t.Rendicion_RendicionID)
                .Index(t => t.Rendicion_RendicionID);
            
            CreateTable(
                "dbo.Rendicion",
                c => new
                    {
                        RendicionID = c.Int(nullable: false, identity: true),
                        NumeroPLanillaID = c.Int(nullable: false),
                        FICHA_EMPLEADO = c.String(nullable: false),
                        FECHA_RENDICION_INI = c.DateTime(nullable: false),
                        FECHA_RENDICION_FIN = c.DateTime(nullable: false),
                        FONDO_INICIAL = c.Double(nullable: false),
                        TOTAL_GASTADO = c.Double(nullable: false),
                        ESTADO_PLANILLA = c.String(nullable: false),
                        FECHA_CAMBIO_ESTADO = c.DateTime(nullable: false),
                        FECHA_CREACION = c.DateTime(nullable: false),
                        GLOSA_GASTOS = c.String(nullable: false),
                        GLOSA_MOVILIDAD = c.String(nullable: false),
                        PERIODO = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RendicionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MotivoGasto", "RendicionDetalle_RendicionDetalleID", "dbo.RendicionDetalle");
            DropForeignKey("dbo.RendicionDetalle", "Rendicion_RendicionID", "dbo.Rendicion");
            DropIndex("dbo.RendicionDetalle", new[] { "Rendicion_RendicionID" });
            DropIndex("dbo.MotivoGasto", new[] { "RendicionDetalle_RendicionDetalleID" });
            DropTable("dbo.Rendicion");
            DropTable("dbo.RendicionDetalle");
            DropTable("dbo.MotivoGasto");
        }
    }
}
