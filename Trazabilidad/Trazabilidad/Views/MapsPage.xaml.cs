using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trazabilidad.Views
{
    using ViewModels;
    using Xamarin.Forms.Maps;

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapsPage : ContentPage
	{
		public MapsPage ()
		{
			InitializeComponent ();
            var mainViewModel = new MainViewModel();
            mainViewModel.GetGeolotation();
            foreach (Pin item in mainViewModel.Pins)
            {
                MyMap.Pins.Add(item);
            }

            Locator();

        }
        private async void Locator()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            var location = await locator.GetPositionAsync(timeout:null);
            var position = new Position(location.Latitude, location.Longitude);
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(.3)));
        }

    }
}