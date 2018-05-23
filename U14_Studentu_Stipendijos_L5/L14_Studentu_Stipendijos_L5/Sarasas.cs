using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L14_Studentu_Stipendijos_L5
{
    public sealed class Sarasas<Tipas> where Tipas : IComparable<Tipas>
    {
        private Mazgas<Tipas> pr;
        private Mazgas<Tipas> d;
        private Mazgas<Tipas> pb;

        public Sarasas()
        {
            this.pr = null;
            this.d = null;
            this.pb = null;
        }

        public void Kitas()
        {
            d = d.Kitas;
        }

        public void Pradzia()
        {
            d = pr;
        }

        public bool Yra()
        {
            return d != null;
        }

        //Tiesioginis sąrašas
        public void DetiTies(Tipas inf)
        {
            var d1 = new Mazgas<Tipas>(inf, null);

            if (pr != null)
            {
                pb.Kitas = d1;
                pb = pb.Kitas;
            }
            else // jei sarasas tuscias
            {
                pr = d1;
                pb = pr;
            }
        }

        // Atvirkštinis sąrašas
        //public void DetiAtv(Tipas inf)
        //{
        //    var d1 = new Mazgas<Tipas>(inf, null);
        //    d1.Kitas = pr;
        //    pr = d1;
        //}

        public Tipas ImtiDuomenis()
        {
           return d.Duomenys; 
        }

        //-----------

        public Tipas GautiS(int i)
        {
            Mazgas<Tipas> dd = pr as Mazgas<Tipas>;
            while (i > 0)
            {
                dd = dd.Kitas;
                i--;
            }
            return dd.Duomenys;
        }
    }
}
 
