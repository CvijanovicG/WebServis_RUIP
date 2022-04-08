using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebServis_RUIP
{
    public class PodaciZaPretraguModel
    {
        public SqlDbType JIBPoslodavca { get; internal set; }
        public string JMBGOsiguranika { get; internal set; }
        public SqlDbType Datum { get; internal set; }
    }
}
