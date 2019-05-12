

namespace Trazabilidad.Common.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using System.ComponentModel.DataAnnotations.Schema;

    public class Station
    {

        [Key]

        public int StationId { get; set; }



        [Display(Name = "Name Station")]

        [Required(ErrorMessage = "The field {0} is requiered.")]

        [MaxLength(50, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]

        public string NameStation { get; set; }

       
        public int MacserverId { get; set; }

        [JsonIgnore]

        public virtual Macserver Macserver { get; set; }

               

        public int MacclienteId { get; set; }

        [JsonIgnore]

        public virtual Maccliente Maccliente { get; set; }


        public int MpeclienteId { get; set; }

        [JsonIgnore]

        public virtual Mpecliente Mpeccliente { get; set; }

        public int XadId { get; set; }

        [JsonIgnore]

        public virtual Xad Xad { get; set; }

        public int GarumId { get; set; }

        [JsonIgnore]

        public virtual Garum Garum { get; set; }

        public int StationTypeId { get; set; }

        [JsonIgnore]

        public virtual StationType StationType { get; set; }




        public DateTime FechaEstacion { get; set; }

        public String Concentrador { get; set; }

        public string Gestion { get; set; }


    }
}
