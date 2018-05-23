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

//U1-14. Viešasis transportas.
//Miesto viešojo transporto(autobusų ir troleibusų) maršrutų duomenys yra dviejuose failuose.Pirmoje eilutėje yra
//transporto įmonės pavadinimas, kitose eilutėse: maršruto numeris, maršruto pavadinimas, ilgis kilometrais ir stotelių
//skaičius.
//L1+L2+L4.
//+ Raskite kiekvienos transporto rūšies bendrą maršrutų ilgį.
//+ Sudarykite bendrą sąrašą tokių maršutų, kurių ilgiai yra intevale[a; b].
//+ Surikiuokite suformuotą sąrašą pagal stotelių skaičių.
//- Pašalinkite iš rezultatų sąrašo maršutus, kurių pavadinime yra nurodytas žodis

namespace L4_Viesasis_transportas
{
    public partial class Form1 : Form
    {
        const string CFr = "..\\..\\Rezultatai.txt";
        const string CFd1 = "..\\..\\Autobusai.txt";
        const string CFu = "..\\..\\uzduotis.txt";

        Sarasas Autobusai;
        Sarasas Troleibusai;
        Sarasas Naujas;
        string pav1,pav2;


        public Form1()
        {
            InitializeComponent();

            if (File.Exists(CFr))
                File.Delete(CFr);
        }

        //---------------------------------
        // MYGTUKAI
        //---------------------------------

