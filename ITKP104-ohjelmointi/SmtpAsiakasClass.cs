using System;
using System.Collections.Generic;
using System.Text;

namespace ITKP104_ohjelmointi
{
    class SmtpAsiakasClass
    {
        /// <summary>
        /// Funktio palauttaa SMTP asiakkaan viestin palvelimen viestin perusteella.
        /// </summary>
        /// <param name="viesti">string SMTP palvelimen viesti</param>
        /// <returns>string SMTP asiakkaan viesti</returns>
        public static string smtpAsiakas(string vastaanotettu)
        {
            string lahetettava = "";
            Console.Write(vastaanotettu);
            // Toteuta
            Console.Write(lahetettava);
            return lahetettava;
        }
    }
}
