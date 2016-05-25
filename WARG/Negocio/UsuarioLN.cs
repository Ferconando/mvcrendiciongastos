using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioLN
    {
        UsuarioDAO usuariodao = new UsuarioDAO();

        public IEnumerable<UsuarioHortus> Listar()
        {
            return usuariodao.Listar();
        }

        public bool Insertar(UsuarioHortus motivo)
        {
            return usuariodao.Insertar(motivo);
        }

        public bool Actualizar(UsuarioHortus motivo)
        {
            return usuariodao.Actualizar(motivo);
        }

        public bool Eliminar(int MotivoId)
        {
            return usuariodao.Eliminar(MotivoId);
        }

        public UsuarioHortus Obtener(int MotivoId)
        {
            return usuariodao.Obtener(MotivoId);
        }
    }
}
