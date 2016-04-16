using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class MotivoGasto
    {
        [Key]
        [Required]//NOT NULL
        public int idMotivo { get; set; }        
        [Required]//NOT NULL
        public int Motivo { get; set; }

        //Relacion con el padre
        public virtual RendicionDetalle RendicionDetalle { get; set; }

    }
}