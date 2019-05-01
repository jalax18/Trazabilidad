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

    public class StationsViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private ObservableCollection<Station> stations;
      //  private List<Station> stationsList;
        private bool isRefreshing;
        private string filter;
        #endregion

        #region Properties
        public ObservableCollection<Station> Stations
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
                "http://localhost:1812",
                "/api",
                "/stations");

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
            this.Stations = new ObservableCollection<Station>(MainViewModel.GetInstance().StationList);
            this.IsRefreshing = false;
        }
        #endregion

        #region Methods



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
                this.Stations = new ObservableCollection<Station>(MainViewModel.GetInstance().StationList);

            }
            else
            {
                this.Stations = new ObservableCollection<Station>(
                    MainViewModel.GetInstance().StationList.Where(
                        s => s.NameStation.ToLower().Contains(this.Filter.ToLower())));
            }
        }
        #endregion
    }
}