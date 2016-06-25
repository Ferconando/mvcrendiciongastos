using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoDocumento
    {
        [Key]
        [Required]//NOT NULL
        public int TipoDocumentoID { get; set; }

        [Required]//NOT NULL
        public string Documento { get; set; }

        //Relacion
        public virtual ICollection<RendicionDetalle> RendicionDetalle { get; set; }
    }
}
