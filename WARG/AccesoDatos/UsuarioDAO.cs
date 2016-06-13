using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class UsuarioDAO
    {
        RendicionContext context = new RendicionContext();

        public IEnumerable<UsuarioHortus> Listar()
        {
            return context.Usuario.ToList();
        }

        public UsuarioHortus Obtener(int id)
        {
            return context.Usuario.Where(
                p => p.ID == id).SingleOrDefault();
        }

        public bool Insertar(UsuarioHortus usuario)
        {
            context.Usuario.Add(usuario);
            return (context.SaveChanges() > 0);
        }

        public bool Actualizar(UsuarioHortus usuario)
        {
            context.Usuario.Attach(usuario);
            context.Entry(usuario).State = EntityState.Modified;
            return (context.SaveChanges() > 0);
        }

        public bool Eliminar(int id)
        {
            var usuario = Obtener(id);
            if (usuario == null) return false;
            //Debido a que el usuario fue creado fuera del 
            //contexto actual, es necesario indicarle a EF
            //que lo agregue al contexto
            context.Usuario.Attach(usuario);
            context.Usuario.Remove(usuario);
            return (context.SaveChanges() > 0);
        }



        public void Dispose()
        {
            if (context != null) context.Dispose();
        }

        public int ObtenerProximoCorrelativo()
        {
            var query =
             (from UsuarioHortus in context.Usuario              
              orderby UsuarioHortus.correlativo descending
              select new
              {
                  correlativo = UsuarioHortus.correlativo
              }).FirstOrDefault();           

            return query.correlativo;
        }
    }
}
