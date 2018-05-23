//Aistė Sudintaitė, IFZ- 6/2
//P175B117

//U1-14. Viešasis transportas.
//Miesto viešojo transporto(autobusų ir troleibusų) maršrutų duomenys yra dviejuose failuose.Pirmoje eilutėje yra
//transporto įmonės pavadinimas, kitose eilutėse: maršruto numeris, maršruto pavadinimas, ilgis kilometrais ir stotelių
//skaičius.
//L1+L2+L4.
// Raskite kiekvienos transporto rūšies bendrą maršrutų ilgį.
// Sudarykite bendrą sąrašą tokių maršutų, kurių ilgiai yra intevale[a; b].
// Surikiuokite suformuotą sąrašą pagal stotelių skaičių.
// Pašalinkite iš rezultatų sąrašo maršutus, kurių pavadinime yra nurodytas žodis

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

namespace U14_Viesasis_transportas_L1
{
    public partial class Form1 : Form
    {
        const string CFd1 = "..\\..\\Autobusai.txt";
        const string CFd2 = "..\\..\\Troleibusai.txt";
        const string CFt = "..\\..\\Tuscias.txt";
        const string CFi = "..\\..\\Iterpimas.txt";
        const string CFu = "..\\..\\Uzduotis.txt";
        const string CFr = "..\\..\\Rezultatai.txt";
        const string CFn = "..\\..\\Nurodymai.txt";
        const string CFr2 = "..\\..\\Rez.csv";

        private List<Transportas> Autobusai; // Autobusų konteineris
        private List<Transportas> Troleibusai; // Troleibusų konteineris
        private List<Transportas> NaujasS; // Naujas bendras konteineris
        private List<Transportas> Papildomas; // iterpimo

        string pavv1, pavv2,pavv3; // Įmonių pavadinimai

        public Form1()
        {
            InitializeComponent();

            if (File.Exists(CFr))
                File.Delete(CFr);

            if (File.Exists(CFr2))
                File.Delete(CFr2);

            rastiToolStripMenuItem.Enabled = false;
            sąrašasToolStripMenuItem.Enabled = false;
            rikiuotiToolStripMenuItem.Enabled = false;
            šalinimasToolStripMenuItem.Enabled = false;
            iterpimas2ToolStripMenuItem.Enabled = false;

        }

