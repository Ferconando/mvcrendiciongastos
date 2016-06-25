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

        public bool Actualizar(Rendicion rendicion)
        {
            context.Rendiciones.Attach(rendicion);
            context.Entry(rendicion).State = EntityState.Modified;
            return (context.SaveChanges() > 0);
        }

        public void Dispose()
        {
            if (context != null) context.Dispose();
        }

        public int ObtenerRendicion(string p)
        {
            var query =
             (from UsuarioHortus in context.Usuario
              where UsuarioHortus.EMAIL == p
              //orderby UsuarioHortus.correlativo descending
              select new
              {
                  correlativo = UsuarioHortus.correlativo
              }).FirstOrDefault();

            return query.correlativo;
        }

        public Rendicion ObtenerDocumentoRendicion(int idrendicion)
        {
            return context.Rendiciones.Where(
                p => p.Id == idrendicion).FirstOrDefault();
        }

        public IEnumerable<Rendicion> Listar(string usuarioLogueado)
        {
            //return context.Rendiciones.ToList();
            return context.Rendiciones.Where(
                p => p.FICHA_EMPLEADO == usuarioLogueado).ToList();
        }

        public void actualizarCorrelativoUsuario(int NumeroRendicion, string mail)
        {  
              var res = (from UsuarioHortus in context.Usuario
              where UsuarioHortus.EMAIL == mail
              select UsuarioHortus).FirstOrDefault();
              res.correlativo = NumeroRendicion;
               context.SaveChanges();             
              
        }

        public IEnumerable<Rendicion> ListarAll()
        {
            return context.Rendiciones.ToList();
        }

        public void actualizarEstadoRendicion(string estadoplanilla,int numerorendicion)
        {
            var res = (from Rendicion in context.Rendiciones
                       where Rendicion.NumeroRendicion == numerorendicion
                       select Rendicion).FirstOrDefault();
            res.ESTADO_PLANILLA = estadoplanilla;
            context.SaveChanges(); 
        }
    }
}
