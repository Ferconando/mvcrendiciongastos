            using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class Rendicion
    {
        [Key]
        public int Id { get; set; }
        [Required]//NOT NULL
        public int NumeroRendicion { get; set; }                
        //[MaxLength(50)]
        [Required]//NOT NULL
        public string FICHA_EMPLEADO { get; set; }
        [Required]//NOT NULL
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FECHA_RENDICION_INI { get; set; }
        [Required]//NOT NULL
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FECHA_RENDICION_FIN { get; set; }
               
        public double FONDO_INICIAL { get; set; }
        [Required]//NOT NULL
        public double TOTAL_GASTADO { get; set; }
        [Required]//NOT NULL
        public string ESTADO_PLANILLA { get; set; }
        [Required]//NOT NULL
        public DateTime FECHA_CAMBIO_ESTADO { get; set; }
        [Required]//NOT NULL
        public DateTime FECHA_CREACION { get; set; }
        [Required]//NOT NULL
        public string GLOSA_GASTOS { get; set; }       
        
                
        // Creo el arreglo de Rendicion Detalle
        public virtual ICollection<RendicionDetalle> RendicionDetalle { get; set; }        
       
    }
}
