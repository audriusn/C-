using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace National_Team_GUI
{
    public partial class Form1 : Form
    {
        private List<Kandidatai> Kandidatas;
        public Form1()
        {
            InitializeComponent();
        }

        private void atidarytiToolStripMenuItem_Click(object sender, EventArgs e)
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
                    Kandidatas = InOutClass.ReadKandidatai(fv);
                    dataGridView1.Rows.Clear();
                    dataGridView1.ColumnCount = 8;
                    dataGridView1.Columns[0].Name = "Vardas";
                    dataGridView1.Columns[0].Width = 80;
                    dataGridView1.Columns[1].Name = "Pavardė";
                    dataGridView1.Columns[1].Width = 80;
                    dataGridView1.Columns[2].Name = "Gimimo data";
                    dataGridView1.Columns[2].Width = 80;
                    dataGridView1.Columns[2].ValueType = typeof(DateTime);
                    dataGridView1.Columns[3].Name = "Ūgis";
                    dataGridView1.Columns[3].Width = 60;
                    dataGridView1.Columns[4].Name = "Pozicija";
                    dataGridView1.Columns[4].Width = 110;
                    dataGridView1.Columns[5].Name = "Komandos pavadinimas";
                    dataGridView1.Columns[5].Width = 130;
                    dataGridView1.Columns[6].Name = "Kandidatas";
                    dataGridView1.Columns[6].Width = 95;
                    dataGridView1.Columns[7].Name = "Kapitonas";
                    dataGridView1.Columns[7].Width = 80;
                    for (int i = 0; i < Kandidatas.Count; i++)
                    {
                        Kandidatai player = Kandidatas[i];
                        dataGridView1.Rows.Add(player.Name, player.Surname, player.BirthDate, player.Height, player.Position, player.TeamName, player.Candidate, player.Captain);
                    }
                   
                }
            }
            catch 
            {
                MessageBox.Show("Blogas duomenų failas. Bankytite dar kartą.", "Įspėjimas!!!");
            }
        }

        private void vyrKandidatasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<Kandidatai> OldPlayers = TaskClass.MakeOldestList(Kandidatas);
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 8;
            dataGridView1.Columns[0].Name = "Vardas";
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Name = "Pavardė";
            dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[2].Name = "Gimimo data";
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[2].ValueType = typeof(DateTime);
            dataGridView1.Columns[3].Name = "Ūgis";
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Name = "Pozicija";
            dataGridView1.Columns[4].Width = 110;
            dataGridView1.Columns[5].Name = "Komandos pavadinimas";
            dataGridView1.Columns[5].Width = 130;
            dataGridView1.Columns[6].Name = "Kandidatas";
            dataGridView1.Columns[6].Width = 95;
            dataGridView1.Columns[7].Name = "Kapitonas";
            dataGridView1.Columns[7].Width = 80;
            for (int i = 0; i < OldPlayers.Count; i++)
            {
                Kandidatai player = OldPlayers[i];
                dataGridView1.Rows.Add(player.Name, player.Surname, player.BirthDate, player.Height, player.Position, player.TeamName, player.Candidate, player.Captain);
            }
            }
            catch 
            {
                MessageBox.Show("Nėra importuotų duomenų.", "Įspėjimas!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns[0].Name = "Vardas";
                dataGridView1.Columns[0].Width = 80;
                dataGridView1.Columns[1].Name = "Pavardė";
                dataGridView1.Columns[1].Width = 80;
                dataGridView1.Columns[2].Name = "Gimimo data";
                dataGridView1.Columns[2].Width = 80;
                dataGridView1.Columns[2].ValueType = typeof(DateTime);
                dataGridView1.Columns[3].Name = "Ūgis";
                dataGridView1.Columns[3].Width = 60;
                dataGridView1.Columns[4].Name = "Pozicija";
                dataGridView1.Columns[4].Width = 110;
                dataGridView1.Columns[5].Name = "Komandos pavadinimas";
                dataGridView1.Columns[5].Width = 130;
                dataGridView1.Columns[6].Name = "Kandidatas";
                dataGridView1.Columns[6].Width = 95;
                dataGridView1.Columns[7].Name = "Kapitonas";
                dataGridView1.Columns[7].Width = 80;

                for (int i = 0; i < Kandidatas.Count; i++)
                {
                    Kandidatai player = Kandidatas[i];
                    dataGridView1.Rows.Add(player.Name, player.Surname, player.BirthDate, player.Height, player.Position, player.TeamName, player.Candidate, player.Captain);
                   
                }
            }
            catch 
            {
                MessageBox.Show("Nėra importuotų duomenų.", "Įspėjimas!");
            }
        }

        private void puolėjaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<Kandidatai> Puolėjai = TaskClass.FindPuolėjai(Kandidatas);
                dataGridView1.Rows.Clear();
                dataGridView1.Columns[0].Name = "Vardas";
                dataGridView1.Columns[0].Width = 80;
                dataGridView1.Columns[1].Name = "Pavardė";
                dataGridView1.Columns[1].Width = 80;
                dataGridView1.Columns[2].Name = "Gimimo data";
                dataGridView1.Columns[2].Width = 80;
                dataGridView1.Columns[2].ValueType = typeof(DateTime);
                dataGridView1.Columns[3].Name = "Ūgis";
                dataGridView1.Columns[3].Width = 60;
                dataGridView1.Columns[4].Name = "Pozicija";
                dataGridView1.Columns[4].Width = 110;
                dataGridView1.Columns[5].Name = "Komandos pavadinimas";
                dataGridView1.Columns[5].Width = 130;
                dataGridView1.Columns[6].Name = "Kandidatas";
                dataGridView1.Columns[6].Width = 95;
                dataGridView1.Columns[7].Name = "Kapitonas";
                dataGridView1.Columns[7].Width = 80;

                for (int i = 0; i < Puolėjai.Count; i++)
                {
                    Kandidatai player = Puolėjai[i];
                    dataGridView1.Rows.Add(player.Name, player.Surname, player.BirthDate, player.Height, player.Position, player.TeamName, player.Candidate, player.Captain);
                }
            }
            catch 
            {
                MessageBox.Show("Nėra importuotų duomenų.", "Įspėjimas!");
            }
        }

        private void rinktinėCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<Kandidatai> CandidatesCSV = TaskClass.CandidateToCsv(Kandidatas, Mark.TRUE);
                if (CandidatesCSV.Count != 0)
                {
                    InOutClass.PrintPlyersToCSVFile("Rinktinė.csv", CandidatesCSV);
                    MessageBox.Show("Duomenys eskportuoti į Rinktinė.csv.", "Informacija!");
                }
                else
                {
                    MessageBox.Show("Nėra duomenų,kuriuos būtų galima eskportuoti.", "Informacija!");
                }
            }
            catch 
            {
                MessageBox.Show("Nėra importuotų duomenų.", "Įspėjimas!");
            }
        }

        private void baigtiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
