using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L4_Viesasis_transportas
{
    public class Transportas
    {
        public int numeris { get; set; }
        public string pav { get; set; }
        public int ilgis { get; set; }
        public int stotsk { get; set; }

        public Transportas (int numeris = 0, string pav = "", int ilgis = 0, int stotsk = 0)
        {
            this.numeris = numeris;
            this.pav = pav;
            this.ilgis = ilgis;
            this.stotsk = stotsk;
        }

        void Deti(int a, string b, int c, int d)
        {
            numeris = a;
            pav = b;
            ilgis = c;
            stotsk = d;
        }

        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0,-3:D} {1,-30} {2,5} {3,15}", numeris, pav, ilgis, stotsk); 
            return eilute;
        }

        public override bool Equals(object obj)
        {
            Transportas elem = obj as Transportas;
            return elem.numeris == numeris && elem.pav == pav && elem.ilgis == ilgis && elem.stotsk == stotsk;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // Užklojimo metodai

        public static bool operator >(Transportas transp1, Transportas transp2)
        {

            return transp1.stotsk > transp2.stotsk || (transp1.stotsk == transp2.stotsk && String.Compare(transp1.pav, transp2.pav, StringComparison.CurrentCulture) == 1);
        }

        public static bool operator <(Transportas transp1, Transportas transp2)
        {
            return transp1.stotsk < transp2.stotsk || (transp1.stotsk == transp2.stotsk && String.Compare(transp1.pav, transp2.pav, StringComparison.CurrentCulture) == 1);
        }
    }
}
