namespace AccesoDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FechaCreacionUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UsuarioHortus", "fechaCreacion", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UsuarioHortus", "fechaCreacion");
        }
    }
}
