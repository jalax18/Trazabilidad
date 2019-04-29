

namespace Trazabilidad.Common.Models
{
    using Newtonsoft.Json;

    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using System.ComponentModel.DataAnnotations.Schema;



    public class Mpecliente

    {

        [Key]

        public int MpeclienteId { get; set; }



        [Required(ErrorMessage = "The field {0} is requiered.")]

        [MaxLength(50, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]

        [Index("Mpecliente_VerMpecliente_Index", IsUnique = true)]

        public string VerMpecliente { get; set; }



        [JsonIgnore]

        public virtual ICollection<Station> Stations { get; set; }

    }
}
