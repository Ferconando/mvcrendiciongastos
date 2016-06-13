namespace AccesoDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelacionIdentity_TablaUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UsuarioHortus", "correlativo", c => c.Int(nullable: false));
            AddColumn("dbo.UsuarioHortus", "Idusuario", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UsuarioHortus", "Idusuario");
            DropColumn("dbo.UsuarioHortus", "correlativo");
        }
    }
}
