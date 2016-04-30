using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.Entity;

namespace AccesoDatos
{
    public class MotivoGastoDAO : IDisposable
    {
        RendicionContext context = new RendicionContext();

        public IEnumerable<MotivoGasto> Listar()
        {
            return context.MotivoGastos.ToList();
        }

        public MotivoGasto Obtener(int id)
        {
            return context.MotivoGastos.Where(
                p => p.MotivoID == id).SingleOrDefault();
        }

        public bool Insertar(MotivoGasto motivo)
        {
            context.MotivoGastos.Add(motivo);
            return (context.SaveChanges() > 0);
        }

        public bool Actualizar(MotivoGasto motivo)
        {            
            context.MotivoGastos.Attach(motivo);
            context.Entry(motivo).State = EntityState.Modified;
            return (context.SaveChanges() > 0);
        }

        public bool Eliminar(int id)
        {
            var motivo = Obtener(id);
            if (motivo == null) return false;
            //Debido a que el producto fue creado fuera del 
            //contexto actual, es necesario indicarle a EF
            //que lo agregue al contexto
            context.MotivoGastos.Attach(motivo);
            context.MotivoGastos.Remove(motivo);
            return (context.SaveChanges() > 0);
        }

       

        public void Dispose()
        {
            if (context != null) context.Dispose();
        }
    }
}
