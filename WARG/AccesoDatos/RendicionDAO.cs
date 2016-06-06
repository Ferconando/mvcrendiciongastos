using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Entidades;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

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

        public string ObtenerRendicion(string p)
        {
            // Extraemos el ObjectContext del DbContext (a partir de Entity Framework 4.1)
            //var objectContext = ((IObjectContextAdapter)context).ObjectContext;

            // Ejecutamos una sentencia de Entity SQL que recupere todos los clientes
            //string sqlQuery = "SELECT top(1) NumeroRendicion FROM Rendicion where FICHA_EMPLEADO=@p order by NumeroRendicion desc ";
            //var result = context.Database.SqlQuery<Rendicion>(
            //     "SELECT top(1) NumeroRendicion FROM Rendicion where FICHA_EMPLEADO=@P0 order by NumeroRendicion desc",
            //p);
            DbSqlQuery<Rendicion> data = context.Rendiciones.SqlQuery("SELECT top(1) NumeroRendicion FROM Rendicion where FICHA_EMPLEADO=(((System.Data.Entity.Infrastructure.DbRawSqlQuery<Entidades.Rendicion>)(data))._internalQuery)._parameters[0] order by NumeroRendicion desc", p);
   
            //var clientes = new ObjectQuery<Rendicion>(sqlQuery, objectContext);
            return data.ToString();
            //return context.Rendiciones.Where(
            //    C => C.FICHA_EMPLEADO == p).MaxAsync();
        }
    }
}
