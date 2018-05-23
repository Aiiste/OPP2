// Aistė Sudintaitė, IFZ-6/2

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

//L5_14. Stipendijos. 
//Studentų stipendijoms yra skiriamas nurodyto dydžio fondas. 
//Studentui skiriama stipendija, jei jo pažymių vidurkis viršija nurodytą dydį ir jis neturi skolų(visi pažymiai >4).
//Studentui skiriama 10% didesnė stipendija, jei jo visi pažymiai didesni už 8. Toks studentas vadinamas pirmūnu.
//Paskirstykite studentams stipendijas pagal duotą fondą.
//Fondą reikia maksimaliai išnaudoti, bet negalima viršyti fondo dydžio.
//Duomenys:
//* Tekstiniame faile U14a.txt duoti studentų asmeniniai duomenys: pavardė ir vardas, telefono
//numeris.
//* Tekstiniame faile U14b.txt pateikta studentų tarnybinė informacija.Pirmojoje failo eilutėje
//nurodytas stipendijų fondo dydis ir pažymių vidurkis stipendijai gauti. Tolimesnėse eilutėse
//tokia informacija: studento pavardė ir vardas, grupė, pažymių kiekis, pažymiai.

namespace L14_Studentu_Stipendijos_L5
{
    public partial class Form1 : Form
    {
        const string CFda = "..\\..\\U14a.txt";
        const string CFdb = "..\\..\\U14b.txt";
        const string CFda2 = "..\\..\\U14a2.txt";
        const string CFdb2 = "..\\..\\U14b2.txt";
        const string CFr = "..\\..\\rezultatai.txt";
        const int Cn = 100;

        private Sarasas<AsmeniniaiDuom> AsmDuom;
        private Sarasas<TarnybiniaiDuom> TarnybDuom;
        
        private int fondas = 0;
        private double vidurkis = 0;

        public Form1()
        {
            if (File.Exists(CFr))
                File.Delete(CFr);

            InitializeComponent();
        }

        //-------------------------------------
        // M Y G T U K A I
        //-------------------------------------

        private void įvestiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AsmDuom=SkaitytiAsmeniniusDuom(CFda2);
            
            TarnybDuom = SkaitytiTarnybiniusDuom(CFdb2,out fondas,out vidurkis);
            Spausdinti2(CFr,AsmDuom,"Pradiniai duomenys");
            string uzrasas= "Studiju fonde yra: " + fondas + " o minimalus vidurkis yra " + vidurkis;
            Spausdinti2(CFr, TarnybDuom, uzrasas);
            //Spausdinti(CFr,TarnybDuom,fondas,vidurkis,"Pradiniai duomenys");
            rezultatai.LoadFile(CFr, RichTextBoxStreamType.PlainText);
        }

        private void skaičiavimaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //--------------
            double stipendija = 0;

            Stipendijos(TarnybDuom, fondas, vidurkis, ref stipendija);
            detiStipendijas(TarnybDuom, ref AsmDuom, vidurkis, stipendija);
            Spausdinti2(CFr, AsmDuom,"Duomenys su paskirstytomis stipendijomis");

