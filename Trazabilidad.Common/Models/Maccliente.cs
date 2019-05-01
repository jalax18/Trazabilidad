

namespace Trazabilidad.Common.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using System.ComponentModel.DataAnnotations.Schema;



    public class Maccliente

    {

        [Key]

        public int MacclienteId { get; set; }



        [Required(ErrorMessage = "The field {0} is requiered.")]

        [MaxLength(50, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]

        [Index("Maccliente_VerMaccliente_Index", IsUnique = true)]

        public string VerMaccliente { get; set; }

        public DateTime FechaMaccliente { get; set; }


        [JsonIgnore]

        public virtual ICollection<Station> Stations { get; set; }

    }
}
