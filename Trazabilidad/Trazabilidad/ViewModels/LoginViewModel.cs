﻿namespace Trazabilidad.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Services;
    using Views;
    using Xamarin.Forms;
    using Helpers;

    public class LoginViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }

        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public bool IsRemembered
        {
            get;
            set;
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.apiService = new ApiService();

            this.IsRemembered = false;
            this.IsEnabled = true;

            this.Email = "jalax@4glsp.com";
            this.Password = "Astrid_1812";
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.EmailValidation,
                    Languages.Accept);
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.PasswordValidation,
                    Languages.Accept);
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    connection.Message,
                    Languages.Accept);
                return;
            }

             var token = await this.apiService.GetToken(
                 "http://2.139.147.209:1601", 
                 this.Email, 
                 this.Password);

             if (token == null)
             {
                 this.IsRunning = false;
                 this.IsEnabled = true;
                 await Application.Current.MainPage.DisplayAlert(
                     Languages.Error,
                     Languages.SomethingWrong,
                     Languages.Accept);
                 return;
             }

             if (string.IsNullOrEmpty(token.AccessToken))
             {
                 this.IsRunning = false;
                 this.IsEnabled = true;
                 await Application.Current.MainPage.DisplayAlert(
                     Languages.Error,
                     token.ErrorDescription,
                     Languages.Accept);
                 this.Password = string.Empty;
                 return;
             }
            Settings.AccessToken = token.AccessToken;
            Settings.TokenType = token.TokenType;
            Settings.IsRemembered = this.IsRemembered;
            // prueba github by ibz
            var mainViewModel = MainViewModel.GetInstance();
            //  mainViewModel.Token = token;
//            mainViewModel.Macserver = new MacserverViewModel();
  //          await Application.Current.MainPage.Navigation.PushAsync(new MacserverPage());
            mainViewModel.Stations = new StationsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new MasterPage());

            this.IsRunning = false;
            this.IsEnabled = true;

           // this.Email = string.Empty;
            //this.Password = string.Empty;
        }
        #endregion
    }
}