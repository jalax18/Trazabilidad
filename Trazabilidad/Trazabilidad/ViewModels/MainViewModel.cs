namespace Trazabilidad.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Models;

    public class MainViewModel
    {

        #region Properties

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
                Title = "Acceso Mapa Estaciones",

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