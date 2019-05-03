

namespace Trazabilidad.Backend.Models
{

    using Domain.Models;

    public class LocalDataContext:DataContext
    {
        public System.Data.Entity.DbSet<Trazabilidad.Common.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<Trazabilidad.Common.Models.UserType> UserTypes { get; set; }

        public System.Data.Entity.DbSet<Trazabilidad.Common.Models.Macserver> Macservers { get; set; }

        public System.Data.Entity.DbSet<Trazabilidad.Common.Models.Maccliente> Macclientes { get; set; }

        public System.Data.Entity.DbSet<Trazabilidad.Common.Models.Mpecliente> Mpeclientes { get; set; }

        public System.Data.Entity.DbSet<Trazabilidad.Common.Models.Xad> Xads { get; set; }

        public System.Data.Entity.DbSet<Trazabilidad.Common.Models.Garum> Garums { get; set; }

        public System.Data.Entity.DbSet<Trazabilidad.Common.Models.StationType> StationTypes { get; set; }

        public System.Data.Entity.DbSet<Trazabilidad.Common.Models.Station> Stations { get; set; }

        public System.Data.Entity.DbSet<Trazabilidad.Common.Models.StationService> StationServices { get; set; }
    }
}