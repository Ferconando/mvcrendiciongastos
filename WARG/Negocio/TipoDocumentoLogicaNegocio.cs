using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidades;

namespace Negocio
{
    public class TipoDocumentoLogicaNegocio
    {
        TipoDocumentoDAO tipodocumentodao = new TipoDocumentoDAO();

        public IEnumerable<TipoDocumento> Listar()
        {
            return tipodocumentodao.Listar();
        }

        public bool Insertar(TipoDocumento tipodocumnto)
        {
            return tipodocumentodao.Insertar(tipodocumnto);
        }

        public bool Actualizar(TipoDocumento tipodocumnto)
        {
            return tipodocumentodao.Actualizar(tipodocumnto);
        }

        public bool Eliminar(int TipoDocumentoID)
        {
            return tipodocumentodao.Eliminar(TipoDocumentoID);
        }

        public TipoDocumento Obtener(int TipoDocumentoID)
        {
            return tipodocumentodao.Obtener(TipoDocumentoID);
        }
    }
    
}
