using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L4_Viesasis_transportas
{
    public sealed class Mazgas
    {
        public Transportas Duomenys { get; set; }
        public Mazgas Kitas { get; set; }

        public Mazgas() { }

        public Mazgas (Transportas inf, Mazgas adresas)
        {
            Duomenys = inf;
            Kitas = adresas;
        }
    }
}
