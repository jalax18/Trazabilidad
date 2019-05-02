using System;
using System.Collections.Generic;
using System.Text;

namespace Trazabilidad.ViewModels
{
    using Models;

    public class StationViewModel
    {
        public Station Station
        {
            get;
            set;
        }

        public StationViewModel(Station Station)
        {
            this.Station = Station;
        }
    }
}
