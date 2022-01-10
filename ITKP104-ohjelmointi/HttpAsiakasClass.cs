using System;
using System.Collections.Generic;
using System.Text;

namespace ITKP104_ohjelmointi
{
    public static class HttpAsiakasClass
    {
        /// <summary>
        /// Funktio palauttaa HTML sivun.
        /// </summary>
        /// <param name="url">URL tekstimuotoiselle HTML-sivulle</param>
        /// <returns>string HTML-sivu tekstinä</returns>
        public static string httpAsiakas(string url)
        {
            string htmlSivu = "";
            // Toteuta
            //Erota skeema
            var schemeSplit = url.Split("://");

            var serverSplit = schemeSplit.Length == 1 ? schemeSplit[0].Split("/") : schemeSplit[1].Split("/");

            var server = serverSplit[0];
            var resource = serverSplit[1];

            Console.WriteLine(server);
            Console.WriteLine(resource);

            var request = $"GET {resource} HTTP/1.1 \r\nHost: {server}\r\n\r\n";

            Console.WriteLine(request);
            /*foreach (var i in midArray)
            {
                Console.WriteLine(i);
            }*/
            return htmlSivu;
        }
    }
}
