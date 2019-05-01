namespace Trazabilidad.ViewModels
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
    
    public class MacserverViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private ObservableCollection<Macserver> macservers;
        private List<Macserver> macserversList;
        private bool isRefreshing;
        private string filter;
        #endregion

        #region Properties
        public ObservableCollection<Macserver> Macservers
        {
            get { return this.macservers; }
            set { SetValue(ref this.macservers, value); }
        }
        public List<Macserver> MacserversList
        {
            get { return this.macserversList; }
            set { SetValue(ref this.macserversList, value); }
        }

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
        public MacserverViewModel()
        {
            this.apiService = new ApiService();
           // this.Test();
            this.LoadMacservers();
        }

       
        #endregion

        #region Methods
        private async void LoadMacservers()
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

            var response = await this.apiService.GetList<Macserver>(
                "http://localhost:1812",
                "/api",
                "/macservers");

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

            this.MacserversList = (List<Macserver>)response.Result;
            this.Macservers = new ObservableCollection<Macserver>(this.MacserversList);
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
                return new RelayCommand(LoadMacservers);
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
                this.Macservers = new ObservableCollection<Macserver>(this.MacserversList);
                    
            }
            else
            {
                this.Macservers = new ObservableCollection<Macserver>(
                    this.MacserversList.Where(
                        m => m.VerMacserver.ToLower().Contains(this.Filter.ToLower())));
            }
        }
        #endregion
    }
}