using System;
using System.Collections.Generic;
using System.Text;

namespace Trazabilidad.ViewModels
{
    using Models;
    using System.Linq;
    using Xamarin.Forms;
    using ViewModels;
    using System.Collections.ObjectModel;

    public class StationViewModel
    {
        public Station Station
        {
            get;
            set;
        }

        public ObservableCollection<Macserverdef> Macserverdef
        {
            get;
            set;
        }

        public ObservableCollection<Artdef> Artdef
        {
            get;
            set;
        }

        public ObservableCollection<Tandef> Tandef
        {
            get;
            set;
        }

        public ObservableCollection<Posdef> Posdef
        {
            get;
            set;
        }

        public ObservableCollection<Surdef> Surdef
        {
            get;
            set;
        }

        public StationViewModel(Station Station)
        {
            this.Station = Station;
            Macserverdef = new ObservableCollection<Macserverdef>(
                     MainViewModel.GetInstance().MacserverdefList.Where(
                         a => a.IdEstacion == Station.StationId));

            Artdef = new ObservableCollection<Artdef>(
                     MainViewModel.GetInstance().ArtdefList.Where(
                         a => a.IdEstacion == Station.StationId));

            Tandef = new ObservableCollection<Tandef>(
                     MainViewModel.GetInstance().TandefList.Where(
                         a => a.IdEstacion == Station.StationId));

            Posdef = new ObservableCollection<Posdef>(
                     MainViewModel.GetInstance().PosdefList.Where(
                         a => a.IdEstacion == Station.StationId));

            Surdef = new ObservableCollection<Surdef>(
                    MainViewModel.GetInstance().SurdefList.Where(
                        a => a.IdEstacion == Station.StationId));

            //  Artdef1 = new ObservableCollection<Artdef>(MainViewModel.GetInstance().ArtdefList);



        }
    }
}
