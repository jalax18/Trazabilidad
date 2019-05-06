

namespace Trazabilidad.Common.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using System.ComponentModel.DataAnnotations.Schema;

    public class StationService
    {

        [Key]

        public int StationId { get; set; }



        [Display(Name = "Estacion de Servicio")]

        [Required(ErrorMessage = "The field {0} is requiered.")]

        [MaxLength(50, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]

        [Index("StationService_NameStation_Index", IsUnique = true)]

        public string NameStation { get; set; }

        [Display(Name = "Version Macserver")]

        [Required(ErrorMessage = "The field {0} is requiered.")]

        [MaxLength(50, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]

        public string VersionMacserver { get; set; }


        [Display(Name = "Version Maccliente")]

        [Required(ErrorMessage = "The field {0} is requiered.")]

        [MaxLength(50, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]
        public string VersionMaccliente { get; set; }

        [Display(Name = "Version Mpecliente")]

        [Required(ErrorMessage = "The field {0} is requiered.")]

        [MaxLength(50, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]
        public string VersionMpecliente { get; set; }

        [Display(Name = "Version XAD")]

        [Required(ErrorMessage = "The field {0} is requiered.")]

        [MaxLength(50, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]
        public string VersionXad { get; set; }



        [Display(Name = "Version de Garum")]

        [Required(ErrorMessage = "The field {0} is requiered.")]

        [MaxLength(50, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]
        public string VersionGarum { get; set; }


        [Display(Name = "Tipo de Estacion")]

        [Required(ErrorMessage = "The field {0} is requiered.")]

        [MaxLength(50, ErrorMessage = "The field {0} only can contains a maximum of {1} characters lenght.")]
        public String TipoEstacion { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaEstacion { get; set; }

        public string ImagePath { get; set; }


        [Display(Name = "Servidor XAD")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        public bool Server { get; set; }


        [Display(Name = "Nº TPVS")]
        [Required(ErrorMessage = "The field {0} is requiered.")]
        public int  NumeroTpvs { get; set; }


    }
}
