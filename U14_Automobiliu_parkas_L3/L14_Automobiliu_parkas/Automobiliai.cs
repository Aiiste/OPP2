using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L14_Automobiliu_parkas
{
      public class Automobiliai : Automobilis
    {
        public double kurosanaudos { get; set; }

        /** konstruktorius be parametrų */
        public Automobiliai()
        {

        }

        /** konstruktorius su parametrais */
        public Automobiliai(string numeris, string gamintojas, string modelis, string spalva,
            DateTime pagaminmetai, DateTime technikine, string kuras, double kurosanaudos = 0.0)
        : base(numeris, gamintojas, modelis, spalva, pagaminmetai, technikine, kuras)
        {
            this.kurosanaudos = kurosanaudos;
        }

        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0} {1}", base.ToString(), kurosanaudos);
            return eilute;
        }

        //-------------------------------------------------------------------------

        public override bool Palyginimas()
        {
            if (spalva.Count() > 0) return true;
            else return false;

        }
    }
}
