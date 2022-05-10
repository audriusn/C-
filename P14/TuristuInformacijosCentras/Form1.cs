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


namespace TuristuInformacijosCentras
{
    public partial class Warning : Form
    {
        const string CFd = "muziejai.csv";
        const string CFr = "Rezultatai.csv";

        private List<Museum> Muziejai;
        public Warning()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        static List<Museum> ReadMuseum(string fv)
        {
            List<Museum> Muziejai = new List<Museum>();
            using (StreamReader srautas = new StreamReader(fv, Encoding.UTF8))
            {
                string eilute;
                while ((eilute = srautas.ReadLine()) != null)
                {
                    string[] eilDalis = eilute.Split(',');
                    string pavadinimas = eilDalis[0];
                    string miestas = eilDalis[1];
                    string tipas = eilDalis[2];
                    int pirmadienis = int.Parse(eilDalis[3]);
                    int antradienis = int.Parse(eilDalis[4]);
                    int treciadienis = int.Parse(eilDalis[5]);
                    int ketvirtadienis = int.Parse(eilDalis[6]);
                    int penktadienis = int.Parse(eilDalis[7]);
                    int sestadienis = int.Parse(eilDalis[8]);
                    int sekmadienis = int.Parse(eilDalis[9]);
                    double kaina = double.Parse(eilDalis[10]);
                    Guide Guide;
                    Enum.TryParse(eilDalis[11], out Guide);
                    Museum museum = new Museum(pavadinimas, miestas, tipas, pirmadienis, antradienis, treciadienis, ketvirtadienis, penktadienis, sestadienis, sekmadienis, kaina, Guide);
                    Muziejai.Add(museum);
                }
            }
            return Muziejai;
        }
         static void PrintMuseums(string fv, List<Museum> Museums, string antraste)
        {
            const string virsus =
                "--------------------------------*------------------\r\n"
               + "  Pavadinimas  Miestas  Tipas     Kaina    Gidas \r\n"
               + "-------------------------------------------------";
            using (var fr = new StreamWriter(File.Open(fv, FileMode.Append), Encoding.UTF8))
            {
                fr.WriteLine("\n" + antraste);
                fr.WriteLine(virsus);
                for (int i = 0; i < Museums.Count; i++)
                {
                    Museum stud = Museums[i];
                    fr.WriteLine("{0}",  stud.ToString());
                }
                fr.WriteLine("------------------------------------------\n");
            }
   
        }
 
        /// <summary>
        /// Count how many museums have guide in Kaunas
        /// </summary>
        /// <param name="Museums">Museum List</param>
        /// <param name="Guide"> Guide Yes/NO</param>
        /// <param name="town">City</param>
        /// <returns></returns>
        static int CountByGuide(List<Museum> Museums, Guide Guide)
        {
            int count = 0;
            foreach (Museum museum in Museums)
            {
                if (museum.Guide.Equals(Guide) && museum.miestas.Equals("Kaunas"))
                {
                    count++;
                }
            }
            return count;
        }
        
        /// <summary>
        /// Count how many museums working on wednesday in Vilnius
        /// </summary>
        /// <param name="Museums">Museum List</param>
        /// <param name="treciadienis">Wednesday value</param>
        /// <param name="town">City</param>
        /// <returns></returns>
         static int CountVLNOnWensday(List<Museum> Museums, int treciadienis, string town)
        {
            int count = 0;
            foreach (Museum museum in Museums)
            {

                if (museum.treciadienis.Equals(treciadienis) && museum.miestas.Equals(town))
                {
                    count++;
                }
            }
            return count;
        }
        /// <summary>
        /// Make a list with museums types working wednesday in Vilnius
        /// </summary>
        /// <param name="Museums">Museum List</param>
        /// <param name="treciadienis"> Wednesday value</param>
        /// <param name="town">City</param>
        /// <returns></returns>
         static List<string> TypesVLNOnWensday(List<Museum> Museums, int treciadienis, string town)
        {
            List<string> VLNtipai = new List<string>();
            foreach (Museum museum in Museums)
            {
                string tipas = museum.tipas;

                if (museum.treciadienis.Equals(treciadienis) && museum.miestas.Equals(town) && (!VLNtipai.Contains(tipas)))
                    VLNtipai.Add(tipas);
            }
            return VLNtipai;
        }

