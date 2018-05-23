using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L14_Automobiliu_parkas
{
    abstract public class Automobilis 
    {

        public string numeris { get; set; }
        public string gamintojas { get; set; }
        public string modelis { get; set; }
        public string spalva { get; set; }
        public DateTime pagaminmetai { get; set; }
        public DateTime technikine { get; set; }
        public string kuras { get; set; }

        /** konstruktorius be parametrų */
        public Automobilis()
        {
        }

        /** konstruktorius su parametrais */
        public Automobilis(string numeris, string gamintojas, string modelis, string spalva,
            DateTime pagaminmetai, DateTime technikine, string kuras)
        {

            this.numeris = numeris;
            this.gamintojas = gamintojas;
            this.modelis = modelis;
            this.spalva = spalva;
            this.pagaminmetai = pagaminmetai;
            this.technikine = technikine;
            this.kuras = kuras;

        }

        abstract public bool Palyginimas();

        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0,-12}{1,-10}{2,-13}{3,-14}{4,-14:yyyy-MM}{5,-15}{6,-14}",
            numeris, gamintojas, modelis, spalva, pagaminmetai, technikine.ToString("d"), kuras);
            return eilute;
        }

        //public int CompareTo(Automobilis kita)
        //{
        //    int poz = String.Compare(this.gamintojas, kita.gamintojas,
        //    StringComparison.CurrentCulture);
        //    if ((this.technikine.Year < kita.technikine.Year) ||
        //    ((this.technikine.Year == kita.technikine.Year) && (poz > 0)))
        //        return 1;
        //    else
        //        return -1;
        //}


        public static bool operator > (Automobilis auto1, Automobilis auto2)
        {

            return auto1.technikine.Year > auto2.technikine.Year ||
                          (auto1.technikine.Year == auto2.technikine.Year && String.Compare(auto1.gamintojas, auto2.gamintojas, StringComparison.CurrentCulture) == 1);
        }

        public static bool operator < (Automobilis auto1, Automobilis auto2)
        {

            return auto1.technikine.Year < auto2.technikine.Year ||
                          (auto1.technikine.Year == auto2.technikine.Year && String.Compare(auto1.gamintojas, auto2.gamintojas, StringComparison.CurrentCulture) == 1);
        }

    }
}
