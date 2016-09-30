using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_2_XAML_proba
{
    class Vest
    {
        String _naslov;
        String _podnaslov;
        String _tekst;
        String _putanja;
        String _tip;
        Boolean _aktuelno;

        public Vest(String naslov, String podnaslov, String tekst, String putanja, String tip, Boolean aktuelno)
        {
            this.naslov = naslov;
            this.podnaslov = podnaslov;
            this.tekst = tekst;
            this.putanja = putanja;
            this.tip = tip;
            this.aktuelno = aktuelno;
        }

        public string naslov
        {
            get { return _naslov; }
            set { _naslov = value; }
        }
        public string podnaslov
        {
            get { return _podnaslov; }
            set { _podnaslov = value; }
        }
        public string tekst
        {
            get { return _tekst; }
            set { _tekst = value; }
        }
        public string putanja
        {
            get { return _putanja; }
            set { _putanja = value; }
        }
        public string tip
        {
            get { return _tip; }
            set { _tip = value; }
        }
        public Boolean aktuelno
        {
            get { return _aktuelno; }
            set { _aktuelno = value; }
        }

        //public static List<Vest> IzlistajVesti()
        //{
        //    List<Vest> vesti = new List<Vest>();

        //    vesti.Add(new Vest
        //    {
        //        _naslov = "Naslov1",
        //        _podnaslov ="Podnaslov1",
        //        _tekst ="Nekitekst za naslov1 koji govori o necemu vezano za naslov1",
        //        _putanja =@"Slike/1.jpg"
        //    });
        //    vesti.Add(new Vest
        //    {
        //        _naslov = "Naslov2",
        //        _podnaslov = "Podnaslov2",
        //        _tekst = "Nekitekst za naslov2 koji govori o necemu vezano za naslov2",
        //        _putanja = @"Slike/2.jpg"
        //    });
        //    vesti.Add(new Vest
        //    {
        //        _naslov = "Naslov3",
        //        _podnaslov = "Podnaslov3",
        //        _tekst = "Nekitekst za naslov3 koji govori o necemu vezano za naslov3",
        //        _putanja = @"Slike/3.jpg"
        //    });
        //    vesti.Add(new Vest
        //    {
        //        _naslov = "Naslov4",
        //        _podnaslov = "Podnaslov4",
        //        _tekst = "Nekitekst za naslov1 koji govori o necemu vezano za naslov4",
        //        _putanja = @"Slike/4.jpg"
        //    });
        //    vesti.Add(new Vest
        //    {
        //        _naslov = "Naslov5",
        //        _podnaslov = "Podnaslov5",
        //        _tekst = "Nekitekst za naslov5 koji govori o necemu vezano za naslov5",
        //        _putanja = @"Slike/5.jpg"
        //    });
        //    return vesti;
        }
    }
}
