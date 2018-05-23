using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L14_Studentu_Stipendijos_L5
{
     public class TarnybiniaiDuom: IComparable<TarnybiniaiDuom>
    {
        
        public string pavarde { get; set; }
        public string vardas { get; set; }
        public string grupe { get; set; }
        public int kiekis { get; set; }
        public List<int> Pazymiai;
        public double Vidurkis { get; set; }
      
      
        public TarnybiniaiDuom(string pavarde, string vardas, string grupe,int kiekis, List<int> Pazymiai)
        {
            this.pavarde = pavarde;
            this.vardas = vardas;
            this.grupe = grupe;
            this.kiekis = kiekis;
            this.Pazymiai = Pazymiai;
            int suma = 0;
            foreach (int i in Pazymiai)
            {
                suma += i;
            }
            Vidurkis = suma / Pazymiai.Count;
            
        }

        public override string ToString()
        {
            string eilute;
            string pazymiai = "";

            for (int i = 0; i < Pazymiai.Count; i++)
            {
                pazymiai += Pazymiai[i] + (" ");
            }

            eilute = string.Format("{0,-16} {1,-10} {2,-16} {3,-10}{4,-20} {5}", pavarde, vardas,grupe, kiekis,pazymiai, Vidurkis);
            
            return eilute;
        }
      
    
        public override bool Equals(object obj)
        {
            TarnybiniaiDuom elem = obj as TarnybiniaiDuom;
            return elem.pavarde == pavarde && elem.vardas == vardas && elem.kiekis==kiekis;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(TarnybiniaiDuom kitas)
        {
            if (kitas == null) return -1;
            if (pavarde.CompareTo(kitas.pavarde) != 0)
                return pavarde.CompareTo(kitas.pavarde);
            else return vardas.CompareTo(kitas.vardas);
        }
        //--------------


        public bool NeturiSkolu(double Vid)
        {

            if (Vidurkis < Vid)
            {
                return false;
            }
            if (Pazymiai.Min() < 5)
            {
                return false;
            }

            return true;
        }

        //Iesko pirmunu
        public bool Pirmunas()
        {
            if (Pazymiai.Min() < 8)
            {
                return false;
            }

            return true;
        }
    }
}
