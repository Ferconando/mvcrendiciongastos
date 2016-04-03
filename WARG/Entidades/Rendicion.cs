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
        [Required]//NOT NULL
        public int RendicionID { get; set; }
        //Llave Foranea
        [Required]//NOT NULL
        public int NumeroPLanillaID { get; set; }
        //[MaxLength(50)]
        [Required]//NOT NULL
        public string FICHA_EMPLEADO { get; set; }
        [Required]//NOT NULL
        public DateTime FECHA_RENDICION_INI { get; set; }
        [Required]//NOT NULL
        public DateTime FECHA_RENDICION_FIN { get; set; }
        //Llave Foranea       
        [Required]//NOT NULL
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
        [Required]//NOT NULL
        public string GLOSA_MOVILIDAD { get; set; }
        [Required]//NOT NULL
        public string PERIODO { get; set; }
                
        // Creo el arreglo de Peliculas
        public virtual List<RendicionDetalle> RendicionDetalle { get; set; }
       // public virtual Director Director { get; set; }
    }
}
