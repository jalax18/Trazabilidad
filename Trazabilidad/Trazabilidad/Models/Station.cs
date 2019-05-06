using System;
using System.Collections.Generic;
using System.Text;

namespace Trazabilidad.Models
{
    public class Station
    {
            public int StationId { get; set; }
            public string NameStation { get; set; }
            public string VersionMacserver { get; set; }
            public string VersionMaccliente { get; set; }
            public string VersionMpecliente { get; set; }
            public string VersionXad { get; set; }
            public string VersionGarum { get; set; }
            public string TipoEstacion { get; set; }
            public DateTime FechaEstacion { get; set; }
            public string ImagePath { get; set; }
            public bool Server { get; set; }
            public int NumeroTpvs { get; set; }


    }
}
