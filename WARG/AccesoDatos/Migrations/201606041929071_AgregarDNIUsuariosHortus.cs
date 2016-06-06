namespace AccesoDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarDNIUsuariosHortus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UsuarioHortus", "Dni", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UsuarioHortus", "Dni");
        }
    }
}
