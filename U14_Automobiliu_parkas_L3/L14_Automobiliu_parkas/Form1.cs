// Aistė Sudintaitė, IFZ-6/2
// P175B502

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

//14. Automobilių parkas. 
//Turite duomenis apie UAB priklausančius automobilius. Duomenų faile
//pateikta ši informacija: valstybinis numeris, gamintojas, modelis, spalva, pagaminimo metai ir
//mėnuo, techninės apžiūros galiojimo data, kuras, vidutinės kuro sąnaudos(100km).
//+1. Raskite du nurodytos spalvos seniausius automobilius(visi duomenys).
//+2. Raskite, kiek yra nurodytos spalvos automobilių.
//+3. Sudarykite visų nurodytų metų intervalo automobilių sąrašą(visi duomenys).
//+4. Surikiuokite sudarytą sąrašą pagal pasirinktus du požymius.
//+5. Sudarykite visų automobilių gamintojų sąrašą be pasikartojimų.
//Visus skaičiavimų rezultatus pateikite rezultatų faile lentelėmis.


// abstraktus metodas
// rikiavimas minmax

namespace L14_Automobiliu_parkas
{
    public partial class Form1 : Form
    {
        const string CFd = "..//..//Duomenys.txt";
        const string CFr = "..//..//Rezultatai.txt";
        const string CFp = "..//..//Pagalba.txt";
        const int Cn = 100;

        List<Automobiliai> AutoList = new List<Automobiliai>(); // Bendras automobilių sąrašas
        List<Automobiliai> Seniausi = new List<Automobiliai>(); // Dviejų seniausių automobilių sąrašas
        List<Automobiliai> Naujas = new List<Automobiliai>(); // Naujas atrinktas sąrašas

        public Form1()
        {
            InitializeComponent();

            if (File.Exists(CFr))
                File.Delete(CFr);
        }

        // MYGTUKAI
        //---------------------------------------------------------------------------------------

