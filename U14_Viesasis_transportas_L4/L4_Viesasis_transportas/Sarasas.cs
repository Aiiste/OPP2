using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L4_Viesasis_transportas
{
    public sealed class Sarasas
    {
        private Mazgas pr;
        private Mazgas d;
        private Mazgas pb;

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

        public void Pradzia ()
        {
            d = pr;
        }

        public bool Yra()
        {
            return d!=null;
        }

        public void Papildyti(Transportas duom)
        {
            Mazgas d1 = new Mazgas();
            d1.Duomenys = duom;
            // if(pr==null)
            //    pb=d1;
            d1.Kitas = pr;
            pr = d1;
        }

        //Tiesioginis sąrašas
        public void DetiTies(Transportas inf)
        {

            var d1 = new Mazgas(inf, null);

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
        public void DetiAtv(Transportas inf)
        {
            var d1 = new Mazgas(inf, null);
            d1.Kitas = pr;
            pr = d1;
        }

        public Transportas ImtiDuomenis()
        {
            return d.Duomenys;
        }

        // Sunaikinamas sarasas
        public void Naikinti()
        {
            while (pr != null)
            {
                d = pr;
                pr = pr.Kitas;
                // d.Duomenys = null;
                d = null;
            }
            d = pr;
        }


        public void ElementoNaikinimas(Transportas inf)
        {
            Mazgas vieta = null;

            for (Mazgas dd = pr; dd.Duomenys != inf; dd = dd.Kitas) // randa pries salinama esanti mazga
                vieta = dd;

            if(vieta==null) // pasalinam pirma
            {
                Mazgas d = pr;
                pr = pr.Kitas;
                d = null;
            }
            else // salinam viduje arba gale
            {
                Mazgas saliniamas = vieta.Kitas;
                vieta.Kitas = saliniamas.Kitas;
                saliniamas = null;
            }
        }

        // Rikiavimas burbuliuko metodu
        public void Burbulas()
        {
            if (pr == null) { return; }
            bool keista = true;
            while (keista)
            {
                keista = false;
                Mazgas d = pr;
                while (d.Kitas != null)
                {
                    if (d.Kitas.Duomenys < d.Duomenys)
                    {
                        Transportas Sk = d.Duomenys;
                        d.Duomenys = d.Kitas.Duomenys;
                        d.Kitas.Duomenys = Sk;
                        keista = true;
                    }

                    d = d.Kitas;
                }
            }
        }

        //----------------------------------

    }
}
