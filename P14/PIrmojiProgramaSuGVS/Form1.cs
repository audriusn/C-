using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIrmojiProgramaSuGVS
{
    public partial class Form1 : Form
    {
        int ilgis, // stačiakampio ilgis    
            plotis, // stačiakampio plotis
            plotas; // sdtačiakampio plotas
        /// <summary>
        /// Kokstruktorius: formos komponemtams suteikia reikšmes
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
    

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Mygtuko "Įvesti" atliekami veiksmai.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></
        private void button1_Click_1(object sender, EventArgs e)
        {
            
                ilgis = Convert.ToInt32(textBox1.Text);
                plotis = Convert.ToInt32(textBox2.Text);
                button2.Enabled = true;      
        }
        /// <summary>
        /// Mygtuko "Skaičiuoti" atliekami veiksmai
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click_1(object sender, EventArgs e)
        {
            Plotas(ilgis,plotis);
            label3.Text = "Stačiakampio plotas: " + Convert.ToString(Plotas(ilgis, plotis));
        }
        /// <summary>
        /// Apskaičiuoja stačiakiampio plotą
        /// </summary>
        /// <param name="ilg"> stačiakmapio ilgis</param>
        /// <param name="plot">stačiakampio plotas</param>
        /// <returns> grąžina plotą</returns>
        static int Plotas (int ilg, int plot)
        {
            return ilg * plot;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
