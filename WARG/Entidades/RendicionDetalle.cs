using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class RendicionDetalle
    {
        [Key]
        public int RendicionDetalleID { get; set; }
        //[MaxLength(100)]
        [Required]//NOT NULL
        public int NumeroPlanilla { get; set; }
        //[MaxLength(100)]
        [Required]//NOT NULL
        public DateTime FECHA_GASTO { get; set; }
        //[MaxLength(50)]
        [Required]//NOT NULL
        public string CONCEPTO_ITEM { get; set; }
        
        //public int SECUENCIA { get; set; }
        public string TIPO_DOCTO { get; set; }
        public string NUMERO_DOCTO { get; set; }
        public string RAZON_SOCIAL { get; set; }
        public string GLOSA { get; set; }
        public double MONTO_LINEA { get; set; }

        //Relacion con el padre
        public virtual Rendicion Rendicion { get; set; }
        public virtual List<MotivoGasto> MotivoGasto { get; set; }
    }
}