        /// <summary>
        /// Filtering by City and more than 3 working days 
        /// </summary>
        /// <param name="Museums"></param>
        /// <param name="miestas"></param>
        /// <returns></returns>
        static List<Museum> FilterByCity(List<Museum> Museums, string miestas)
        {
            List<Museum> Filtered = new List<Museum>();
            foreach (Museum museum in Museums)
            {
                if (museum.miestas.Equals(miestas) && (museum.pirmadienis + museum.antradienis + museum.treciadienis + museum.ketvirtadienis + museum.penktadienis + museum.sestadienis + museum.sekmadienis) >= 3) //uses string method Equals()
                {
                    Filtered.Add(museum);
                }
            }
            return Filtered;
        }
         static void PrintMuseumsToCSVFile(string fileName, List<Museum> Museums)
        {
            string[] lines = new string[Museums.Count + 1];
            lines[0] = String.Format(" {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", "Pavadinimas", "Miestas", "Tipas", "I", "II", "III", "IV", "V", "VI", "VII", "Kaina", "Gidas");
            for (int i = 0; i < Museums.Count; i++)
            {
                lines[i + 1] = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", Museums[i].pavadinimas, Museums[i].miestas, Museums[i].tipas, Museums[i].pirmadienis, Museums[i].antradienis,
                        Museums[i].treciadienis, Museums[i].ketvirtadienis, Museums[i].penktadienis, Museums[i].sestadienis, Museums[i].sekmadienis, Museums[i].kaina, Museums[i].Guide);
            }
            File.WriteAllLines(fileName, lines);
        }

        private void įvestiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog1.Title = "Pasirinkite duomenų failą";
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string fv = openFileDialog1.FileName;
                    Muziejai = ReadMuseum(fv);
                    duomenys.Rows.Clear();
                    duomenys.ColumnCount = 13;
                    duomenys.Columns[0].Name = "Nr";
                    duomenys.Columns[0].Width = 40;
                    duomenys.Columns[1].Name = "Pavadinimas";
                    duomenys.Columns[1].Width = 130;
                    duomenys.Columns[2].Name = "Miestas";
                    duomenys.Columns[2].Width = 60;
                    duomenys.Columns[3].Name = "Tipas";
                    duomenys.Columns[3].Width = 60;
                    duomenys.Columns[4].Name = "I";
                    duomenys.Columns[4].Width = 30;
                    duomenys.Columns[5].Name = "II";
                    duomenys.Columns[5].Width = 30;
                    duomenys.Columns[6].Name = "III";
                    duomenys.Columns[6].Width = 30;
                    duomenys.Columns[7].Name = "IV";
                    duomenys.Columns[7].Width = 30;
                    duomenys.Columns[8].Name = "V";
                    duomenys.Columns[8].Width = 30;
                    duomenys.Columns[9].Name = "VI";
                    duomenys.Columns[9].Width = 30;
                    duomenys.Columns[10].Name = "VII";
                    duomenys.Columns[10].Width = 30;
                    duomenys.Columns[11].Name = "Kaina";
                    duomenys.Columns[11].Width = 50;
                    duomenys.Columns[12].Name = "Gidas";
                    duomenys.Columns[12].Width = 50;

                    for (int i = 0; i < Muziejai.Count; i++)
                    {
                        Museum museum = Muziejai[i];
                        duomenys.Rows.Add(i + 1, museum.pavadinimas, museum.miestas, museum.tipas, museum.pirmadienis, museum.antradienis, museum.treciadienis, museum.ketvirtadienis,
                            museum.penktadienis, museum.sestadienis, museum.sekmadienis, museum.kaina, museum.Guide);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( "Blogas duomenų failas. Bankytite dar kartą.","Warning!!!");
            }          
        }

       

        private void baigtiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void results_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void kaunoMuziejaiSuGidaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label2.Text = "Kaune muziejų su gidais yra : " + CountByGuide(Muziejai, Guide.Taip).ToString();
        }

        private void vilniausMuziejaiDirbantysTrečiadieniaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label3.Text = " Vilniuje trečiadieniais galima aplynkyti šių tipų muziejus: ";
            List<string> VLNtipai = TypesVLNOnWensday(Muziejai, 1, "Vilnius");
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "Nr";
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[1].Name = "Tipas";
            dataGridView1.Columns[1].Width = 80;
            if (VLNtipai.Count > 0)
            { 
                for (int i = 0; i < VLNtipai.Count; i++)
                {
                    string vlnon3 = VLNtipai[i];
                    dataGridView1.Rows.Add(i + 1, vlnon3);
                }
            }
            else
            {
                MessageBox.Show("Trečiadieniais Vilniuje dirbančių muziejų nėra.", "Pranešimas");
            }
        }

        private void daugiauKaip3DienasDirbantysKaunoMuziejaiToolStripMenuItem_Click(object sender, EventArgs e)         
        {
            List<Museum> Filtered = FilterByCity(Muziejai, "Kaunas");
            string fileName = "Kaunas" + ".csv";
            PrintMuseumsToCSVFile(fileName, Filtered);
            MessageBox.Show("Informacija išspausdinta į Kaunas.csv failą", "Informacija!");
        }

        
    }
}
