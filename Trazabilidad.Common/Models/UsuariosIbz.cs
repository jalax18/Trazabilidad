using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trazabilidad.Common.Models
{
    class UsuariosIbz
    {
        [Key]
        public int IdUsario { get; set; }

        public string nombre { get; set; }
        
    }
}
