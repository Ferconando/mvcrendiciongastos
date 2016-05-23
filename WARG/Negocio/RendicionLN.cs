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
            return rendicionDAO.Insertar(rendicion);
        }
    }
}
