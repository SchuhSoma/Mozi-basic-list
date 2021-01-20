using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        static List<Mozi> MoziList;
        static void Main(string[] args)
        {
            Beolvasas(); Console.WriteLine("\n-----------------------------\n");
            ListaHossza(); Console.WriteLine("\n-----------------------------\n");
            OsszNezeszam(); Console.WriteLine("\n-----------------------------\n");
            KeresesEvre(); Console.WriteLine("\n-----------------------------\n");
            Tartalmazas(); Console.WriteLine("\n-----------------------------\n");
            Console.ReadKey();
        }

        private static void Tartalmazas()
        {
            Console.WriteLine("Van olyan film aminek a címében ott van a homokvihar szó?");
            foreach (var m in MoziList)
            {
                if(m.FilmCim.ToLower().Contains("homok"))
                {
                    Console.WriteLine("Van ilyen film a listában");
                }
            }
        }

        private static void KeresesEvre()
        {
            Console.WriteLine("Kérjen be egy évet 2004 és 2012 között mondja meg milyen film készült abban az évben");
            Console.Write("\tKérem adjon meg egy évszámot 2004 és 2012 között: ");
            int KeresettEvszam = int.Parse(Console.ReadLine());
            /*
            for (int i = 0; i < MoziList.Count; i++)
            {
                if(MoziList[i].KiadasDatuma==KeresettEvszam)
                {
                    Console.WriteLine("\tAz adott évben ez a film volt bemutatva: {0}", MoziList[i].FilmCim);
                }
            }
            */
            int Szamlalo = 0;
            while(Szamlalo<MoziList.Count && KeresettEvszam!=MoziList[Szamlalo].KiadasDatuma)
            { Szamlalo++; }
            if (Szamlalo == MoziList.Count) Console.WriteLine("Nincs ilyen film");
            else Console.WriteLine("\tAz adott évben ez a film volt bemutatva: {0}", MoziList[Szamlalo].FilmCim);
        }

        private static void OsszNezeszam()
        {
            Console.WriteLine("Határozza meg az összes néző számát akik a listában lévő filmeket látták");
            int Osszeg = 0;
            foreach (var m in MoziList)
            {
                Osszeg += m.Nezoszam;
            }
            Console.WriteLine("\tÖsszesen ennyi néző volt: {0}", Osszeg);
        }

        private static void ListaHossza()
        {
            Console.WriteLine("\tA lista hossza: {0}", MoziList.Count);
        }

        private static void Beolvasas()
        {
            Console.WriteLine("Beolvassuk a MOZI állományt");
            MoziList = new List<Mozi>();
            int db = 0;
            var sr = new StreamReader(@"mozi.txt", Encoding.UTF8);
            while(!sr.EndOfStream)
            {
                MoziList.Add(new Mozi(sr.ReadLine()));
                db++;
            }
            sr.Close();
            if (db > 0) Console.WriteLine("\tSikeres volt a beolvasás, beolvastam: {0} sort", db);
            else Console.WriteLine("\tSajnos sikertelen beolvasás");
        }
    }
}
