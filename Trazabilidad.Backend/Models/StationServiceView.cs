using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trazabilidad.Backend.Models
{
    using Common.Models;

    public class StationServiceView:StationService
    {
        public HttpPostedFileBase ImageFile { get; set; }

    }
}