

namespace Trazabilidad.Common.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using System.ComponentModel.DataAnnotations.Schema;



    public class Posdef

    {

        [Key]

        public int IdPosdef { get; set; }
        public string Posicion { get; set; }
        public string Numman { get; set; }
        public int IdEstacion { get; set; }






    }
}