        private void autobusaiToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt) |*.txt|All files (*.*)|*.*";
            openFileDialog1.Title = "Pasirinkite rezultatu faila";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fv = openFileDialog1.FileName;
                Autobusai = SkaitytiTranspKont(fv, out pavv1);
                SpausdintiTranspKont(CFr, Autobusai, "Autobusu marsrutai", pavv1);
                rezultatai.LoadFile(CFr, RichTextBoxStreamType.PlainText);
                troleibusaiToolStripMenuItem.Enabled = true;
                autobusaiToolStripMenuItem.Enabled = false;
            }
        }

        private void troleibusaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt) |*.txt|All files (*.*)|*.*";
            openFileDialog1.Title = "Pasirinkite rezultatu faila";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fv = openFileDialog1.FileName;
                Troleibusai = SkaitytiTranspKont(fv, out pavv2);
                SpausdintiTranspKont(CFr, Troleibusai, "Troleibusu marsrutai", pavv2);
                rezultatai.LoadFile(CFr, RichTextBoxStreamType.PlainText);
                rastiToolStripMenuItem.Enabled = true;

            }
        }

        private void papildomasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Title = "Pasirinkite duomenų failą";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fv = openFileDialog1.FileName;
                Papildomas = SkaitytiTranspKont(fv, out pavv3);
                SpausdintiTranspKont(CFr, Papildomas, "Iterpimui skirtas sarasas", "Naujas sarasas");
                rezultatai.LoadFile(CFr, RichTextBoxStreamType.PlainText);
            }
        }

        private void įvestiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rastiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int suma1 = 0;
            int suma2 = 0;
            BendrasMarsrutuIlgis(Autobusai, out suma1);
            BendrasMarsrutuIlgis(Troleibusai, out suma2);

           Ilgis.Text = "Autobusu kelio ilgis " + suma1 + " km, \no Troleibusų - " + suma2 + "km";

            sąrašasToolStripMenuItem.Enabled = true;

        }

        private void sąrašasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(areiksme.Text);
            int b = Convert.ToInt32(breiksme.Text);

            NaujasS = new List<Transportas>();

            Intervalas(Autobusai, NaujasS, a, b);
            Intervalas(Troleibusai, NaujasS, a, b);

            SpausdintiTranspKont(CFr, NaujasS, "Naujas sarasas", "Bendras sarasas");

            rezultatai.LoadFile(CFr, RichTextBoxStreamType.PlainText);
            rikiuotiToolStripMenuItem.Enabled = true;
        }

        private void rikiuotiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NaujasS = Rikiavimas(NaujasS);
            SpausdintiTranspKont(CFr, NaujasS, "Rikiuotas sąrasas", "Bendras sarasas");
            rezultatai.LoadFile(CFr, RichTextBoxStreamType.PlainText);
            šalinimasToolStripMenuItem.Enabled = true;
        }

        private void šalinimasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string zodis = nurodytaszodis.Text;
            Ismesti(NaujasS, zodis);
            SpausdintiTranspKont(CFr,NaujasS,"Sarasas su ismestu zodziu","Bendras sarasas");
            rezultatai.LoadFile(CFr, RichTextBoxStreamType.PlainText);
            iterpimas2ToolStripMenuItem.Enabled = true;

        }

        private void iterpimas2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NaujasS = Iterpimoisvedimas(NaujasS,Papildomas);
            SpausdintiTranspKont(CFr, NaujasS, "Papildytas sarasas", "bendras sarasas");
            SpausdintiCSV(CFr2, NaujasS);
            rezultatai.LoadFile(CFr, RichTextBoxStreamType.PlainText);
        }


        private void užduotisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamReader tekstas = new StreamReader(CFu, Encoding.GetEncoding(1257));
            MessageBox.Show(tekstas.ReadToEnd());
            tekstas.Close();
        }

        private void nurodymaiVartotojuiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamReader tekstas = new StreamReader(CFn, Encoding.GetEncoding(1257));
            MessageBox.Show(tekstas.ReadToEnd());
            tekstas.Close();
        }

        private void baigtiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        // METODAI

        /// <summary>
        /// Duomenų nuskaitymas
        /// </summary>
        /// <param name="fv"> duomenų failas </param>
        /// <returns></returns>

        static List<Transportas> SkaitytiTranspKont(string fv,out string imone)
        {
           
            List<Transportas> TransportasKont = new List<Transportas>();
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
                    Transportas transportas = new Transportas(numeris,pav,ilgis,stotsk);
                    TransportasKont.Add(transportas);
                }
            }
            return TransportasKont;
        }


        /// <summary>
        /// Duomenų atspausdinimo metodas
        /// </summary>
        /// <param name="fv"> Duomenų failas</param>
        /// <param name="TransportasKont"> LIST sąrašas </param>
        /// <param name="antraste"> antraste </param>

        static void SpausdintiTranspKont(string fv, List<Transportas> TransportasKont, string antraste,string imone,FileMode fm = FileMode.Append)
        {

            const string virsus =
            "---------------------------------------------------------------------\r\n"
            + "Nr.        Marsrutas              Kelio ilgis   Stoteliu skaicius \r\n"
            + "---------------------------------------------------------------------";

            using (var fr = new StreamWriter(File.Open(fv, FileMode.Append),
            Encoding.GetEncoding(1257)))
            {
                if (TransportasKont.Count == 0) fr.WriteLine("Sąrašo nėra");
                else
                {
                    fr.WriteLine(imone);
                    fr.WriteLine("\n " + antraste);
                    fr.WriteLine(virsus);
                    for (int i = 0; i < TransportasKont.Count; i++)
                    {
                        Transportas kn = TransportasKont[i];
                        fr.WriteLine("{0}", kn);
                    }
                    fr.WriteLine("---------------------------------------------------------------------\n");
                }
            }
        }

        /// <summary>
        /// Skaičiuojamami bendri maršrutų ilgiai
        /// </summary>
        /// <param name="TransportasKont"> LIST sąrašas </param>
        /// <param name="suma"> ilgis </param>

        static void BendrasMarsrutuIlgis(List<Transportas> TransportasKont,out int suma)
        {
             suma = 0;

            for (int i = 0; i < TransportasKont.Count; i++)
            {
                Transportas kn = TransportasKont[i];
                suma = suma + kn.ilgis;
            }

        }

        /// <summary>
        /// Randa maršrutus kurie yra intervale [a;b]
        /// </summary>
        /// <param name="TransportasKont"> LIST sąrašas </param>
        /// <param name="naujas"> Naujas sąrašas </param>
        /// <param name="a"> intervalo a reikšmė </param>
        /// <param name="b"> intervalo b reikšmė </param>

        static void Intervalas( List<Transportas> TransportasKont,List<Transportas> naujas, int a, int b)
        {
           
            for (int i = 0; i < TransportasKont.Count; i++)
            {
                Transportas kn = TransportasKont[i];

                if (a <= kn.ilgis && b >= kn.ilgis)
                {
                   naujas.Add(TransportasKont[i]);
                }
            }
         }

        /// <summary>
        /// Rikiavimo metodas
        /// </summary>
        /// <param name="TransportasKont"> LIST sąrašas </param>
        /// <returns></returns>
        
        private List<Transportas> Rikiavimas(List<Transportas> TransportasKont)
        {
            int i = 0;
            bool bk = true;
            while (bk)
            {
                bk = false;
                for (int j = TransportasKont.Count - 1; j > i; j--)
                    if (TransportasKont[j] > TransportasKont[j - 1])
                    {
                        bk = true;
                        Transportas transportas = TransportasKont[j];
                        TransportasKont[j] = TransportasKont[j - 1];
                        TransportasKont[j - 1] = transportas;
                    }
                i++;
            }
            return TransportasKont;
        }

        /// <summary>
        /// Šalinimo metodas
        /// </summary>
        /// <param name="TransportasKont"> LIST sąrašas </param>
        /// <param name="zodis"> Nurodytas žodis </param>
        
        static void Ismesti(List<Transportas> TransportasKont,string zodis)
        {
            for (int i = 0; i < TransportasKont.Count; i++)
            {
                if (TransportasKont[i].ImtiPav().Contains(zodis))
                {
                    TransportasKont.RemoveAt(i);
                    i--;
                }
            } 
        }

       /// <summary>
       /// Įterpimo metodas 
       /// </summary>
       /// <param name="Naujas"> Bendro sąrašo list'as</param>
       /// <param name="Transp"> Papildomas sąrašas įterpimui </param>
       /// <returns></returns>
       
        static List<Transportas> Iterpimas4(List<Transportas> Naujas, Transportas Transp)
        {
            for (int i = 0; i < Naujas.Count; i++)
            {
                if (Naujas[i].stotsk <= Transp.stotsk)
                {
                    Naujas.Insert(i, Transp);
                    break;
                }
            }
            return Naujas;
        }

        /// <summary>
        /// Įterpimo išvedimo metodas
        /// </summary>
        /// <param name="Naujas"> Bendro sąrašo list'as </param>
        /// <param name="Transp"> Papildomas sąrašas įterpimui </param>
        /// <returns></returns>
        
        static List<Transportas> Iterpimoisvedimas(List<Transportas> Naujas, List<Transportas> Transp)
        {

            for (int i = 0; i < Transp.Count; i++)
            {
                Naujas = Iterpimas4(Naujas, Transp[i]);
            }
            return Naujas;
        }

        /// <summary>
        /// Spausdinimas skirtas csv failui
        /// </summary>
        /// <param name="fv"> Rezultatų failas </param>
        /// <param name="Transp"> LIST sąrašas </param>

        static void SpausdintiCSV(string fv, List<Transportas> Transp)
        {
            using (var fr = new StreamWriter(File.Open(fv, FileMode.Append), Encoding.GetEncoding(1257)))
            {
                fr.WriteLine("Nr.;Maršrutas;Kelio ilgis;Stot sk.");
                if (Transp.Count != 0)
                {
                    for (int i = 0; i < Transp.Count; i++)
                    {
                        Transportas transp = Transp[i];
                        fr.WriteLine("{0};{1};{2};{3}", transp.numeris, transp.pav, transp.ilgis, transp.stotsk);
                    }
                    fr.WriteLine();
                }
            }
        }

       
        //-----------------------------------------------------------
      
    }
}

