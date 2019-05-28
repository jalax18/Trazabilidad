namespace Trazabilidad.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Models;
    using Xamarin.Forms.Maps;

    public class MainViewModel
    {

        #region Properties

        public ObservableCollection<Pin> Pins { get; set; }
        public List<Fpardia> FpardiaList
        {
            get;
            set;
        }

        public List<Macserverdef> MacserverdefList
        {
            get;
            set;
        }

        public List<Artdef> ArtdefList
        {
            get;
            set;
        }

        public List<Tandef> TandefList
        {
            get;
            set;
        }

        public List<Posdef> PosdefList
        {
            get;
            set;
        }

        public List<Surdef> SurdefList
        {
            get;
            set;
        }
        public List<Station> StationList
        {
            get;
            set;
        }


        public ObservableCollection<MenuItemViewModel> Menus
        {
            get;
            set;
        }
        #endregion
        /*   #region Properties
        public List<Land> LandsList
        {
            get;
            set;
        }

        public TokenResponse Token
        {
            get;
            set;
        }
        #endregion*/

        #region ViewModels

        public CarbdefgridPageViewModel Cardefgrid { get; set; }
        public MapsViewModel Maps { get; set; }
        public MasinfoViewModel Masinfo { get; set; }
        public ProgramadordeTareasViewModel ProgramadordeTareas { get; set; }
        public AcercadeViewModel Acercade { get; set; }
        public PruebaFotoViewModel PruebaFoto { get; set; }

        public MacserverIniViewModel Macserverini
        {
            get;
            set;
        }
        public UltimasVersionesViewModel UltimasVersiones
        {
            get;
            set;
        }
        public LoginViewModel Login
        {
            get;
            set;
        }

        public MacserverViewModel Macserver
        {
            get;
            set;
        }
        public StationsViewModel Stations
        {
            get;
            set;
        }

        public StationViewModel Station
        {
            get;
            set;
        }

        /*  public LandsViewModel Lands
          {
              get;
              set;
          }

          public LandViewModel Land
          {
              get;
              set;
          }*/
        #endregion

        #region Constructors
        public MainViewModel()
        {
            Pins = new ObservableCollection<Pin>();
            instance = this;
            this.Login = new LoginViewModel();
            this.LoadMenu();
        }

        private void LoadMenu()
        {
            this.Menus = new ObservableCollection<MenuItemViewModel>();
            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_settings",
                PageName="UltimasVersionesPage",
                Title="Ver Ultimas Versiones",

            }); this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_settings",
                PageName = "MapsPage",
                Title = "Mapa de EESS Cercanas",

            });
            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_insert_chart",
                PageName = "ProgramadordeTareasPage",
                Title = "Programador Tareas",

            });
            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_insert_chart",
                PageName = "AcercadePage",
                Title = "Acerca de",

            });

            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_insert_chart",
                PageName = "LoginPage",
                Title = "Logoff",

            });

        /*    this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_insert_chart",
                PageName = "PruebaFotoPage",
                Title = "Test",

            });*/
        }
        #endregion
        #region Methods
        public void GetGeolotation()
        {
            var position1 = new Position(37.998161, -1.139048);
            var pin1 = new Pin
            {
                Type = PinType.Place,
                Position = position1,
                Label = "Gasolinera Avda Los Pinos",
                Address = "direccion Avda Los Pinos"
            };
            Pins.Add(pin1);

            var position2 = new Position(37.997018, -1.103357);
            var pin2 = new Pin
            {
                Type = PinType.Place,
                Position = position2,
                Label = "E.S. RIZAO",
                Address = "Direccion Rizao"
            };
            Pins.Add(pin2);

            var position3 = new Position(38.020400, -1.163618);
            var pin3 = new Pin
            {
                Type = PinType.Place,
                Position = position3,
                Label = "E.S. PETROPAY",
                Address = "Direccion PetroPay"
            };
            Pins.Add(pin3);
        }


        #endregion
        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
        #endregion
    }
}