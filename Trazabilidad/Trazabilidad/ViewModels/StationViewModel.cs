using System;
using System.Collections.Generic;
using System.Text;

namespace Trazabilidad.ViewModels
{
    using Models;
    using System.Linq;

    public class StationViewModel
    {
        public Station Station
        {
            get;
            set;
        }

       // public string MacserverName { get; set; }

        public StationViewModel(Station Station)
        {
            this.Station = Station;

         /*    var macserver = MainViewModel.GetInstance().StationTypeList.
                                       Where(l => l.StationTypeId == Station.MacserverId).
                                       FirstOrDefault();
            if (macserver != null)
            {
                this.MacserverName = macserver.StationTypeName;
            }*/

        }
    }
}
