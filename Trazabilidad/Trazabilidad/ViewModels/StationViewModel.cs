//await Application.Current.MainPage.Navigation.PopAsync();

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
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Views;
    public class StationViewModel
    {
        #region Properties
        public Station Station
        {
            get;
            set;
        }

        public ObservableCollection<Fpardia> Fpardia
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

        #endregion

        #region Command
        public ICommand VerenmapaCommand
        {
            get
            {
                return new RelayCommand(Verenmapa);
            }
        }

        public ICommand MasInfoCommand
        {
            get
            {
                return new RelayCommand(MasInfo);
            }
        }



        #endregion

        #region Methods
        private async void  Verenmapa()
        {

            MainViewModel.GetInstance().Maps = new MapsViewModel();
            await App.Navigator.PushAsync(new MapsPage());
            // await App.Navigator.PopAsync();
        }

        private async void MasInfo()
        {
            await App.Navigator.PushAsync(new MasinfoPage());
        }
        #endregion

        public StationViewModel(Station Station)
        {
            this.Station = Station;

            Fpardia = new ObservableCollection<Fpardia>(
                    MainViewModel.GetInstance().FpardiaList.Where(
                        a => a.IdEstacion == Station.StationId));

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
