using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;

namespace AccesoDatos
{
    public class RendicionContext:DbContext
    {
        public RendicionContext(): base("name=RendicionContext")
        {
        }

        public virtual DbSet<Rendicion> Rendiciones { get; set; }
        public virtual DbSet<RendicionDetalle> RendicioneDetalle { get; set; }
        public virtual DbSet<MotivoGasto> MotivoGastos { get; set; }
        public virtual DbSet<UsuarioHortus> Usuario { get; set; }
        

        //Cambiando convension de nombres de tablas a singular en EF
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {         
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
