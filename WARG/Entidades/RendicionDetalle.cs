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
        public int NumeroRendicion { get; set; }
        [Required]//NOT NULL
        public int MotivoID { get; set; }
        //[MaxLength(100)]
        [Required]//NOT NULL
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FECHA_GASTO { get; set; }
        [Required]//NOT NULL
        public int SECUENCIA { get; set; }
        public string TIPO_DOCTO { get; set; }
        public string NUMERO_DOCTO { get; set; }
        public string RAZON_SOCIAL { get; set; }
        public string GLOSA { get; set; }
        [Required]//NOT NULL
        public double MONTO_LINEA { get; set; }

        //Relacion
        public virtual Rendicion Rendicion { get; set; }
        public virtual MotivoGasto MotivoGasto { get; set; }
    }
}
