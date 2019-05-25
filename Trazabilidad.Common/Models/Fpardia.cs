using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trazabilidad.Common.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using System.ComponentModel.DataAnnotations.Schema;



    public class Fpardia

    {

        [Key]

        public int IdFpardia { get; set; }
        [Index("Fpardia_IdEstacion_Index", IsUnique = true)]
        public int IdEstacion { get; set; }
        public string Fptipest { get; set; }
        // M Comisionista E Firme
        public string Fpemp { get; set; }
        public string Fpdir { get; set; }
        public string Fptel { get; set; }
        public string Fpcab1 { get; set; }
        public string Fpcab2 { get; set; }
        public string Fpcab3 { get; set; }
        public string Fpcab4 { get; set; }
        public string Fpcab5 { get; set; }
        public string Fppie1 { get; set; }
        public string Fppie2 { get; set; }
        public string Fppie3 { get; set; }
        public string Fpcabfac1 { get; set; }
        public string Fpcabfac2 { get; set; }
        public string Fpcabfac3 { get; set; }
        public string Fpcabfac4 { get; set; }
        public string Fpcabfac5 { get; set; }
        public string Fpcabfac6 { get; set; }
        public string Fpcabfac7 { get; set; }
        public string Fppiefac1 { get; set; }
        public string Fppiefac2 { get; set; }
        public string Fppiefac3 { get; set; }





    }
}
