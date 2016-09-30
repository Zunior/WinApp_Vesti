using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinApp_Vesti
{
    class Vest
    {
        String _naslov;
        String _podnaslov;
        String _tekst;
        String _putanja;
        String _tip;
        Boolean _aktuelno = false;
        String _komentari;

        
        public Vest(String naslov, String podnaslov, String tekst, String putanja, String tip, Boolean aktuelno, String komentari)
        {
            _naslov = naslov;
            _podnaslov = podnaslov;
            _tekst = tekst;
            _putanja = putanja;
            _tip = tip;
            _aktuelno = aktuelno;
            _komentari = komentari;
        }

        public Vest()
        {
        }

        public string naslov
        {
            get { return _naslov; }
        }
        public string podnaslov
        {
            get { return _podnaslov; }
        }
        public string tekst
        {
            get { return _tekst; }
        }
        public string putanja
        {
            get { return _putanja; }
        }
        public string tip
        {
            get { return _tip; }
        }
        public Boolean aktuelno
        {
            get { return _aktuelno; }
        }
        public string komentari
        {
            get { return _komentari; }
        }

        public void dodajKomentar(string s)
        {
            _komentari += s + "#";
        }

        public static List<Vest> IzlistajVesti()
        {
            List<Vest> vesti = new List<Vest>();

            vesti.Add(new Vest("Obiđite bajkovite dvorce Češke", "Brojni su dvorci širom Češke, a većina njih je dostupna...",
                "Brojni su dvorci širom Češke, a većina njih je dostupna posetiocima. Oni su dokaz velike arhitektonske umetnosti koja je bila razvijena na prostorima te države, a često su opremljeni bogatim umetničkim blagom." +
                "Skoro 60 dvoraca je upisano u Registar nacionalnih kulturnih spomenika, a nekoliko njih se nalazi i na listi UNESCO-vih svetskih kulturnih i prirodnih istorijskih mesta." + 
                "Ukoliko danas na sajtu Superodmor napravite upit, možete razgledati bajkovite Češke dvorce i to uz popust.Dva noćenja s doručkom i autobuski prevoz 14.aprila platićete 117, umesto 130 evra po osobi.", @"Slike/1.jpg", "Zabava", true, ""));
            vesti.Add(new Vest("Oštar pad funte zbog straha od 'Brexita'", "Britanska funta je jutros oštro pala prema dolaru...", "Britanska funta je jutros oštro pala prema dolaru, zbog neizvesnosti u pogledu potencijalnog izlaska Britanije iz Evropske unije, " +
                "prenosi britanski javni servis Bi-Bi-Si. U ranom trgovanju u Londonu, funta je oslabila za 1,4 odsto prema dolaru, na 1,42 dolara, čime je samo nastavljeno višemesečno slabljenje britanske valute. Prema japanskom jenu, funta je sa 162,40 jena u petak, " +
                "danas pala na čak 160,40 jena, što je najniži nivo od novembra 2013. godine. Najnoviji pad je usledio nakon što je gradonačelnik Londona Boris Džonson počeo da podržava kampanju za izlazak Britanije iz sastava EU, pošto je britanski premijer Dejvid Kameron " + 
                "raspisao referendum o tom pitanju za 23. jun.", @"Slike/2.jpg", "Svet", true, "Nije loša vest#Vest je odlična!#"));
            vesti.Add(new Vest("Okupljanje 'Prijatelja' je razočaranje godine", "Dženifer Aniston, Kortni Koks, Lisa Kudrou, Met Leblank i Dejvid Švimer...", "Dženifer Aniston, Kortni Koks, Lisa Kudrou, Met Leblank i Dejvid Švimer učestovali su u televizijskom specijalu " + 
                "posvećenom čuvenom televizijskom reditelju Džejmsu Barovsu, što je bilo njihovo prvo zajedničko pojavljivanje pred kamerama od kako je legendarna serija 'Prijatelji' prestala da se snima.", @"Slike/3.jpg", "Zabava", true, ""));
            vesti.Add(new Vest("Naslov4", "Podnaslov4", "Nekitekst za naslov4 koji govori o necemu vezano za naslov4", @"Slike/4.jpg", "Svet", false, ""));
            vesti.Add(new Vest("Naslov5", "Podnaslov5", "Nekitekst za naslov5 koji govori o necemu vezano za naslov5", @"Slike/5.jpg", "Zabava", false, ""));

            return vesti;
        }
    }
}
