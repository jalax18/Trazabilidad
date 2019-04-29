

namespace Trazabilidad.Backend.Models
{

    using Domain.Models;

    public class LocalDataContext:DataContext
    {
        public System.Data.Entity.DbSet<Trazabilidad.Common.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<Trazabilidad.Common.Models.UserType> UserTypes { get; set; }
    }
}