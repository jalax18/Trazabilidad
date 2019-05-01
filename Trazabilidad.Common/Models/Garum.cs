

namespace Trazabilidad.Common.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using System.ComponentModel.DataAnnotations.Schema;



    public class Garum

    {

        [Key]

        public int GarumId { get; set; }



        [Required(ErrorMessage = "The field {0} is requiered.")]

        [MaxLength(50, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]

        [Index("Garum_VerGarum_Index", IsUnique = true)]

        public string VerGarum { get; set; }

        public DateTime FechaGarum { get; set; }



        [JsonIgnore]

        public virtual ICollection<Station> Stations { get; set; }

    }
}
