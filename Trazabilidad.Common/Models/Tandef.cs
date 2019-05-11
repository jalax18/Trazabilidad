

namespace Trazabilidad.Common.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using System.ComponentModel.DataAnnotations.Schema;



    public class Tandef

    {

        [Key]

        public int IdTandef { get; set; }
        public string Codtan { get; set; }
        public string Arttan { get; set; }
        public string Desart { get; set; }
        public int IdEstacion { get; set; }





    }
}
