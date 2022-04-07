using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServis_RUIP.Models
{
    public class KorisnickiPodaciModel
    {
        public string JIB { get; set; }
        public string fldJMBG { get; set; }
        public string NazivObveznika { get; set; }
        public string fldPrezime { get; set; }
        public string fldIme { get; set; }
        public string fldOsigOsnovNaziv { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
        public string SO { get; set; }
        public int RadniSati { get; set; }
        public int Aktivan { get; set; }
    }
}
