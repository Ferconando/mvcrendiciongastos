namespace AccesoDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarUsuariosHortus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UsuarioHortus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NOMBRE = c.String(),
                        EMAIL = c.String(),
                        CARGO = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UsuarioHortus");
        }
    }
}
