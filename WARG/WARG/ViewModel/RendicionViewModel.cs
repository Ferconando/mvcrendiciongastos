using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WARG
{
    public class RendicionViewModel
    {
        public int Id { get; set; }
        public int NumeroRendicion { get; set; }
        public string FICHA_EMPLEADO { get; set; }
        public DateTime FECHA_RENDICION_INI { get; set; }
        public DateTime FECHA_RENDICION_FIN { get; set; }
        public double FONDO_INICIAL { get; set; }
        public double TOTAL_GASTADO { get; set; }
        public string ESTADO_PLANILLA { get; set; }
        public DateTime FECHA_CAMBIO_ESTADO { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public string GLOSA_GASTOS { get; set; } 
        //public string PK_RENDICION { get; set; }
        //public string ATRIBUTO1_CABECERA { get; set; }
        //public string ATRIBUTO2_CABECERA { get; set; }
        public List<RendicionDetalleB> LISTA_DETALLE { get; set; }
    }

    public class RendicionCabecera
    {
        public int Id { get; set; }        
        public int NumeroRendicion { get; set; }        
        public string FICHA_EMPLEADO { get; set; }        
        public DateTime FECHA_RENDICION_INI { get; set; }        
        public DateTime FECHA_RENDICION_FIN { get; set; }
        public double FONDO_INICIAL { get; set; }        
        public double TOTAL_GASTADO { get; set; }        
        public string ESTADO_PLANILLA { get; set; }        
        public DateTime FECHA_CAMBIO_ESTADO { get; set; }        
        public DateTime FECHA_CREACION { get; set; }        
        public string GLOSA_GASTOS { get; set; } 
        //public string PK_RENDICION { get; set; }
        //public string ATRIBUTO1_CABECERA { get; set; }
        //public string ATRIBUTO2_CABECERA { get; set; }
        public List<RendicionDetalleB> DETALLERENDICION { get; set; }
    }

    public class RendicionDetalleB
    {
        public int RendicionDetalleID { get; set; }
        public int NumeroRendicion { get; set; }
        public int MotivoID { get; set; }
        public DateTime FECHA_GASTO { get; set; }
        public int SECUENCIA { get; set; }
        public string TIPO_DOCTO { get; set; }
        public string NUMERO_DOCTO { get; set; }
        public string RAZON_SOCIAL { get; set; }
        public string GLOSA { get; set; }
        public double MONTO_LINEA { get; set; }

        //public string PK_DETALLE { get; set; }
        //public string ATRIBUTO1_DETALLE { get; set; }
        //public string ATRIBUTO2_DETALLE { get; set; }
    }
}