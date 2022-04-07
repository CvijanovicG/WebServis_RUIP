using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using WebServis_RUIP.Models;

namespace WebServis_RUIP.Services
{
    [ServiceContract]
    public interface IWS_KorisnickiPodaci
    {
        [OperationContract]
        public List<KorisnickiPodaciModel> PronadjiKorisnika(PodaciZaPretraguModel podaciZaPretragu);
    }
}
