using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace rozwiazanie_mateusz_tobiasz
{
    
    [Serializable, XmlRoot("SIMC")]
    public class Simc
    {
        public CatalogSimc catalog { get; set; }
    }

    [Serializable, XmlRoot("teryt")]
    public class Terc
    {
        public CatalogTerc catalog { get; set; }
    }
    
    [Serializable, XmlRoot("ULIC")]
    public class Ulic
    {
        public CatalogUlic catalog { get; set; }
    }
    public abstract class Catalog
    {
        [XmlAttribute("name")]
        public string name { get; set; }

        [XmlAttribute("type")]
        public string type { get; set; }

        [XmlAttribute("date")]
        public DateTime date { get; set; }
    }

    [Serializable, XmlRoot("catalog")]
    public class CatalogSimc : Catalog
    {
        [XmlElement("row")]
        public RowSimc[] rows { get; set; }

    }

    [Serializable, XmlRoot("catalog")]
    public class CatalogTerc : Catalog
    {
        [XmlElement("row")]
        public RowTerc[] rows { get; set; }

    }

    [Serializable, XmlRoot("catalog")]
    public class CatalogUlic : Catalog
    {
        [XmlElement("row")]
        public RowUlic[] rows { get; set; }

    }

    


    public abstract class Row
    {
        [XmlElement("WOJ")]
        public string Woj { get; set; }

        [XmlElement("POW")]
        public string Pow { get; set; }

        [XmlElement("GMI")]
        public string Gmi { get; set; }
    }

    [Serializable, XmlRoot("row")]
    public class RowSimc:Row
    {
        

        [XmlElement("RODZ_GMI")]
        public string Rodz_gminy { get; set; }

        [XmlElement("RM")]
        public string Rm { get; set; }

        [XmlElement("MZ")]
        public string Mz { get; set; }

        [XmlElement("NAZWA")]
        public string Nazwa { get; set; }

        [XmlElement("SYM")]
        public string Sym { get; set; }

        [XmlElement("SYMPOD")]
        public string Sym_pod { get; set; }

        [XmlElement("STAN_NA")]
        public DateTime Stan_na { get; set; }


    }

    [Serializable, XmlRoot("row")]

    public class RowTerc: Row
    {

        [XmlElement("RODZ")]
        public string Rodz { get; set; }

        [XmlElement("NAZWA")]
        public string Nazwa { get; set; }

        [XmlElement("NAZWA_DOD")]
        public string Nazwa_dod { get; set; }

        [XmlElement("STAN_NA")]
        public DateTime Stan_na { get; set; }


    }


    [Serializable, XmlRoot("row")]

    public class RowUlic: Row
    {
      
        [XmlElement("RODZ_GMI")]
        public string Rodz_gminy { get; set; }

        [XmlElement("SYM")]
        public string Sym { get; set; }

        [XmlElement("SYM_UL")]
        public string Sym_ul { get; set; }

        [XmlElement("CECHA")]
        public string Cecha { get; set; }
        
        [XmlElement("NAZWA_1")]
        public string Nazwa_1 { get; set; }

        [XmlElement("NAZWA_2")]
        public string Nazwa_2 { get; set; }

        [XmlElement("STAN_NA")]
        public DateTime Stan_na { get; set; }


    }
}
