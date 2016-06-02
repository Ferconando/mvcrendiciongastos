using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.Entity;

namespace AccesoDatos
{
    public class RendicionInitializer : DropCreateDatabaseIfModelChanges<RendicionContext>
    {
        protected override void Seed(RendicionContext context)
        {
            //var motivo = new List<MotivoGasto>{
            //    new MotivoGasto{Motivo="Desayuno"},
            //    new MotivoGasto{Motivo="Almuerzo"},
            //    new MotivoGasto{Motivo="Cena"}
            //};
            //motivo.ForEach(c => context.MotivoGastos.Add(c));

            context.MotivoGastos.Add(new MotivoGasto { Motivo = "Desayuno" });
            context.MotivoGastos.Add(new MotivoGasto { Motivo = "Almuerzo" });
            context.MotivoGastos.Add(new MotivoGasto { Motivo = "Cena" });

            context.SaveChanges();
        }
            
            
    }
}
