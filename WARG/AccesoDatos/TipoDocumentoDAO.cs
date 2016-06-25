using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.Entity;

namespace AccesoDatos
{
    public class TipoDocumentoDAO: IDisposable
    {
        RendicionContext context = new RendicionContext();

        public IEnumerable<TipoDocumento> Listar()
        {
            return context.TipoDocumento.ToList();
        }

        public TipoDocumento Obtener(int id)
        {
            return context.TipoDocumento.Where(
                p => p.TipoDocumentoID == id).SingleOrDefault();
        }

        public bool Insertar(TipoDocumento tipodocumento)
        {
            context.TipoDocumento.Add(tipodocumento);
            return (context.SaveChanges() > 0);
        }

        public bool Actualizar(TipoDocumento tipodocumento)
        {
            context.TipoDocumento.Attach(tipodocumento);
            context.Entry(tipodocumento).State = EntityState.Modified;
            return (context.SaveChanges() > 0);
        }

        public bool Eliminar(int id)
        {
            var tipodocumento = Obtener(id);
            if (tipodocumento == null) return false;            
            context.TipoDocumento.Attach(tipodocumento);
            context.TipoDocumento.Remove(tipodocumento);
            return (context.SaveChanges() > 0);
        }



        public void Dispose()
        {
            if (context != null) context.Dispose();
        }
    }
}
