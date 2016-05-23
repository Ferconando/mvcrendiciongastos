using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Entidades;

namespace AccesoDatos
{
    public class RendicionDAO:IDisposable
    {
        RendicionContext context = new RendicionContext();

        public bool Insertar(Rendicion rendicion)
        {
            context.Rendiciones.Add(rendicion);
            return (context.SaveChanges() > 0);
        }

        public void Dispose()
        {
            if (context != null) context.Dispose();
        }
    }
}
