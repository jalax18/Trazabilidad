using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trazabilidad.Common.Models
{
    public class UltimasVersiones
    {
        [Key]

        public int IdVersiones { get; set; }


        [Required(ErrorMessage = "The field {0} is requiered.")]

        [MaxLength(50, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]

        [Index("UltimasVersiones_VersionMacserver_Index", IsUnique = true)]

        public string VersionMacserver { get; set; }

        public DateTime FechaVersionMacserver { get; set; }


        [Required(ErrorMessage = "The field {0} is requiered.")]

        [MaxLength(50, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]

        [Index("UltimasVersiones_VersionMaccliente_Index", IsUnique = true)]

        public string VersionMaccliente { get; set; }

        public DateTime FechaVersionMaccliente { get; set; }


        [Required(ErrorMessage = "The field {0} is requiered.")]

        [MaxLength(50, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]

        [Index("UltimasVersiones_VersionMaccliente_Index", IsUnique = true)]

        public string VersionMpecliente { get; set; }

        public DateTime FechaVersionMpecliente { get; set; }

                     
        [Required(ErrorMessage = "The field {0} is requiered.")]

        [MaxLength(50, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]

        [Index("UltimasVersiones_VersionXad_Index", IsUnique = true)]

        public string VersionXad { get; set; }

        public DateTime FechaVersionXad { get; set; }

        [Required(ErrorMessage = "The field {0} is requiered.")]

        [MaxLength(50, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]

        [Index("UltimasVersiones_VersionGarum_Index", IsUnique = true)]

        public string VersionGarum { get; set; }

        public DateTime FechaVersionGarum { get; set; }





        [JsonIgnore]

        public virtual ICollection<Station> Stations { get; set; }

    }

}

