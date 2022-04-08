using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServis_RUIP.Models;
using WebServis_RUIP.Repozitorij;

namespace WebServis_RUIP.Services
{
    public class WS_KorisnickiPodaci : IWS_KorisnickiPodaci
    {
        private RepozitorijGlavni _db;

        public WS_KorisnickiPodaci(
            RepozitorijGlavni repozitorij
            )
        {
            _db = repozitorij;
        }

        public List<KorisnickiPodaciModel> PronadjiKorisnika(PodaciZaPretraguModel podaciZaPretragu)
        {
            List<KorisnickiPodaciModel> rezultat;

            try
            {
                rezultat = _db.PronadjiKorisnika(podaciZaPretragu);

                return rezultat;
            }
            catch (Exception ex)
            {
                _db.LogujGresku(ex);
                throw new Exception($"Greška prilikom izvršavanja servisa! Opis greške: {ex.Message}");
            }

        }
    }
}