        private void įvedimasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt) |*.txt|All files (*.*)|*.*";
            openFileDialog1.Title = "Pasirinkite rezultatu faila";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fv = openFileDialog1.FileName;
                AutoList = Skaityti(fv, AutoList);
                Spausdinti(CFr, AutoList, "Pradiniai duomenys");
                rezultatai.LoadFile(CFr, RichTextBoxStreamType.PlainText);
            }
        }

        //------------------------------------

        private void skaičiavimaiToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (AutoList.Count > 0)

            {

                // Raskite du nurodytos spalvos seniausius automobilius(visi duomenys).
                string zodis = nurodytaspalva.Text;
                Automobiliai max1;
                Automobiliai max2;
                if (DuSeniausi(AutoList, out max1, out max2, zodis, Seniausi))
                {
                    Spausdinti(CFr, Seniausi, "Jusu nurodytos spalvos du seniausi automobiliai: ");
                }

                else
                    using (var fr = File.AppendText(CFr))
                    {
                        fr.WriteLine("Dvieju seniausiu masinu jusu nurodytos spalvos nera\n");
                    }

                // Raskite, kiek yra nurodytos spalvos automobilių.

                using (var fr = File.AppendText(CFr))
                {
                    int Kiekis = AutomobiliuKiekis(AutoList, zodis);

                    if (Kiekis > 0)
                        fr.WriteLine("Jusu nurodytos spalvos: {0} , masinu yra {1}\n", zodis, Kiekis);
                    else
                        fr.WriteLine("Jusu nurodytos spalvos: {0}, masinu nera\n", zodis);
                }


                // Sudarykite visų nurodytų metų intervalo automobilių sąrašą(visi duomenys).
                int a = Convert.ToInt32(areiksme.Text);
                int b = Convert.ToInt32(breiksme.Text);
                Intervalas(AutoList, Naujas, a, b);
                Spausdinti(CFr, Naujas, "Naujas sarasas");

                //Surikiuokite sudarytą sąrašą pagal pasirinktus du požymius.
                //Naujas.Sort(); // Rikiuoja pagal technines apziuros metus ir gamintoją
                //Spausdinti(CFr, Naujas, "Rikiuotas sarasas");

                //-------------

                Naujas = Rikiavimas(Naujas);
                Spausdinti(CFr, Naujas, "Rikiuotas sarasas");

                // Sudarykite visų automobilių gamintojų sąrašą be pasikartojimų.

                string[] Gamintojai = new string[Cn];
                int kiek;
                int count;
                int[] kiekis = new int[Cn];
                GamintojuSarasas(AutoList, Gamintojai, out kiek);


                using (var fr = File.AppendText(CFr))
                {
                    fr.WriteLine("-------------------------------------------");
                    fr.WriteLine("Bendras gamintoju sarasas be pasikartojimu: ");
                    fr.WriteLine("-------------------------------------------");
                    SpausdintiNepasikartojancius(fr, Gamintojai, kiek);
                    fr.WriteLine("-------------------------------------------");
                }

                rezultatai.LoadFile(CFr, RichTextBoxStreamType.PlainText);
                int[] Kiekis2 = new int[Cn];

            }

        }

        //------------------------------------

        private void pagalbaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamReader tekstas = new StreamReader(CFp, Encoding.GetEncoding(1257));
            MessageBox.Show(tekstas.ReadToEnd());
            tekstas.Close();
        }

        // METODAI
        //---------------------------------------------------------------------------------------

        /// <summary>
        /// Nuskaitymo metodas
        /// </summary>
        /// <param name="fv"> Duomenų failas </param>
        /// <param name="AutoList"> Duomenų list </param>
        /// <returns></returns>

        static List<Automobiliai> Skaityti(string fv, List<Automobiliai> AutoList)
        {
            using (StreamReader reader = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    string numeris = parts[0];
                    string gamintojas = parts[1];
                    string modelis = parts[2];
                    string spalva = parts[3];
                    DateTime pagaminmetai = DateTime.Parse(parts[4]);
                    DateTime technikine = DateTime.Parse(parts[5]);
                    string kuras = parts[6];
                    double kurosanaudos = double.Parse(parts[7]);
                    Automobiliai auto = new Automobiliai(numeris, gamintojas, modelis,
                        spalva, pagaminmetai, technikine, kuras, kurosanaudos);
                    AutoList.Add(auto);
                }
            }
            return AutoList;
        }

        /// <summary>
        /// Spausdinimo metodas
        /// </summary>
        /// <param name="fv"> Duomenų failas </param>
        /// <param name="AutoList"> Duomenų list </param>
        /// <param name="info"> Papildoma informacija apie duomenis </param>

        static void Spausdinti(string fv, List<Automobiliai> AutoList, string info)
        {
            if (AutoList.Count > 0)
            {
                const string virsus =
                    "----------------------------------------------------------------------------------------------------\r\n"
                + " Numeris   Gamintojas  Modelis      Spalva     Pag. metai     Techn.apziura     Kuras    Sanaudos \r\n"
                + "----------------------------------------------------------------------------------------------------";


                using (var fr = File.AppendText(fv))
                {
                    fr.WriteLine(info);
                    fr.WriteLine(virsus);
                    for (int i = 0; i < AutoList.Count; i++)
                    {
                        Automobiliai pr = AutoList[i];
                        fr.WriteLine("{0}", pr);
                    }

                    fr.WriteLine("----------------------------------------------------------------------------------------------------\r\n");

                }
            }

            else using (var fr = File.AppendText(fv))
                {
                    fr.WriteLine("Tuscias sarasas\n");
                }
        }

        /// <summary>
        /// Atrenka automobilius tik nurodytos spalvos
        /// </summary>
        /// <param name="AutoList"> Automobilių duomenys </param>
        /// <param name="nurodytaszodis"> Nurodyta spalva </param>
        /// <returns></returns>

        static List<Automobiliai> Spalvos(List<Automobiliai> AutoList, string nurodytaszodis)
        {
            List<Automobiliai> spalva = new List<Automobiliai>();
            for (int i = 0; i < AutoList.Count; i++)
            {
                Automobiliai Auto = AutoList[i];

                if (Auto.Palyginimas())
                {
                    if (Auto.spalva == nurodytaszodis)

                    {
                        spalva.Add(Auto);
                    }
                }
            }

            return spalva;
        }

        /// <summary>
        /// Atrenka du seniausius nurodytos spalvos automobilius
        /// </summary>
        /// <param name="AutoList"> Automobilių duomenys </param>
        /// <param name="max1"> Pirmas seniausias automobilis </param>
        /// <param name="max2"> Antras seniausias automobilis </param>
        /// <param name="nurodytaspalva"> Nurodyta spalva </param>
        /// <returns></returns>

        static bool DuSeniausi(List<Automobiliai> AutoList, out Automobiliai max1, out Automobiliai max2, string nurodytaspalva, List<Automobiliai> Seniausi)
        {

            List<Automobiliai> Atrinkti = Spalvos(AutoList, nurodytaspalva);

            //DateTime DT1 = new DateTime(0000 - 00 - 00);
            //DateTime DT2 = new DateTime(0000 - 00);
            //max1 = new Automobiliai("", "", "", "", DT2, DT1, "", 0.0);
            //max2 = new Automobiliai("", "", "", "", DT2, DT1, "", 0.0);

            max1 = new Automobiliai();
            max2 = new Automobiliai();

            if (Atrinkti.Count < 2) return false;

            //--- Pradinių reikšmių suteikimas --------------------
            if (Atrinkti[0].pagaminmetai.Date < Atrinkti[1].pagaminmetai.Date)
            {
                max1 = Atrinkti[0];
                max2 = Atrinkti[1];
            }
            else
            {
                max1 = Atrinkti[1];
                max2 = Atrinkti[0];
            }

            //--- Paieška --------------------------------------------
            for (int i = 2; i < Atrinkti.Count; i++)
            {

                if (Atrinkti[i].pagaminmetai.Date < max1.pagaminmetai.Date)
                {
                    max2 = max1;
                    max1 = Atrinkti[i];
                }

                else if (Atrinkti[i].pagaminmetai.Date < max2.pagaminmetai.Date)
                {
                    max2 = Atrinkti[i];
                }

            }

            Seniausi.Add(max1);
            Seniausi.Add(max2);
            return true;
        }

        /// <summary>
        /// Suskaičiuoja nurodytos spalvos automobilių kiekį
        /// </summary>
        /// <param name="AutoList"> Automobilių duomenys </param>
        /// <param name="nurodytaspalva"> Nurodyta spalva </param>
        /// <returns></returns>

        //---------------------------------------------------------------------------------------------------------

        static int AutomobiliuKiekis(List<Automobiliai> AutoList, string nurodytaspalva)
        {
            int kiek = 0;
            for (int i = 0; i < AutoList.Count; i++)
            {
                Automobiliai Auto = AutoList[i];

                if (Auto.spalva == nurodytaspalva)
                {
                    kiek++;
                }

            }
            return kiek;
        }

        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Sudaro naują sarašą pagal nurodytą pagaminimo metų intervalą
        /// </summary>
        /// <param name="AutoList"> Automobilių duomenys </param>
        /// <param name="Naujas"> Naujas list'as duomenims saugoti </param>
        /// <param name="a"> [a;b] a intervalo reikšmė </param>
        /// <param name="b"> [a;b] b intervalo reikšmė </param>
        /// <returns></returns>

        static List<Automobiliai> Intervalas(List<Automobiliai> AutoList, List<Automobiliai> Naujas, int a, int b)
        {
            for (int i = 0; i < AutoList.Count; i++)
            {
                Automobiliai Auto = AutoList[i];

                if (a <= Auto.pagaminmetai.Year && b >= Auto.pagaminmetai.Year)
                {
                    Naujas.Add(Auto);
                }

            }

            return Naujas;
        }

        /// <summary>
        /// Sudaro gamintojų sąrašą be pasikartojimų
        /// </summary>
        /// <param name="AutoList"> Automobilių sąrašas </param>
        /// <param name="Naujas2"> Naujas sąrašas gamintojams saugoti </param>
        /// <param name="kiek"> Gamintojų kiekis </param>

        static void GamintojuSarasas(List<Automobiliai> AutoList, string[] Gamintojai, out int kiek)
        {
            kiek = 0;
           // int sk = 0;
            for (int i = 0; i < AutoList.Count; i++)
            {
                for (int j = 0; j < AutoList.Count; j++)
                {
                    if (AutoList[i].gamintojas.Contains(AutoList[j].gamintojas) && !Gamintojai.Contains(AutoList[j].gamintojas))

                    {
                       
                        Gamintojai[kiek] += AutoList[i].gamintojas;
                        kiek++;

                    }

                }
            }
        }

        /// <summary>
        /// Spausdinimo metodas gamintojų sąrašui
        /// </summary>
        /// <param name="fr"> Rezultatų failas </param>
        /// <param name="Gamintojai"> Gamintojų sąrašas </param>
        /// <param name="kiek"> Gamintojų kiekis </param>

        static void SpausdintiNepasikartojancius(StreamWriter fr, string[] Gamintojai, int kiek)
        {
            for (int i = 0; i < kiek; i++)
            {
                fr.WriteLine(Gamintojai[i]);
            }
        }

        /// <summary>
        /// Rikiavimo metodas
        /// </summary>
        /// <param name="AutoList"> Automobilių sąrašas </param>
        /// <returns></returns>

        private List<Automobiliai> Rikiavimas(List<Automobiliai> AutoList)
        {
            int i = 0;
            bool bk = true;
            while (bk)
            {
                bk = false;
                for (int j = AutoList.Count - 1; j > i; j--)
                    if (AutoList[j] > AutoList[j - 1])
                    {
                        bk = true;
                        Automobiliai auto = AutoList[j];
                        AutoList[j] = AutoList[j - 1];
                        AutoList[j - 1] = auto;
                    }
                i++;
            }
            return AutoList;
        }


    }
}


