using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WARG
{
    public class RendicionViewModel
    {
        public string PK_RENDICION { get; set; }
        public string ATRIBUTO1_CABECERA { get; set; }
        public string ATRIBUTO2_CABECERA { get; set; }
        public List<RendicionDetalleB> LISTA_DETALLE { get; set; }
    }

    public class RendicionCabecera
    {
        public string PK_RENDICION { get; set; }
        public string ATRIBUTO1_CABECERA { get; set; }
        public string ATRIBUTO2_CABECERA { get; set; }
        public List<RendicionDetalleB> DETALLERENDICION { get; set; }
    }

    public class RendicionDetalleB
    {
        public string PK_DETALLE { get; set; }
        public string ATRIBUTO1_DETALLE { get; set; }
        public string ATRIBUTO2_DETALLE { get; set; }
    }
}