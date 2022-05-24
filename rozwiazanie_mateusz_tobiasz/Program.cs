using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Xml.Serialization;

namespace rozwiazanie_mateusz_tobiasz
{
    class Program
    {
        static void Main(string[] args)
        {


            // Należałoby sprawdzić czy kod TERYT gminy ma poprawną formę xx xx xxx - gdzie pierwsze 2 cyfry to wojewodztwo, kolejne dwie to powiat,
            // dwie kolejne to gmina, a ostatnia cyfra to rodzaj gminy

            string terytGm = null;
            string terytMsc = null;

            Console.WriteLine("Który teryt został podany? (g - gmina, m - miejscowość)");

            string choice = Console.ReadLine();
            
            if(args.Length < 1)
            {
                Console.WriteLine("Nie podano żadnych kodów teryt.");
                return;
            }
            else if(args.Length < 2)
            {
                if (choice.Equals("g"))
                {
                    terytGm = args[0];
                    terytMsc = null;
                }
                else if (choice.Equals("m"))
                {
                    terytMsc = args[0];
                    terytGm = null;
                }
                else
                {
                    Console.WriteLine("Zły wybór");
                    return;
                }
            }
          
            
            


            (Simc simc, Ulic ulic, Terc terc) =  RowReader.ReadXML("SIMC.zip", "ULIC.zip", "TERC.zip");
            Console.WriteLine();
            RowReader.GetCitiesInCommune(simc, terc, terytGm);
            Console.WriteLine();
            RowReader.GetRoadsInCity(simc, ulic, terytMsc);

            
           



        }
    }

   
}
