using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Felfedezesek> f = new List<Felfedezesek>();

            StreamReader sr = new StreamReader("felfedezesek.csv");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] splitLine = line.Split(';');

                f.Add(new Felfedezesek(splitLine[0], splitLine[1], splitLine[2], Int32.Parse(splitLine[3]), splitLine[4]));
            }

            if (f.Count > 200)
            {
                Console.WriteLine("Túl hosszú a bemeneti adatfájl");
                System.Environment.Exit(-1);
            } else
            {
                Console.WriteLine($"3. feladat: Elemek száma: {f.Count()}");
            }

            int okoriFelfedezesek = 0;

            okoriFelfedezesek = f.FindAll(x => x.Ev == "Ókor").Count;

            Console.WriteLine($"4. feladat: Felfedezések száma az ókorban: {okoriFelfedezesek}");

            bool found = false;
            string input = "";
            Felfedezesek foundItem;
            while (!found)
            {
                Console.Write("5. feladat: Kérek egy vegyjelet:");
                input = Console.ReadLine().ToLower();
                if (input.Length == 1 || input.Length == 2)
                {
                    found = true;
                }
            }

            if (f.Exists(x => x.Vegyjel.ToLower() == input))
            {
                foundItem = f.Find(x => x.Vegyjel.ToLower() == input);
                Console.WriteLine($"6. feladat: Keresés\n\t Az elem vegyjele: {foundItem.Vegyjel}\n\t Az elem neve: {foundItem.Nev}\n\t Rendszáma: {foundItem.Rendszam}\n\t Felfedezés éve: {foundItem.Ev}\n\t Felfedező: {foundItem.Felfedezo}");
            } else
            {
                Console.WriteLine("6. feladat: Keresés\n\tNincs ilyen elem az adatforrásban");
            }

            int highestInterval = 0;

            for (int i = 0; i < f.Count() - 1; i++)
            {
                if (f[i].Ev != "Ókor")
                {
                    if (Int32.Parse(f[i + 1].Ev) - Int32.Parse(f[i].Ev) > highestInterval)
                    {
                        highestInterval = Int32.Parse(f[i + 1].Ev) - Int32.Parse(f[i].Ev);
                    }
                }
            }
            Console.WriteLine($"7. feladat: {highestInterval} év volt a leghosszabb időszak két elem felfedezése között.");

            Dictionary<int, int> statistics = new Dictionary<int, int>();

            foreach (Felfedezesek felfedezes in f)
            {
                if (felfedezes.Ev != "Ókor") 
                {
                    int count = f.Count(x => x.Ev == felfedezes.Ev);
                    if (count > 3 && statistics.ContainsKey(Int32.Parse(felfedezes.Ev)) == false)
                    {
                        statistics.Add(Int32.Parse(felfedezes.Ev), count);
                    }
                }
            }

            Console.WriteLine("8. feladat: Statisztika");
            int[] keys = statistics.Keys.ToArray();
            int[] values = statistics.Values.ToArray();
            for (int i = 0; i < statistics.Count; i++)
            {
                Console.WriteLine($"\t {keys[i]} : {values[i]} db");
            }
            
        }
    }
}
