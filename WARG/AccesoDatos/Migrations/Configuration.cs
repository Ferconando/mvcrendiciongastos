namespace AccesoDatos.Migrations
{
    using Entidades;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AccesoDatos.RendicionContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AccesoDatos.RendicionContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            context.MotivoGastos.AddOrUpdate(
                p=> p.Motivo,
                new MotivoGasto { Motivo="Desayuno"},
                new MotivoGasto { Motivo="Almuerzo"},
                new MotivoGasto { Motivo="Cena"},
                new MotivoGasto { Motivo = "Hotel" },
                new MotivoGasto { Motivo = "Telefono" },
                new MotivoGasto { Motivo = "Correspondencia" },
                new MotivoGasto { Motivo = "Taxis" },
                new MotivoGasto { Motivo = "Avion" },
                new MotivoGasto { Motivo = "Buses" },
                new MotivoGasto { Motivo = "Fotocopias" }
                );

            context.TipoDocumento.AddOrUpdate(
                p => p.Documento,
                new TipoDocumento { Documento = "Factura" },
                new TipoDocumento { Documento = "Boleta" },
                new TipoDocumento { Documento="Ticket"},
                new TipoDocumento { Documento = "SinDocumento" }
                );

            context.Usuario.AddOrUpdate(                
                new UsuarioHortus {NOMBRE="usuarioSemilla", CARGO="Sistemas", Dni="00000000",
                    fechaCreacion=DateTime.Now, EMAIL="usuario@correo.com", correlativo=100000000}                
                );
            //
        }
    }
}
