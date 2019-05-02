namespace Trazabilidad.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;
    public class StationItemViewModel : Station
    {
        #region Commands
        public ICommand SelectStationCommand
        {
            get
            {
                return new RelayCommand(SelectStation);
            }
        }

        private async void SelectStation()
        {
         //   MainViewModel.GetInstance().Station = new StationViewModel(this);
            MainViewModel.GetInstance().Station = new StationViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new StationPage());
        }
        #endregion

    }
}