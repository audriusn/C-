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

namespace StudentaiListMenu
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// KONSTANTOS
        /// </summary>
        const string CFd = "Studentai.txt";
        const string CFr = "Rezultatai.txt";
        const string CFvs = "VertinimoSistema.txt";
        //const string CFvs = "VertinimoSistema.txt";
        const string CFu = "Uzduotis.txt";
        const string CFn = "Nurodymai.txt";
        /// <summary>
        /// KINTAMIJEI (OBJEKTAI, OBJEKTŲ MASYVAI)
        /// </summary>
        private List<Studentas> StudentuTestas;
        private List<Pazymys> Pazymiai;
        public Form1()
        {
            InitializeComponent();
            //Nurodyti meniu punktai padaromi pasyviais
            spausdintiToolStripMenuItem.Enabled = false;
            studentųSkaičiusToolStripMenuItem.Enabled = false;
            studentųĮvestinimaiToolStripMenuItem.Enabled=false;


            ////FOR METHODS TEST///
            //MessageBox.Show(Kiekis(StudentuTestas, 5).ToString(), "Studentų skaičius:");
            //MessageBox.Show(StudentoIndeksas(StudentuTestas, "Petraitis Petras").ToString(), "Studento index:");
        }
        //=======================================================================================
        //  GRAFINĖS VARTOTOJO SČSAJOS METODAI
        //=======================================================================================
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Skaito duomenis iš failo į dinaminį masyvą
        /// </summary>
        /// <param name="fv"></param>
        /// <returns></returns>
        static List<Studentas> SkaitytiStudList (string fv)
        {
            List<Studentas> StudTestas = new List<Studentas>();
            using (StreamReader srautas = new StreamReader(fv, Encoding.UTF8))
            {
                string eilute;
                while((eilute = srautas.ReadLine()) != null)
                {
                    string[] eilDalis = eilute.Split(';');
                    string pavVrd = eilDalis[0];
                    int pazym = int .Parse(eilDalis[1]);  
                    Studentas studentas = new Studentas(pavVrd, pazym);
                    StudTestas.Add(studentas);
                }
            }
            return StudTestas;
        }

        static void SpausdintiStudList(string fv, List<Studentas> StudTestas, string antraste)
        {
            const string virsus =
                "--------------------------------------\r\n"
               + "  Nr.  Pavardė ir vardas   Pažymys \r\n"
               + "--------------------------------------";
            using (var fr = new StreamWriter(File.Open(fv,FileMode.Append), Encoding.UTF8))
            {
                fr.WriteLine("\n" + antraste);
                fr.WriteLine(virsus);
                for (int i = 0; i< StudTestas.Count; i++)
                {
                    Studentas stud = StudTestas[i];
                    fr.WriteLine("{0,4}  {1}", i+1, stud);
                }
                fr.WriteLine("------------------------------------------\n");
            }
        }
        static List<Pazymys> SkaitytiVertinimoSistemaList(string fv)
        {
            List<Pazymys> VertSistema = new List<Pazymys>();
            using (StreamReader srautas = new StreamReader(fv, Encoding.UTF8))
            {
                string eilute;
                while ((eilute = srautas.ReadLine()) != null)
                {
                    string[] eilDalis = eilute.Split(';');
                    int pazym = int.Parse(eilDalis[0]);
                    string pazReiksme = eilDalis[1];
                    Pazymys pazymys = new Pazymys(pazym, pazReiksme);
                    VertSistema.Add(pazymys);
                }
            }
             return VertSistema;
        }
        /// <summary>
        /// Suskaičiuoja studentų, kurių pažymiai lygūs nurodytam pažymiui, skaičių.
        /// </summary>
        /// <param name="StudTestas"></param>
        /// <param name="pazymys"></param>
        /// <returns></returns>
        static int Kiekis (List<Studentas> StudTestas, int pazymys)
        {
            int kiek = 0;
            for(int i = 0; i < StudTestas.Count; i++)
            {
                Studentas stud = StudTestas[i];
                if (stud.Pazym == pazymys)
                    kiek++;
            }
            return kiek;
        }
        static int StudentoIndeksas(List<Studentas> StudTestas, string pavVrd)
        {
            for (int i = 0; i < StudTestas.Count;i++)
            {
                if (StudTestas[i].PavVrd.ToLower() == pavVrd.ToLower())
                    return i;
            }
            return -1;
        }
        static double VyruVidurkis (List<Studentas> StudTestas)
        {
            double suma= 0;
            double kiek = 0;
            for (int i = 0; i< StudTestas.Count; i++)
            {
                if (StudTestas[i].PavVrd.EndsWith("as") || StudTestas[i].PavVrd.EndsWith("ius"))
                {
                    suma = suma + StudTestas[i].Pazym;
                    kiek++;
                }
            }
            return  suma / kiek ;
        }
        static double MoteruVidurkis(List<Studentas> StudTestas)
        {
            double suma = 0;
            double kiek = 0;
            for (int i = 0; i < StudTestas.Count; i++)
            {
                if (StudTestas[i].PavVrd.EndsWith("a") || StudTestas[i].PavVrd.EndsWith("ė"))
                { 
                suma = suma + StudTestas[i].Pazym;
                kiek++;
                 }
            }
            return  suma / kiek ;
        }

        /// <summary>
        /// Meniu punkti "Įvesti atliekami veiksmai. Duomenų failo vardas išrenkamas naudojant openFileDialog komponentą
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void įvestiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pazymiai = SkaitytiVertinimoSistemaList(CFvs);
            foreach (Pazymys paz in Pazymiai)
                vertinimai.Items.Add(paz.ToString());
            vertinimai.SelectedIndex = 0;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Title = "Pasirinkite duomenų failą";
            DialogResult result = openFileDialog1.ShowDialog();
            if(result == DialogResult.OK)
            {
                string fv = openFileDialog1.FileName;
                duomenys.LoadFile(fv, RichTextBoxStreamType.PlainText);
                StudentuTestas =SkaitytiStudList(fv);
            }
            įvestiToolStripMenuItem.Enabled = false;
            spausdintiToolStripMenuItem.Enabled = true;
            studentųSkaičiusToolStripMenuItem.Enabled=true;
            studentųĮvestinimaiToolStripMenuItem.Enabled =true;

        }
        /// <summary>
        /// Meniu punkto "Spausdinti" atliekami veiksmai. Rezultatų failo vardas išrenkamas naudojant saveFileDialog komponentą
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spausdintiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();  
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Title = "Pasirinkite rezultatų failą.";
            DialogResult result =saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fv = saveFileDialog1.FileName;
                //jeigu reikia rezultatu failas išvalomas
                if(File.Exists(fv))
                    File.Delete(fv);
                SpausdintiStudList(fv, StudentuTestas, "Studentų sąrašas (testo rezultatai");
                //-------------------------------------------
                //Komponento dataGridView1 užpildymas duomenimis
                rezultatai.ColumnCount = 3;
                rezultatai.Columns[0].Name = "Nr";
                rezultatai.Columns[0].Width = 40;
                rezultatai.Columns[1].Name = "Pavardė ir vardas";
                rezultatai.Columns[1].Width = 280;
                rezultatai.Columns[2].Name = "Pažymys";
                rezultatai.Columns[2].Width = 80;
                for (int i = 0; i< StudentuTestas.Count; i++)
                {
                    Studentas studentas = StudentuTestas[i];
                    rezultatai.Rows.Add(i + 1, studentas.PavVrd, studentas.Pazym);
                }

            }
        }
        /// <summary>
        /// Meniu punkto "Baigti" atliemaki veiksmai
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void baigtiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void studentųSkaičiusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ivertis = vertinimai.SelectedItem.ToString().TrimStart();
            string[] eilDalis = ivertis.Split(' ');
            int pazymys = Int32.Parse(eilDalis[0]);
            int kiekis = Kiekis(StudentuTestas, pazymys);
            if (kiekis > 0)
                rezultatas.Text = "Studentų skaičius: " + kiekis.ToString();
            else
                rezultatas.Text = "Tokių studentų nėra.";
        }

        private void studentųĮvestinimaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string pavVrd = pavardeVrd.Text;
            int index = StudentoIndeksas(StudentuTestas, pavVrd);
            if (index > -1)
            {
                Studentas stud = StudentuTestas[index];
                int pazymys = stud.Pazym;
                pavardeVrd.Text = pavardeVrd.Text + " -> pažymys: " + pazymys.ToString();
            }
            else
                pavardeVrd.Text = pavardeVrd.Text + " -> tokio studento (-ės) nėra.";
        }
        /// <summary>
        /// Meniu punkto "Užduotis" atliekami veiksmai
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void užduotisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            duomenys.LoadFile(CFu,RichTextBoxStreamType.PlainText);
        }
        /// <summary>
        /// Meniu punkto "Nurodymai vartotojui" atliekami veiksmai
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nurodymaiVartotojuiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            duomenys.LoadFile(CFn,RichTextBoxStreamType.PlainText);
        }

        private void vertinimai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rezultatas_Click(object sender, EventArgs e)
        {

        }

        private void duomenys_TextChanged(object sender, EventArgs e)
        {

        }

        private void pavardeVrd_TextChanged(object sender, EventArgs e)
        {

        }

        private void rezultatai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void vyrųVidurkisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vyruVidurkis.Text = "Vyrų vidurkis: " + VyruVidurkis(StudentuTestas).ToString();
        }

        private void moretųVidurkisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            moteruVidurkis.Text = "Moterų vidurkis: " + MoteruVidurkis(StudentuTestas).ToString();
        }

        private void vyruVidurkis_Click(object sender, EventArgs e)
        {
           
        }

        private void moteruVidurkis_Click(object sender, EventArgs e)
        {
          
        }
    }
}
