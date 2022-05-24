using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Net;

namespace rozwiazanie_mateusz_tobiasz
{
    public static class RowReader
    {
        public static (Simc, Ulic, Terc) ReadXML(string nameSimc, string nameUlic, string nameTerc)
        {
            Simc simc = null;
            Terc terc = null;
            Ulic ulic = null;

            using (ZipArchive archive = ZipFile.OpenRead(nameSimc))
            {
                foreach (var entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".xml"))
                    {
                        using var stream = entry.Open();

                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Simc));

                        simc = (Simc)xmlSerializer.Deserialize(stream);

                    }
                }
            }

            using (ZipArchive archive = ZipFile.OpenRead(nameUlic))
            {
                foreach (var entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".xml"))
                    {
                        using var stream = entry.Open();

                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Ulic));

                        ulic = (Ulic)xmlSerializer.Deserialize(stream);

                    }
                }
            }
            
            using (ZipArchive archive = ZipFile.OpenRead(nameTerc))
            {
                foreach (var entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".xml"))
                    {
                        using var stream = entry.Open();

                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Terc));

                        terc = (Terc)xmlSerializer.Deserialize(stream);

                    }
                }
            }


            return (simc, ulic, terc);
        }
        public static void GetCitiesInCommune(Simc simc, Terc terc, string teryt)
        {
            
            if(teryt is null)
            {
                Console.WriteLine("Nie podano TERYT gminy");
                return;
            }
            string woj = teryt.Substring(0, 2);
            string pow = teryt.Substring(2, 2);
            string gmi = teryt.Substring(4, 2);
            string rodz = teryt.Substring(6, 1);

            var found = terc.catalog.rows.Where(x => (x.Woj.Equals(woj) && x.Pow.Equals(pow) && x.Gmi.Equals(gmi) && x.Rodz.Equals(rodz))).ToArray();

            if(found.Length == 0)
            {
                Console.WriteLine("Nie znaleziono gminy o podanym TERYT");
                return;
            }

            var row = found.First();
            Console.WriteLine($"Miejscowości w {row.Nazwa} ({row.Nazwa_dod}): ");
            var rows = simc.catalog.rows.Where(x => (x.Woj.Equals(woj) && x.Pow.Equals(pow) && x.Gmi.Equals(gmi) && x.Rodz_gminy.Equals(rodz))).ToArray();

            if (rows.Length !=0)
            {
                foreach (var city in rows)
                {
                    Console.WriteLine($"{city.Nazwa}");
                }
            }
        }

        public static void GetRoadsInCity(Simc simc, Ulic ulic, string teryt)
        {

            if (teryt is null)
            {
                Console.WriteLine("Nie podano TERYT miejscowości");
                return;
            }

            var found = simc.catalog.rows.Where(x => (x.Sym.Equals(teryt))).ToArray();

            if (found.Length == 0)
            {
                Console.WriteLine("Nie znaleziono miejscowości o podanym TERYT");
                return;
            }

            var row = found.First();


            Console.WriteLine($"Ulice w {row.Nazwa}: ");

            var rows = ulic.catalog.rows.Where(x => x.Sym.Equals(teryt)).ToArray();

            if (rows.Length!=0)
            {
                foreach (var road in rows)
                {
                    Console.WriteLine($"{road.Cecha} {road.Nazwa_1} {road.Nazwa_2}");
                }
            }
        }
    }
}
