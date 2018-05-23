using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L14_Studentu_Stipendijos_L5
{
    public class AsmeniniaiDuom : IComparable<AsmeniniaiDuom>
    {
        public string pavarde { get; set; }
        public string vardas { get; set; }
        public int numeris { get; set; }
        public double Stipendija { get; set; }
  

        public AsmeniniaiDuom(string pavarde, string vardas, int numeris)
            
        {
            this.pavarde = pavarde;
            this.vardas = vardas;
            this.numeris = numeris;
            Stipendija = 0;
        }

        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0,-16} {1,-12} {2,-16} {3,2:f} ", pavarde,vardas, numeris,Stipendija);
            return eilute;
        }

        public override bool Equals(object obj)
        {
            AsmeniniaiDuom elem = obj as AsmeniniaiDuom;
            return elem.pavarde == pavarde && elem.vardas==vardas && elem.numeris == numeris;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(AsmeniniaiDuom kitas)
        {
            if (kitas == null) return -1;
            if (pavarde.CompareTo(kitas.pavarde) != 0)
                return pavarde.CompareTo(kitas.pavarde);
            else return vardas.CompareTo(kitas.vardas);
        }

        public void detiStipendija(double s)
        {
            Stipendija = s;
        }
    }
}
