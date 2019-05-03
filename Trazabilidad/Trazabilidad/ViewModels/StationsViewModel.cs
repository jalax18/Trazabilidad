﻿namespace Trazabilidad.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Net.Http;
    // using System.Net.Http.Headers;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Helpers;
    using Models;
    using Services;
    using Xamarin.Forms;
    using ViewModels;
    public class StationsViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private ObservableCollection<StationItemViewModel> stations;
      //  private List<Station> stationsList;
        private bool isRefreshing;
        private string filter;
        #endregion

        #region Properties
        public ObservableCollection<StationItemViewModel> Stations
        {
            get { return this.stations; }
            set { SetValue(ref this.stations, value); }
        }
      /*  public List<Station> StationsList
        {
            get { return this.stationsList; }
            set { SetValue(ref this.stationsList, value); }
        }*/

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public string Filter
        {
            get { return this.filter; }
            set
            {
                SetValue(ref this.filter, value);
                this.Search();
            }
        }
        #endregion

        #region Constructors
        public StationsViewModel()
        {
            this.apiService = new ApiService();
            // this.Test();
            this.LoadStations();
        }


        #endregion

        #region Methods
        private async void LoadStations()
        {
            this.IsRefreshing = true;
            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    connection.Message,
                    Languages.Accept);
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            var response = await this.apiService.GetList<Station>(
                "http://2.139.147.209:1601",
                "/api",
                "/stationservices");

            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    response.Message,
                    Languages.Accept);
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            MainViewModel.GetInstance().StationList= (List<Station>)response.Result;
          //  this.StationsList = (List<Station>)response.Result;
            this.Stations = new ObservableCollection<StationItemViewModel>(this.ToStationItemViewModel());
            this.IsRefreshing = false;
        }
        #endregion

        #region Methods
		 #region Methods
        private IEnumerable<StationItemViewModel> ToStationItemViewModel()
        {
            return MainViewModel.GetInstance().StationList.Select(l => new StationItemViewModel
            {
                NameStation = l.NameStation,
                VersionMacserver = l.VersionMacserver,
                VersionMaccliente = l.VersionMaccliente,
                VersionMpecliente = l.VersionMpecliente,
                VersionXad = l.VersionXad,
                VersionGarum = l.VersionGarum,
                TipoEstacion = l.TipoEstacion,
                FechaEstacion = l.FechaEstacion,
            });
        }



        #endregion


        #endregion

        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadStations);
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }

        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Stations = new ObservableCollection<StationItemViewModel>(ToStationItemViewModel());

            }
            else
            {
                this.Stations = new ObservableCollection<StationItemViewModel>(
                    this.ToStationItemViewModel().Where(
                        s => s.NameStation.ToLower().Contains(this.Filter.ToLower())));
            }
        }
        #endregion
    }
}