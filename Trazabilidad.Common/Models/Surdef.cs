

namespace Trazabilidad.Common.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using System.ComponentModel.DataAnnotations.Schema;



    public class Surdef

    {

        [Key]

        public int IdSurdef { get; set; }
        public string Possur { get; set; }
        public string Manguera { get; set; }
        public string Desart { get; set; }
        public string Codsur { get; set; }
        public int IdEstacion { get; set; }





    }
}
