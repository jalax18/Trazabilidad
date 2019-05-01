

namespace Trazabilidad.Common.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using System.ComponentModel.DataAnnotations.Schema;



    public class Macserver

    {

        [Key]

        public int MacserverId { get; set; }



        [Required(ErrorMessage = "The field {0} is requiered.")]

        [MaxLength(50, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]

        [Index("Macserver_VerMacserver_Index", IsUnique = true)]

        public string VerMacserver { get; set; }

        public DateTime FechaMacserver { get; set; }

        [JsonIgnore]

        public virtual ICollection<Station> Stations { get; set; }

    }
}
