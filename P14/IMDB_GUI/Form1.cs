using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMDB_GUI
{
    public partial class Form1 : Form
    {
        const string CFd = "IMDM.csv";
        

        private List<Film> Films;
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                    Films = InOutClass.ReadFilm(fv);
                    dataGridView1.Rows.Clear();
                    dataGridView1.ColumnCount = 8;
                    dataGridView1.Columns[0].Name = "Pavadinimas";
                    dataGridView1.Columns[0].Width = 130;
                    dataGridView1.Columns[1].Name = "Metai";
                    dataGridView1.Columns[1].Width = 40;
                    dataGridView1.Columns[2].Name = "Žanras";
                    dataGridView1.Columns[2].Width = 60;
                    dataGridView1.Columns[3].Name = "Leidėjas";
                    dataGridView1.Columns[3].Width = 160;
                    dataGridView1.Columns[4].Name = "Režisierius";
                    dataGridView1.Columns[4].Width = 100;
                    dataGridView1.Columns[5].Name = "Aktorius";
                    dataGridView1.Columns[5].Width = 100;
                    dataGridView1.Columns[6].Name = "Aktorius";
                    dataGridView1.Columns[6].Width = 100;
                    dataGridView1.Columns[7].Name = "Uždirbis";
                    dataGridView1.Columns[7].Width = 80;
                    for (int i = 0; i < Films.Count; i++)
                    {
                        Film film = Films[i];
                        dataGridView1.Rows.Add(film.Name, film.Year, film.Type, film.Company, film.Director, film.Actor1, film.Actor2, film.Profit);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Blogas duomenų failas. Bankytite dar kartą.", "Įspėjimas!!!");
            }
        
    }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                List<Film> MaxProfit = TaskClass.FindMax(Films, 2019);
                dataGridView1.Rows.Clear();
                dataGridView1.ColumnCount = 8;
                dataGridView1.Columns[0].Name = "Pavadinimas";
                dataGridView1.Columns[0].Width = 130;
                dataGridView1.Columns[1].Name = "Metai";
                dataGridView1.Columns[1].Width = 40;
                dataGridView1.Columns[2].Name = "Žanras";
                dataGridView1.Columns[2].Width = 60;
                dataGridView1.Columns[3].Name = "Leidėjas";
                dataGridView1.Columns[3].Width = 160;
                dataGridView1.Columns[4].Name = "Režisierius";
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].Name = "Aktorius";
                dataGridView1.Columns[5].Width = 100;
                dataGridView1.Columns[6].Name = "Aktorius";
                dataGridView1.Columns[6].Width = 100;
                dataGridView1.Columns[7].Name = "Uždirbis";
                dataGridView1.Columns[7].Width = 80;
                if (MaxProfit != null)
                {
                    for (int i = 0; i < MaxProfit.Count; i++)
                    {
                        Film film = MaxProfit[i];
                        dataGridView1.Rows.Add(film.Name, film.Year, film.Type, film.Company, film.Director, film.Actor1, film.Actor2, film.Profit);
                    }
                }
                else
                    MessageBox.Show("Informacijos apie daugiauniai uždirbusį filmą nėra.", "Įspėjimas");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Nėra importuotų duomenų.", "Įspėjimas!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> Directors = TaskClass.FindDirectors(Films);             
                List<int> Dir = TaskClass.CountDirectors(Films);
                int a = TaskClass.dirMax(Dir);
                List<string> maxDir = TaskClass.FindMaxCountDirector(Directors, Dir, a);
                dataGridView1.Rows.Clear();
                dataGridView1.ColumnCount = 1;
                dataGridView1.Columns[0].Name = "Režisierius";
                dataGridView1.Columns[0].Width = 100;
                if (maxDir != null)
                {
                    for (int i = 0; i < maxDir.Count; i++)
                    {                   
                        dataGridView1.Rows.Add(maxDir[i]);
                    }
                }
                else
                    MessageBox.Show("Informacijos apie daugiauniai uždirbusį filmą nėra.", "Įspėjimas");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Nėra importuotų duomenų.", "Įspėjimas!" );
            }
        }

        private void baigtiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                List<Film> Ncage = TaskClass.NCageFimls(Films);
            if (Ncage.Count != 0)
            {
                InOutClass.PrintMuseumsToCSVFile("cage.csv", Ncage);
                MessageBox.Show("Duomenys eskportuoti į Cage.CSV.", "Informacija!");
            }
            else
            {
                MessageBox.Show("Nėra duomenų,kuriuos būtų galima eskportuoti.", "Informacija!");
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nėra importuotų duomenų.", "Įspėjimas!");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                    dataGridView1.Rows.Clear();
                    dataGridView1.ColumnCount = 8;
                    dataGridView1.Columns[0].Name = "Pavadinimas";
                    dataGridView1.Columns[0].Width = 130;
                    dataGridView1.Columns[1].Name = "Metai";
                    dataGridView1.Columns[1].Width = 40;
                    dataGridView1.Columns[2].Name = "Žanras";
                    dataGridView1.Columns[2].Width = 60;
                    dataGridView1.Columns[3].Name = "Leidėjas";
                    dataGridView1.Columns[3].Width = 160;
                    dataGridView1.Columns[4].Name = "Režisierius";
                    dataGridView1.Columns[4].Width = 100;
                    dataGridView1.Columns[5].Name = "Aktorius";
                    dataGridView1.Columns[5].Width = 100;
                    dataGridView1.Columns[6].Name = "Aktorius";
                    dataGridView1.Columns[6].Width = 100;
                    dataGridView1.Columns[7].Name = "Uždirbis";
                    dataGridView1.Columns[7].Width = 80;
                  
                    for (int i = 0; i < Films.Count; i++)
                     {
                      Film film = Films[i];
                      dataGridView1.Rows.Add(film.Name, film.Year, film.Type, film.Company, film.Director, film.Actor1, film.Actor2, film.Profit);
                     }                   
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nėra importuotų duomenų.", "Įspėjimas!");
            }
        }
    }
}

