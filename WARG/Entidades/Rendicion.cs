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
       
        [Required]//NOT NULL
        public string FICHA_EMPLEADO { get; set; }
        
        [Required(ErrorMessage = "La fecha incial es requerido")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]        
        public DateTime FECHA_RENDICION_INI { get; set; }
        [Required(ErrorMessage = "La fecha final es requerido")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FECHA_RENDICION_FIN { get; set; }

        [Required(ErrorMessage = "El fondo inicial es requerido")]
        public double FONDO_INICIAL { get; set; }
        [Required(ErrorMessage = "El total gasto es requerido")]
        public double TOTAL_GASTADO { get; set; }
        [Required]//NOT NULL
        public string ESTADO_PLANILLA { get; set; }
        [Required]//NOT NULL
        public DateTime FECHA_CAMBIO_ESTADO { get; set; }
        [Required]//NOT NULL
        public DateTime FECHA_CREACION { get; set; }
        [Required(ErrorMessage = "La glosa es requerida")]
        public string GLOSA_GASTOS { get; set; }       
        
                
        // Creo el arreglo de Rendicion Detalle
        public virtual ICollection<RendicionDetalle> RendicionDetalle { get; set; }        
       
    }
}
