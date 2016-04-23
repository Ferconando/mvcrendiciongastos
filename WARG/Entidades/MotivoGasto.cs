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
        public int MotivoID { get; set; }
        [Required]//NOT NULL
        public string Motivo { get; set; }

        //Relacion
        public virtual ICollection<RendicionDetalle> RendicionDetalle { get; set; }

    }
}
