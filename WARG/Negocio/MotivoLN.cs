using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidades;

namespace Negocio
{
    public class MotivoLN
    {
        MotivoGastoDAO motivodao = new MotivoGastoDAO();

        public IEnumerable<MotivoGasto> Listar()
        {
            return motivodao.Listar();
        }

        public int Insertar(MotivoGasto motivo)
        {
            return motivodao.Insertar(motivo);
        }

        public bool Actualizar(MotivoGasto motivo)
        {
            return motivodao.Actualizar(motivo);
        }

        public bool Eliminar(int MotivoId)
        {
            return motivodao.Eliminar(MotivoId);
        }

        public MotivoGasto Obtener(int MotivoId)
        {
            return motivodao.Obtener(MotivoId);
        }
    }
}
