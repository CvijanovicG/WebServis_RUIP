using Microsoft.Extensions.Configuration;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebServis_RUIP.Models;

namespace WebServis_RUIP.Repozitorij
{
    public class RepozitorijGlavni
    {
        private IDatabase _db;

        public RepozitorijGlavni(IConfiguration configuration)
        {
            _db = DatabaseConfiguration.Build()
                .UsingConnectionString(configuration.GetConnectionString("DatabaseConnection"))
                .UsingProvider<PetaPoco.Providers.SqlServerDatabaseProvider>()
                .UsingCommandTimeout(180)
                .Create();
        }

        //---------------------------------------------

        public List<KorisnickiPodaciModel> PronadjiKorisnika(PodaciZaPretraguModel podaciZaPretragu)
        {
            List<KorisnickiPodaciModel> rezultat = new List<KorisnickiPodaciModel>();
            SqlParameter modeParam = new SqlParameter("@JIB", podaciZaPretragu.JIB);
            SqlParameter JMBGZaPretraguParam = new SqlParameter("@JMBG", podaciZaPretragu.JMBG);
            SqlParameter modeParam1 = new SqlParameter("@Datum", podaciZaPretragu.Datum);
            rezultat = _db.QueryProc<KorisnickiPodaciModel>(
                "spPregledSvihZaposlenjaKodPoslodavcaRUIS",
                 JMBGZaPretraguParam
                 , modeParam
                 , modeParam1
                ).ToList();
            return rezultat;
        }

        //---------------------------------------------

        /// <summary>
        /// Logovanje greske u bazu.
        /// Ako se desi greska prilikom upisa u bazu, to se ne prijavljuje, mada se to ne bi smjelo desiti.
        /// </summary>
        public void LogujGresku(Exception ex)
        {
            try
            {
                SqlParameter codeParam = new SqlParameter("@Code", "");
                SqlParameter messageParam = new SqlParameter("@Message", (ex.Message ?? ""));
                SqlParameter stackTraceParam = new SqlParameter("@StackTrace", (ex.ToString() ?? ""));
                SqlParameter errorLevelParam = new SqlParameter("@ErrorLevel", ("ERROR"));
                SqlParameter userNameParam = new SqlParameter("@UserName", "");
                SqlParameter ipAddressParam = new SqlParameter("@IpAddress", "");
                _db.ExecuteNonQueryProc(
                    "test.spLogGreske",
                    codeParam,
                    messageParam,
                    stackTraceParam,
                    errorLevelParam,
                    userNameParam,
                    ipAddressParam
                    );
            }
            catch
            {
            }
        }
    }
}
