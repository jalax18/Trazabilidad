﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Trazabilidad
{
    using Views;
    using ViewModels;
    using Helpers;
    public partial class App : Application
    {
        public static NavigationPage Navigator { get; internal set; }

        public App()
        {
            InitializeComponent();
            if (Settings.IsRemembered && !string.IsNullOrEmpty(Settings.AccessToken))

            {

                //  MainPage = new MainPage();
               // MainViewModel.GetInstance().Login = new LoginViewModel();
                //this.MainPage = new NavigationPage(new LoginPage());
                //  MainPage = new MainPage();
               MainViewModel.GetInstance().Stations = new StationsViewModel();
                this.MainPage = new MasterPage();
            }
            else
            {
                //  MainPage = new MainPage();
                MainViewModel.GetInstance().Login = new LoginViewModel();
                this.MainPage = new NavigationPage(new LoginPage());
            }
            
           
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
