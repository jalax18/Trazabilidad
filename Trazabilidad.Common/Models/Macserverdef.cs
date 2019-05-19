

namespace Trazabilidad.Common.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using System.ComponentModel.DataAnnotations.Schema;



    public class Macserverdef

    {

        [Key]

        public int Idmacserve { get; set; }
        public string linea { get; set; }
        public int IdEstacion { get; set; }





    }
}