        private void autobusaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt) |*.txt|All files (*.*)|*.*";
            openFileDialog1.Title = "Pasirinkite duomenu faila";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fv = openFileDialog1.FileName;
                Autobusai = SkaitytiTransp(fv, out pav1);
                SpausdintiTransp(CFr, Autobusai, "Autobusu marsrutai", pav1);
                rezultatai.LoadFile(CFr, RichTextBoxStreamType.PlainText);
                troleibusaiToolStripMenuItem.Enabled = true;
                autobusaiToolStripMenuItem.Enabled = false;
            }

        }

        private void troleibusaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt) |*.txt|All files (*.*)|*.*";
            openFileDialog1.Title = "Pasirinkite duomenu faila";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fv = openFileDialog1.FileName;
                Troleibusai = SkaitytiTransp(fv, out pav2);
                SpausdintiTransp(CFr, Troleibusai, "Troleibusu marsrutai", pav1);
                rezultatai.LoadFile(CFr, RichTextBoxStreamType.PlainText);
                troleibusaiToolStripMenuItem.Enabled = true;
                autobusaiToolStripMenuItem.Enabled = false;
            }
        }


        private void skaičiavimaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //------------------------------------------------------------
            // Raskite kiekvienos transporto rūšies bendrą maršrutų ilgį.
            //------------------------------------------------------------

            int suma1 = 0;
            int suma2 = 0;
            BendrasMarsrutuIlgis(Autobusai, out suma1);
            BendrasMarsrutuIlgis(Troleibusai, out suma2);

            using (var fr = new StreamWriter(File.Open(CFr, FileMode.Append), Encoding.GetEncoding(1257)))
            {
                
                fr.WriteLine("Autobusu marsrutu ilgis yra: {0} km, o troleibusu: {1} km\n", suma1,suma2);
            }


            //--------------------------------------------------------------------------
            // Sudarykite bendrą sąrašą tokių maršutų, kurių ilgiai yra intevale[a; b].
            //--------------------------------------------------------------------------

            Naujas = new Sarasas();

            int a = Convert.ToInt32(areiksme.Text);
            int b = Convert.ToInt32(breiksme.Text);

            Intervalas(Autobusai, Naujas, a, b);
            Intervalas(Troleibusai, Naujas, a, b);

            SpausdintiTransp(CFr, Naujas, "Naujas sarasas", "Bendras sarasas");

            //--------------------------------------------------------------------------
            // Surikiuokite suformuotą sąrašą pagal stotelių skaičių.
            //--------------------------------------------------------------------------

            Naujas.Burbulas();
            SpausdintiTransp(CFr,Naujas,"Surikiuotas sarasas", "Bendras sarasas");

            //--------------------------------------------------------------------------------
            // Pašalinkite iš rezultatų sąrašo maršutus, kurių pavadinime yra nurodytas žodis
            //--------------------------------------------------------------------------------
            string zodis = nurodytaszodis.Text;

            Ismesti(Naujas, zodis);
            SpausdintiTransp(CFr, Naujas, "Su ismestu zodziu", "Bendras sarasas");

            //----------------------------------------------------------
            rezultatai.LoadFile(CFr, RichTextBoxStreamType.PlainText);

        }

        private void pagalbaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamReader tekstas = new StreamReader(CFu, Encoding.GetEncoding(1257));
            MessageBox.Show(tekstas.ReadToEnd());
            tekstas.Close();
        }

        //-------------------------------------
        // METODAI
        //-------------------------------------

        /// <summary>
        /// Duomenų nuskaitymo metodas
        /// </summary>
        /// <param name="fv"> Duomenų failas </param>
        /// <param name="imone"> Įmonės pavadinimas </param>
        /// <returns></returns>
        static Sarasas SkaitytiTransp (string fv, out string imone)
        {

            var Transp = new Sarasas();
            using (StreamReader srautas = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                string eilute;
                eilute = srautas.ReadLine();
                imone = eilute;
                while ((eilute = srautas.ReadLine()) != null)
                {
                    string[] eilDalis = eilute.Split(';');
                    int numeris = int.Parse(eilDalis[0]);
                    string pav = eilDalis[1];
                    int ilgis = int.Parse(eilDalis[2]);
                    int stotsk = int.Parse(eilDalis[3]);
                    Transportas transportas = new Transportas(numeris, pav, ilgis, stotsk);
                    Transp.DetiTies(transportas);
                }
            }
            return Transp;
        }

        
        /// <summary>
        /// Spausdinimo metodas
        /// </summary>
        /// <param name="fv"> Rezultatų failas </param>
        /// <param name="Transp"> Transporto sąrašas </param>
        /// <param name="antraste"> Antraštė apie duomenis</param>
        /// <param name="imone"> Transporto įmonė </param>
        /// <param name="fm"></param>
        
        static void SpausdintiTransp(string fv, Sarasas Transp, string antraste, string imone, FileMode fm = FileMode.Append)
        {

            const string virsus =
            "---------------------------------------------------------------------\r\n"
            + "Nr.        Marsrutas              Kelio ilgis   Stoteliu skaicius \r\n"
            + "---------------------------------------------------------------------";

            using (var fr = new StreamWriter(File.Open(fv, FileMode.Append),
            Encoding.GetEncoding(1257)))
            {
                Transp.Pradzia();
                if (Transp.Yra()) 
                {
                    fr.WriteLine(imone);
                    fr.WriteLine("\n " + antraste);
                    fr.WriteLine(virsus);
                    for (Transp.Pradzia();Transp.Yra();Transp.Kitas())
                    {
                        fr.WriteLine(Transp.ImtiDuomenis().ToString());
                    }
                    fr.WriteLine("---------------------------------------------------------------------\n");
                }
                else
                fr.WriteLine("Sąrašo nėra");
            }
        }

        /// <summary>
        /// Skaičiuojamami bendri maršrutų ilgiai
        /// </summary>
        /// <param name="TransportasKont"> Transporto duomenys </param>
        /// <param name="suma"> ilgis </param>

        static void BendrasMarsrutuIlgis(Sarasas Transp, out int suma)
        {
            suma = 0;

            for (Transp.Pradzia(); Transp.Yra(); Transp.Kitas())
            {
                suma = suma + Transp.ImtiDuomenis().ilgis;
            }

        }

        /// <summary>
        /// Sudaro naują sąrašą nurodytame intervale
        /// </summary>
        /// <param name="senas"></param>
        /// <param name="naujas"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
       
        static void Intervalas(Sarasas senas, Sarasas naujas, int a, int b)
        {

            for (senas.Pradzia();senas.Yra();senas.Kitas())
            {
                if (a <= senas.ImtiDuomenis().ilgis && b >= senas.ImtiDuomenis().ilgis)
                {
                    naujas.DetiAtv(senas.ImtiDuomenis());
                }
            }
        }

        /// <summary>
        /// Šalinimo metodas
        /// </summary>
        /// <param name="naujas"></param>
        /// <param name="zodis"></param>

        static void Ismesti(Sarasas naujas, string zodis)
        {
            for (naujas.Pradzia(); naujas.Yra(); naujas.Kitas())
            {
                if (naujas.ImtiDuomenis().pav.Contains(zodis))
                {
                    naujas.ElementoNaikinimas(naujas.ImtiDuomenis());
                }
            }
        }

        //--
    }
}
