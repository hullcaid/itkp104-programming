using System;
using System.Net;
using System.Text;
using System.Net.Sockets;
public class UDPasiakas
{
    public static void Main()
    {
    Socket soketti = null;
    IPAddress ip = null;
    IPEndPoint iep = null;
    try {
ip = Dns.GetHostAddresses("djxmmx.com")[0]; // IPAddress luokan olio, alustettu arvoon null
iep = new IPEndPoint(ip, 17); // IPEndPoint luokan olio, alustettu arvoon null
soketti = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp); // Luo UDP soketti, alustettu arvoon null
soketti.ReceiveTimeout = 3000; // Lopetetaan jos palvelin ei lähetä mitään 3000 ms
String message = "foobar"; // Mitä tahansa tekstiä
soketti.SendTo(Encoding.ASCII.GetBytes(message), iep); // Lähetys UDP soketilla iep:n määrittämälle vastaanottajalle
IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0); // Vastaanotetun paketin lähettäjä
EndPoint senderRemote = (EndPoint)sender; // Typecast EndPoint:ksi
byte[] rec = new byte[2048]; // Tavutaulukko vastaanottoa varten
// Alla valmiina ReceiveFrom parametreiksi tavutaulukko ja referenssi EndPoint olioon
int paljon = soketti.ReceiveFrom(rec, ref senderRemote);
String vastaus = System.Text.Encoding.ASCII.GetString(rec, 0, paljon);
        Console.Write("IPAddress luokan olio luotiin onnistuneesti:\n"
        + "IP osoite = " + ip.ToString() + '\n');
        Console.Write("IPEndPoint luokan olio luotiin onnistuneesti:\n"
        + "IP osoite ja porttinumero = " + iep.ToString() + '\n');
        Console.Write("Soketti luotiin onnistuneesti seuraavin ominaisuuksin:\n"
        + "AddressFamily = " + soketti.AddressFamily.ToString () + "\nSocketType = "
        + soketti.SocketType.ToString () + "\nProtocolType = " + soketti.ProtocolType.ToString () + '\n');
        Console.Write("Vastaanotettiin viesti:\n" + vastaus + '\n');
    }
    catch (SocketException se) {
        Console.WriteLine( se.Message);
        if (se.Message.StartsWith("Could not resolve host")) {
            Console.WriteLine("DNS palvelu selvittää verkkotunnuksia, osoitteeksi vain verkkotunnus");
        }
    }
    catch (Exception e) {
        Console.WriteLine( e.ToString());
    }
    finally {
        if (soketti != null) {
            // suljetaan soketti ja vapautetaan resurssit
            soketti.Close();
            Console.WriteLine("Soketti suljettiin onnistuneesti");
        }
    }
    }
}
