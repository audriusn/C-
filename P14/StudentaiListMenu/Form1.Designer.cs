namespace StudentaiListMenu
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.failasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.įvestiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spausdintiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baigtiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skaičiavimaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentųSkaičiusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentųĮvestinimaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vyrųVidurkisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moretųVidurkisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagalbaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.užduotisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nurodymaiVartotojuiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duomenys = new System.Windows.Forms.RichTextBox();
            this.vertinimai = new System.Windows.Forms.ComboBox();
            this.rezultatas = new System.Windows.Forms.Label();
            this.pavardeVrd = new System.Windows.Forms.TextBox();
            this.rezultatai = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.vyruVidurkis = new System.Windows.Forms.Label();
            this.moteruVidurkis = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rezultatai)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.failasToolStripMenuItem,
            this.skaičiavimaiToolStripMenuItem,
            this.pagalbaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1099, 36);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // failasToolStripMenuItem
            // 
            this.failasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.įvestiToolStripMenuItem,
            this.spausdintiToolStripMenuItem,
            this.baigtiToolStripMenuItem});
            this.failasToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.failasToolStripMenuItem.Name = "failasToolStripMenuItem";
            this.failasToolStripMenuItem.Size = new System.Drawing.Size(78, 32);
            this.failasToolStripMenuItem.Text = "Failas ";
            // 
            // įvestiToolStripMenuItem
            // 
            this.įvestiToolStripMenuItem.Name = "įvestiToolStripMenuItem";
            this.įvestiToolStripMenuItem.Size = new System.Drawing.Size(190, 32);
            this.įvestiToolStripMenuItem.Text = "Įvesti";
            this.įvestiToolStripMenuItem.Click += new System.EventHandler(this.įvestiToolStripMenuItem_Click);
            // 
            // spausdintiToolStripMenuItem
            // 
            this.spausdintiToolStripMenuItem.Name = "spausdintiToolStripMenuItem";
            this.spausdintiToolStripMenuItem.Size = new System.Drawing.Size(190, 32);
            this.spausdintiToolStripMenuItem.Text = "Spausdinti";
            this.spausdintiToolStripMenuItem.Click += new System.EventHandler(this.spausdintiToolStripMenuItem_Click);
            // 
            // baigtiToolStripMenuItem
            // 
            this.baigtiToolStripMenuItem.Name = "baigtiToolStripMenuItem";
            this.baigtiToolStripMenuItem.Size = new System.Drawing.Size(190, 32);
            this.baigtiToolStripMenuItem.Text = "Baigti";
            this.baigtiToolStripMenuItem.Click += new System.EventHandler(this.baigtiToolStripMenuItem_Click);
            // 
            // skaičiavimaiToolStripMenuItem
            // 
            this.skaičiavimaiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studentųSkaičiusToolStripMenuItem,
            this.studentųĮvestinimaiToolStripMenuItem,
            this.vyrųVidurkisToolStripMenuItem,
            this.moretųVidurkisToolStripMenuItem});
            this.skaičiavimaiToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.skaičiavimaiToolStripMenuItem.Name = "skaičiavimaiToolStripMenuItem";
            this.skaičiavimaiToolStripMenuItem.Size = new System.Drawing.Size(133, 32);
            this.skaičiavimaiToolStripMenuItem.Text = "Skaičiavimai";
            // 
            // studentųSkaičiusToolStripMenuItem
            // 
            this.studentųSkaičiusToolStripMenuItem.Name = "studentųSkaičiusToolStripMenuItem";
            this.studentųSkaičiusToolStripMenuItem.Size = new System.Drawing.Size(277, 32);
            this.studentųSkaičiusToolStripMenuItem.Text = "Studentų skaičius";
            this.studentųSkaičiusToolStripMenuItem.Click += new System.EventHandler(this.studentųSkaičiusToolStripMenuItem_Click);
            // 
            // studentųĮvestinimaiToolStripMenuItem
            // 
            this.studentųĮvestinimaiToolStripMenuItem.Name = "studentųĮvestinimaiToolStripMenuItem";
            this.studentųĮvestinimaiToolStripMenuItem.Size = new System.Drawing.Size(277, 32);
            this.studentųĮvestinimaiToolStripMenuItem.Text = "Studentų įvertinimas";
            this.studentųĮvestinimaiToolStripMenuItem.Click += new System.EventHandler(this.studentųĮvestinimaiToolStripMenuItem_Click);
            // 
            // vyrųVidurkisToolStripMenuItem
            // 
            this.vyrųVidurkisToolStripMenuItem.Name = "vyrųVidurkisToolStripMenuItem";
            this.vyrųVidurkisToolStripMenuItem.Size = new System.Drawing.Size(277, 32);
            this.vyrųVidurkisToolStripMenuItem.Text = "Vyrų vidurkis";
            this.vyrųVidurkisToolStripMenuItem.Click += new System.EventHandler(this.vyrųVidurkisToolStripMenuItem_Click);
            // 
            // moretųVidurkisToolStripMenuItem
            // 
            this.moretųVidurkisToolStripMenuItem.Name = "moretųVidurkisToolStripMenuItem";
            this.moretųVidurkisToolStripMenuItem.Size = new System.Drawing.Size(277, 32);
            this.moretųVidurkisToolStripMenuItem.Text = "Moretų vidurkis";
            this.moretųVidurkisToolStripMenuItem.Click += new System.EventHandler(this.moretųVidurkisToolStripMenuItem_Click);
            // 
            // pagalbaToolStripMenuItem
            // 
            this.pagalbaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.užduotisToolStripMenuItem,
            this.nurodymaiVartotojuiToolStripMenuItem});
            this.pagalbaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.pagalbaToolStripMenuItem.Name = "pagalbaToolStripMenuItem";
            this.pagalbaToolStripMenuItem.Size = new System.Drawing.Size(95, 32);
            this.pagalbaToolStripMenuItem.Text = "Pagalba";
            // 
            // užduotisToolStripMenuItem
            // 
            this.užduotisToolStripMenuItem.Name = "užduotisToolStripMenuItem";
            this.užduotisToolStripMenuItem.Size = new System.Drawing.Size(288, 32);
            this.užduotisToolStripMenuItem.Text = "Užduotis";
            this.užduotisToolStripMenuItem.Click += new System.EventHandler(this.užduotisToolStripMenuItem_Click);
            // 
            // nurodymaiVartotojuiToolStripMenuItem
            // 
            this.nurodymaiVartotojuiToolStripMenuItem.Name = "nurodymaiVartotojuiToolStripMenuItem";
            this.nurodymaiVartotojuiToolStripMenuItem.Size = new System.Drawing.Size(288, 32);
            this.nurodymaiVartotojuiToolStripMenuItem.Text = "Nurodymai vartotojui";
            this.nurodymaiVartotojuiToolStripMenuItem.Click += new System.EventHandler(this.nurodymaiVartotojuiToolStripMenuItem_Click);
            // 
            // duomenys
            // 
            this.duomenys.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.duomenys.Location = new System.Drawing.Point(12, 46);
            this.duomenys.Name = "duomenys";
            this.duomenys.Size = new System.Drawing.Size(689, 188);
            this.duomenys.TabIndex = 1;
            this.duomenys.Text = "Čia bus parodyti programos pradiniai duomenys";
            this.duomenys.TextChanged += new System.EventHandler(this.duomenys_TextChanged);
            // 
            // vertinimai
            // 
            this.vertinimai.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.vertinimai.FormattingEnabled = true;
            this.vertinimai.Location = new System.Drawing.Point(720, 46);
            this.vertinimai.Name = "vertinimai";
            this.vertinimai.Size = new System.Drawing.Size(231, 33);
            this.vertinimai.TabIndex = 2;
            this.vertinimai.Text = "Pasirinkite pažymį";
            this.vertinimai.SelectedIndexChanged += new System.EventHandler(this.vertinimai_SelectedIndexChanged);
            // 
            // rezultatas
            // 
            this.rezultatas.AutoSize = true;
            this.rezultatas.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.rezultatas.ForeColor = System.Drawing.Color.Black;
            this.rezultatas.Location = new System.Drawing.Point(717, 96);
            this.rezultatas.Name = "rezultatas";
            this.rezultatas.Size = new System.Drawing.Size(234, 23);
            this.rezultatas.TabIndex = 3;
            this.rezultatas.Text = "Čia bus parodyti rezultatai";
            this.rezultatas.Click += new System.EventHandler(this.rezultatas_Click);
            // 
            // pavardeVrd
            // 
            this.pavardeVrd.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.pavardeVrd.Location = new System.Drawing.Point(13, 241);
            this.pavardeVrd.Name = "pavardeVrd";
            this.pavardeVrd.Size = new System.Drawing.Size(519, 30);
            this.pavardeVrd.TabIndex = 4;
            this.pavardeVrd.Text = "Čia užrašykite pavardę ir vardą";
            this.pavardeVrd.TextChanged += new System.EventHandler(this.pavardeVrd_TextChanged);
            // 
            // rezultatai
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.rezultatai.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.rezultatai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.rezultatai.DefaultCellStyle = dataGridViewCellStyle2;
            this.rezultatai.Location = new System.Drawing.Point(13, 279);
            this.rezultatai.Name = "rezultatai";
            this.rezultatai.RowHeadersWidth = 51;
            this.rezultatai.RowTemplate.Height = 24;
            this.rezultatai.Size = new System.Drawing.Size(688, 150);
            this.rezultatai.TabIndex = 5;
            this.rezultatai.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rezultatai_CellContentClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // vyruVidurkis
            // 
            this.vyruVidurkis.AutoSize = true;
            this.vyruVidurkis.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.vyruVidurkis.Location = new System.Drawing.Point(717, 140);
            this.vyruVidurkis.Name = "vyruVidurkis";
            this.vyruVidurkis.Size = new System.Drawing.Size(275, 23);
            this.vyruVidurkis.TabIndex = 6;
            this.vyruVidurkis.Text = "Čia bus parodytas vyrų vidurkis";
            this.vyruVidurkis.Click += new System.EventHandler(this.vyruVidurkis_Click);
            // 
            // moteruVidurkis
            // 
            this.moteruVidurkis.AutoSize = true;
            this.moteruVidurkis.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.moteruVidurkis.Location = new System.Drawing.Point(717, 186);
            this.moteruVidurkis.Name = "moteruVidurkis";
            this.moteruVidurkis.Size = new System.Drawing.Size(297, 23);
            this.moteruVidurkis.TabIndex = 7;
            this.moteruVidurkis.Text = "Čia bus parodytas moterų vidurkis";
            this.moteruVidurkis.Click += new System.EventHandler(this.moteruVidurkis_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 450);
            this.Controls.Add(this.moteruVidurkis);
            this.Controls.Add(this.vyruVidurkis);
            this.Controls.Add(this.rezultatai);
            this.Controls.Add(this.pavardeVrd);
            this.Controls.Add(this.rezultatas);
            this.Controls.Add(this.vertinimai);
            this.Controls.Add(this.duomenys);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Studentai";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rezultatai)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem failasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem įvestiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spausdintiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baigtiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skaičiavimaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentųSkaičiusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentųĮvestinimaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagalbaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem užduotisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nurodymaiVartotojuiToolStripMenuItem;
        private System.Windows.Forms.RichTextBox duomenys;
        private System.Windows.Forms.ComboBox vertinimai;
        private System.Windows.Forms.Label rezultatas;
        private System.Windows.Forms.TextBox pavardeVrd;
        private System.Windows.Forms.DataGridView rezultatai;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem vyrųVidurkisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moretųVidurkisToolStripMenuItem;
        private System.Windows.Forms.Label vyruVidurkis;
        private System.Windows.Forms.Label moteruVidurkis;
    }
}

