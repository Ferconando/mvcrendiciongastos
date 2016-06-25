namespace WARG.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WARG.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WARG.Models.ApplicationDbContext";
        }

        protected override void Seed(WARG.Models.ApplicationDbContext context)
        {
            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);
            if (!context.Roles.Any(r => r.Name == "Administracion"))
            {
                var role = new IdentityRole { Name = "Administracion" };
                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "Cobranzas"))
            {
                var role = new IdentityRole { Name = "Cobranzas" };
                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "Comercial"))
            {
                var role = new IdentityRole { Name = "Comercial" };
                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "Contabilidad"))
            {
                var role = new IdentityRole { Name = "Contabilidad" };
                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "Compras"))
            {
                var role = new IdentityRole { Name = "Compras" };
                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "Registros"))
            {
                var role = new IdentityRole { Name = "Registros" };
                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "Sistemas"))
            {
                var role = new IdentityRole { Name = "Sistemas" };
                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "PostVenta"))
            {
                var role = new IdentityRole { Name = "PostVenta" };
                manager.Create(role);
            }
        }
    }
}
