﻿using System;
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

        public int ObtenerRendicion(string p)
        {
            var query =
             (from Rendicion in context.Rendiciones
              where Rendicion.FICHA_EMPLEADO == p
              orderby Rendicion.NumeroRendicion descending
              select new
              {
                  NumeroRendicion = Rendicion.NumeroRendicion
              }).FirstOrDefault();

            return query.NumeroRendicion;
        }

        public Rendicion ObtenerDocumentoRendicion(int idrendicion)
        {
            return context.Rendiciones.Where(
                p => p.Id == idrendicion).FirstOrDefault();
        }

        public IEnumerable<Rendicion> Listar()
        {
            return context.Rendiciones.ToList();
        }
    }
}