            rezultatai.LoadFile(CFr, RichTextBoxStreamType.PlainText);
        }
        //-------------------------------------
        // M E T O D A I
        //-------------------------------------

        /// <summary>
        /// Asmeninių duomenų nuskaitymas
        /// </summary>
        /// <param name="fv"> Duomenų failas</param>
        /// <returns></returns>

        static Sarasas<AsmeniniaiDuom> SkaitytiAsmeniniusDuom(string fv)
        {
            var A = new Sarasas<AsmeniniaiDuom>();
            using (StreamReader reader = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    string pavarde = parts[0];
                    string vardas = parts[1];
                    int numeris = int.Parse(parts[2]);
                    AsmeniniaiDuom asmeniniaiduom = new AsmeniniaiDuom(pavarde,vardas,numeris);
                    A.DetiTies(asmeniniaiduom);
                }
            }

            return A;
        }
        
        /// <summary>
        /// Tarnybinių duomenų nuskaitymas
        /// </summary>
        /// <param name="fv"> Duomenų failas </param>
        /// <returns></returns>

        static Sarasas<TarnybiniaiDuom> SkaitytiTarnybiniusDuom(string fv, out int fondas, out double vidurkis)
        {
          
            var A = new Sarasas<TarnybiniaiDuom>();
            using (StreamReader reader = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                string line;
                line = reader.ReadLine();
                string[] duom = line.Split(' ');
                fondas = Convert.ToInt32(duom[0]);
                vidurkis = Convert.ToDouble(duom[1]);

                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    string pavarde = parts[0];
                    string vardas = parts[1];
                    string grupe = parts[2];
                    int kiekis = int.Parse(parts[3]);
                    string[] pazymiai = parts[4].Split(',');
                    List<int> paz = new List<int>();
                    foreach (string p in pazymiai)
                    {
                        paz.Add(Convert.ToInt32(p));

                    }
                    TarnybiniaiDuom tarnybiniaiduom = new TarnybiniaiDuom(pavarde, vardas, grupe, kiekis, paz);
                    A.DetiTies(tarnybiniaiduom);
                }
            }

            return A;
        }

        //static void Spausdinti(string fv, Sarasas<TarnybiniaiDuom> Duomenys, int fondas, double vidurkis, string uzrasas) 
        //{
        //    const string lentele = "-----------------------------------------------------------------------------------\r\n" +
        //                           "| Pavarde        Vardas      Grupe      Paz.Kiekis        Pazymiai       Vidurkis |\r\n" +
        //                           "-----------------------------------------------------------------------------------";
          
            
        //    using (var failas = new StreamWriter(File.Open(fv, FileMode.Append), Encoding.GetEncoding(1257)))
        //    {
        //        failas.WriteLine("Studiju fonde yra: {0} eur, o minimalus vidurkis yra {1}",fondas,vidurkis);
        //        failas.WriteLine(uzrasas);
        //        failas.WriteLine(lentele);
        //        //---------------------------------------------------
        //        for (Duomenys.Pradzia(); Duomenys.Yra(); Duomenys.Kitas())
        //        {
        //            failas.WriteLine("{0}", Duomenys.ImtiDuomenis().ToString());
        //        }
        //        failas.WriteLine("-----------------------------------------------------------------------------------\r\n");
            
        //    }
        //}
        //---------------------------
        static void Spausdinti2<Tipas>(string fv, Sarasas<Tipas> duom, string uzrasas) where Tipas : IComparable<Tipas>
        {
            const string lentele = "-----------------------------------------------------------------------------------\r\n" +
                                 "| Pavarde        Vardas      Grupe      Paz.Kiekis        Pazymiai       Vidurkis |\r\n" +
                                 "-----------------------------------------------------------------------------------";

            const string lentele2 = "---------------------------------------------------------\r\n" +
                                   "| Pavarde        Vardas     Telefono nr.      Stipendija|\r\n" +
                                   "---------------------------------------------------------";

            using (var fr = new StreamWriter(File.Open(fv, FileMode.Append), Encoding.GetEncoding(1257)))
            {
                fr.WriteLine(uzrasas);
                duom.Pradzia();
                if (duom.Yra())
                {
                   if (typeof(Tipas) == typeof(AsmeniniaiDuom))
                      {
                        fr.WriteLine(lentele2);
                      }
                   else fr.WriteLine(lentele);
                }

                //---------------------------------------------------
                for (duom.Pradzia(); duom.Yra(); duom.Kitas())
                {
                    fr.WriteLine("{0}", duom.ImtiDuomenis().ToString());
                }
                duom.Pradzia();
                if (duom.Yra())
                {
                    if (typeof(Tipas) == typeof(AsmeniniaiDuom))
                    {
                        fr.WriteLine("---------------------------------------------------------\r\n");
                    }
                    else fr.WriteLine("-----------------------------------------------------------------------------------\r\n");
                }
                 
            }
        }
       
        //==================================================================================


        static void Stipendijos(Sarasas<TarnybiniaiDuom> duom, int fondas, double Vid, ref double Stipendija)
        {
            int studentuKiekis = 0;
            int PirmunuKiekis = 0;
            for (duom.Pradzia(); duom.Yra(); duom.Kitas())
            {

                if(duom.ImtiDuomenis().NeturiSkolu(Vid))// neturi skolu ir vid didesnis uz nurodyta
                  {
                     studentuKiekis++;
                  }

                 if(duom.ImtiDuomenis().Pirmunas()) // visi pazymiai > 8
                  {
                     PirmunuKiekis++;
                  }

            }

            duom.Pradzia();
            Stipendija = fondas / (0.1 * PirmunuKiekis + studentuKiekis);
        }

        //----------------

        static void detiStipendijas(Sarasas<TarnybiniaiDuom> duom, ref Sarasas<AsmeniniaiDuom> stud, double vid, double Stipendija)
        {
            int Sk = 0; // studento indeksas
            for (duom.Pradzia(); duom.Yra(); duom.Kitas())
            {
                    // pirmunai
                    if (duom.ImtiDuomenis().Pirmunas())
                    {
                        stud.GautiS(Sk).detiStipendija(1.1 * Stipendija);
                    }
                    // be skolu
                    else if (duom.ImtiDuomenis().NeturiSkolu(vid))
                    {
                        stud.GautiS(Sk).detiStipendija(Stipendija);
                    }
              Sk++;  
            }
            //------------------------

        }
    }
}
