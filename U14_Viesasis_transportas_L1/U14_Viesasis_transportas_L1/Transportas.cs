using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U14_Viesasis_transportas_L1
{
    class Transportas
    {
        public int numeris { get; set; }
        public string pav { get; set; }
        public int ilgis { get; set; }
        public int stotsk { get; set; }

        public Transportas(int numeris, string pav, int ilgis, int stotsk)
        {
            this.numeris = numeris;
            this.pav = pav;
            this.ilgis = ilgis;
            this.stotsk = stotsk;
        }
        public int ImtiNumeri() { return numeris; }
        public string ImtiPav() { return pav; }
        public int ImtiIlgi() { return ilgis; }
        public int ImtiStotSk() { return stotsk; }

        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0,-3} {1,-30} {2,5} {3,15}", numeris,pav,ilgis,stotsk);
            return eilute;
        }

        // Užklojimo metodai

        public static bool operator >(Transportas transp1, Transportas transp2)
        {
            return transp1.stotsk > transp2.stotsk;
        }

        public static bool operator <(Transportas transp1, Transportas transp2)
        {
            return transp1.stotsk < transp2.stotsk;
        }
    }
}
