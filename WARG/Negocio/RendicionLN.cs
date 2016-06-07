using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidades;

namespace Negocio
{
    public class RendicionLN
    {
        RendicionDAO rendicionDAO = new RendicionDAO();

        public bool Insertar(Rendicion rendicion)
        {
            //rendicion.FICHA_EMPLEADO = "A";
            rendicion.ESTADO_PLANILLA = "PENDIENTE";

            rendicion.FECHA_CAMBIO_ESTADO = DateTime.Now;
            rendicion.FECHA_CREACION = DateTime.Now;

            var valor = obtenerUltimaRendicion(rendicion.FICHA_EMPLEADO);
            rendicion.NumeroRendicion = valor + 1;

            var i=1;
            double montoTotal = 0;
            foreach (var obj in rendicion.RendicionDetalle)
            {
                obj.FECHA_GASTO = DateTime.Now;
                obj.SECUENCIA = i++;
                obj.NumeroRendicion = rendicion.NumeroRendicion;
                montoTotal = montoTotal + obj.MONTO_LINEA;
            }

            rendicion.TOTAL_GASTADO = montoTotal;            
            return rendicionDAO.Insertar(rendicion);
        }

        private int obtenerUltimaRendicion(string p)
        {
           // throw new NotImplementedException();
            return rendicionDAO.ObtenerRendicion(p);
        }

        public IEnumerable<Rendicion> Listar()
        {
            return rendicionDAO.Listar();
        }

        public object Obtener(int id)
        {
            return rendicionDAO.ObtenerDocumentoRendicion(id);
        }
    }
}
