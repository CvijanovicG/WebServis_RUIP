using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebServis_RUIP
{
    public class PodaciZaPretraguModel
    {
         public SqlDbType Datum { get; internal set; }
        public string JIB { get; internal set; }
        public string JMBG { get; internal set; }
    }
}
