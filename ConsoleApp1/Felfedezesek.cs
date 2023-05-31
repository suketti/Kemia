using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Felfedezesek
    {
        string ev;
        string nev;
        string vegyjel;
        int rendszam;
        string felfedezo;

        public Felfedezesek(string ev, string nev, string vegyjel, int rendszam, string felfedezo)
        {
            this.ev = ev;
            this.nev = nev;
            this.vegyjel = vegyjel;
            this.rendszam = rendszam;
            this.felfedezo = felfedezo;
        }

        public string Ev { get => ev; set => ev = value; }
        public string Nev { get => nev; set => nev = value; }
        public string Vegyjel { get => vegyjel; set => vegyjel = value; }
        public int Rendszam { get => rendszam; set => rendszam = value; }
        public string Felfedezo { get => felfedezo; set => felfedezo = value; }

    }
}
