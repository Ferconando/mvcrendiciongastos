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
            //rendicion.FECHA_RENDICION_FIN = DateTime.Now;
            //rendicion.FECHA_RENDICION_INI = DateTime.Now;

            var i=1;
            foreach (var obj in rendicion.RendicionDetalle)
            {
                obj.FECHA_GASTO = DateTime.Now;
                obj.SECUENCIA = i++;
            }

            return rendicionDAO.Insertar(rendicion);
        }
    }
}
