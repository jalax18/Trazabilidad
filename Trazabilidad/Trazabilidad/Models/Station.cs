using System;
using System.Collections.Generic;
using System.Text;

namespace Trazabilidad.Models
{
    public class Station
    {

            public int StationId { get; set; }
            public string NameStation { get; set; }
            public int MacserverId { get; set; }
            public int MacclienteId { get; set; }
            public int MpeclienteId { get; set; }
            public int XadId { get; set; }
            public int GarumId { get; set; }
            public int StationTypeId { get; set; }
            public DateTime FechaEstacion { get; set; }
        
    }
}
