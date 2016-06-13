using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class UsuarioHortus
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public string EMAIL { get; set; }
        public string CARGO { get; set; }
        public string Dni { get; set; }
        public int correlativo { get; set; }
        public string Idusuario { get; set; }
        public DateTime fechaCreacion { get; set; }
    }
}
