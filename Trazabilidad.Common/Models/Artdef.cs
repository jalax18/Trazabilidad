

namespace Trazabilidad.Common.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using System.ComponentModel.DataAnnotations.Schema;



    public class Artdef

    {

        [Key]

        public int IdArtdef { get; set; }
        public string Codart { get; set; }
        public string Desart { get; set; }
        public int IdArticu { get; set; }
        public int Idgrupo { get; set; }
        public int Idsubfam { get; set; }
        public int Idfam { get; set; }
        public int IdEstacion { get; set; }




    }
}
