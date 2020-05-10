using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace xd
{
    public class Magazyn : IComparable<Magazyn>
    {
        [XmlAttribute]
        public string Nazwa { get; set; }

        [XmlAttribute]
        public string Model { get; set; }

        [XmlAttribute]
        public string Data_zakupu { get; set; }

        [XmlAttribute]
        public double Cena { get; set; }

        [XmlElement]
        public List<Serwis> Naprawy { get; set; }

        [XmlAttribute]
        public string Info { get; set; }

        [XmlAttribute]
        public List<string> Wyposarzenie { get; set; }

        [XmlAttribute]
        public List<string> Usterka { get; set; }

        [XmlAttribute]
        public bool CzyOdNowosci { get; set; }

        [XmlAttribute]
        public string GdzieNabyto { get; set; }

        [XmlAttribute]
        public string Kategoria { get; set; }

        [XmlAttribute]
        public int ID { get; set; }


        public int CompareTo(Magazyn other)
        {
            if(other == null)  return 1;
            else return this.Nazwa.CompareTo(other.Nazwa);
        }

        public override string ToString()
        {
            return $"{Nazwa}";
        }
    }
}
