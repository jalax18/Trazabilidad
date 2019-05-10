namespace Trazabilidad.ViewModels
{
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Views;
    using Xamarin.Forms;
    using Helpers;

    public class MenuItemViewModel
    {
        #region Properties
        public string Icon { get; set; }

        public string Title { get; set; }

        public string PageName { get; set; }
        #endregion

        #region Commands
        public ICommand NavigateCommand
        {
            get
            {
                return new RelayCommand(Navigate);
            }
        }

        private void Navigate()
        {
           App.Master.IsPresented = false;

                /*  Application.Current.MainPage.DisplayAlert(
                   "Aviso",
                   this.PageName,
                   "Accept");*/

            if (this.PageName == "LoginPage")
            {
  //              Settings.IsRemembered = "false";
                var mainViewModel = MainViewModel.GetInstance();
  //              mainViewModel.Token = null;
  //              mainViewModel.User = null;
                Application.Current.MainPage = new NavigationPage(
                    new LoginPage());
            }
            else if (this.PageName == "UltimasVersionesPage") 
            {
               

                MainViewModel.GetInstance().UltimasVersiones = new UltimasVersionesViewModel();
                App.Navigator.PushAsync(new UltimasVersionesPage());
            }
        }
        #endregion
    }
}