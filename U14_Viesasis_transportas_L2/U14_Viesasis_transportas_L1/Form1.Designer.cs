namespace U14_Viesasis_transportas_L1
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
            this.rezultatai = new System.Windows.Forms.RichTextBox();
            this.nurodytaszodis = new System.Windows.Forms.TextBox();
            this.areiksme = new System.Windows.Forms.TextBox();
            this.breiksme = new System.Windows.Forms.TextBox();
            this.Ilgis = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.failasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.įvestiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autobusaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.troleibusaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baigtiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skaičiavimaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rastiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sąrašasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rikiuotiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.šalinimasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iterpimas2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagalbaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.užduotisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nurodymaiVartotojuiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.papildomasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rezultatai
            // 
            this.rezultatai.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.rezultatai.Location = new System.Drawing.Point(12, 27);
            this.rezultatai.Name = "rezultatai";
            this.rezultatai.Size = new System.Drawing.Size(606, 472);
            this.rezultatai.TabIndex = 0;
            this.rezultatai.Text = "";
            // 
            // nurodytaszodis
            // 
            this.nurodytaszodis.Location = new System.Drawing.Point(12, 520);
            this.nurodytaszodis.Name = "nurodytaszodis";
            this.nurodytaszodis.Size = new System.Drawing.Size(209, 20);
            this.nurodytaszodis.TabIndex = 8;
            this.nurodytaszodis.Text = "Įveskite žodį";
            // 
            // areiksme
            // 
            this.areiksme.Location = new System.Drawing.Point(642, 194);
            this.areiksme.Name = "areiksme";
            this.areiksme.Size = new System.Drawing.Size(100, 20);
            this.areiksme.TabIndex = 9;
            this.areiksme.Text = "Įveskite a reikšmę";
            // 
            // breiksme
            // 
            this.breiksme.Location = new System.Drawing.Point(748, 194);
            this.breiksme.Name = "breiksme";
            this.breiksme.Size = new System.Drawing.Size(103, 20);
            this.breiksme.TabIndex = 10;
            this.breiksme.Text = "Įveskite b reikšmę";
            // 
            // Ilgis
            // 
            this.Ilgis.AutoSize = true;
            this.Ilgis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Ilgis.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Ilgis.Location = new System.Drawing.Point(624, 151);
            this.Ilgis.Name = "Ilgis";
            this.Ilgis.Size = new System.Drawing.Size(244, 15);
            this.Ilgis.TabIndex = 11;
            this.Ilgis.Text = "Autobusų ir troleibusų maršrutų ilgiai";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.failasToolStripMenuItem,
            this.skaičiavimaiToolStripMenuItem,
            this.pagalbaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(880, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // failasToolStripMenuItem
            // 
            this.failasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.įvestiToolStripMenuItem,
            this.baigtiToolStripMenuItem});
            this.failasToolStripMenuItem.Name = "failasToolStripMenuItem";
            this.failasToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.failasToolStripMenuItem.Text = "Failas";
            // 
            // įvestiToolStripMenuItem
            //// 
            this.įvestiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autobusaiToolStripMenuItem,
            this.troleibusaiToolStripMenuItem,
            this.papildomasToolStripMenuItem});
            this.įvestiToolStripMenuItem.Name = "įvestiToolStripMenuItem";
            this.įvestiToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.įvestiToolStripMenuItem.Text = "Įvesti";
            this.įvestiToolStripMenuItem.Click += new System.EventHandler(this.įvestiToolStripMenuItem_Click);
            // 
            // autobusaiToolStripMenuItem
            // 
            this.autobusaiToolStripMenuItem.Name = "autobusaiToolStripMenuItem";
            this.autobusaiToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.autobusaiToolStripMenuItem.Text = "Autobusai";
            this.autobusaiToolStripMenuItem.Click += new System.EventHandler(this.autobusaiToolStripMenuItem_Click);
            // 
            // troleibusaiToolStripMenuItem
            // 
            this.troleibusaiToolStripMenuItem.Name = "troleibusaiToolStripMenuItem";
            this.troleibusaiToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.troleibusaiToolStripMenuItem.Text = "Troleibusai";
            this.troleibusaiToolStripMenuItem.Click += new System.EventHandler(this.troleibusaiToolStripMenuItem_Click);
            // 
            // baigtiToolStripMenuItem
            // 
            this.baigtiToolStripMenuItem.Name = "baigtiToolStripMenuItem";
            this.baigtiToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.baigtiToolStripMenuItem.Text = "Baigti";
            this.baigtiToolStripMenuItem.Click += new System.EventHandler(this.baigtiToolStripMenuItem_Click);
            // 
            // skaičiavimaiToolStripMenuItem
            // 
            this.skaičiavimaiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rastiToolStripMenuItem,
            this.sąrašasToolStripMenuItem,
            this.rikiuotiToolStripMenuItem,
            this.šalinimasToolStripMenuItem,
            this.iterpimas2ToolStripMenuItem});
            this.skaičiavimaiToolStripMenuItem.Name = "skaičiavimaiToolStripMenuItem";
            this.skaičiavimaiToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.skaičiavimaiToolStripMenuItem.Text = "Skaičiavimai";
            // 
            // rastiToolStripMenuItem
            // 
            this.rastiToolStripMenuItem.Name = "rastiToolStripMenuItem";
            this.rastiToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.rastiToolStripMenuItem.Text = "Rasti";
            this.rastiToolStripMenuItem.Click += new System.EventHandler(this.rastiToolStripMenuItem_Click);
            // 
            // sąrašasToolStripMenuItem
            // 
            this.sąrašasToolStripMenuItem.Name = "sąrašasToolStripMenuItem";
            this.sąrašasToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.sąrašasToolStripMenuItem.Text = "Sąrašas";
            this.sąrašasToolStripMenuItem.Click += new System.EventHandler(this.sąrašasToolStripMenuItem_Click);
            // 
            // rikiuotiToolStripMenuItem
            // 
            this.rikiuotiToolStripMenuItem.Name = "rikiuotiToolStripMenuItem";
            this.rikiuotiToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.rikiuotiToolStripMenuItem.Text = "Rikiuoti";
            this.rikiuotiToolStripMenuItem.Click += new System.EventHandler(this.rikiuotiToolStripMenuItem_Click);
            // 
            // šalinimasToolStripMenuItem
            // 
            this.šalinimasToolStripMenuItem.Name = "šalinimasToolStripMenuItem";
            this.šalinimasToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.šalinimasToolStripMenuItem.Text = "Šalinimas";
            this.šalinimasToolStripMenuItem.Click += new System.EventHandler(this.šalinimasToolStripMenuItem_Click);
            // 
            // iterpimas2ToolStripMenuItem
            // 
            this.iterpimas2ToolStripMenuItem.Name = "iterpimas2ToolStripMenuItem";
            this.iterpimas2ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.iterpimas2ToolStripMenuItem.Text = "Iterpimas";
            this.iterpimas2ToolStripMenuItem.Click += new System.EventHandler(this.iterpimas2ToolStripMenuItem_Click);
            // 
            // pagalbaToolStripMenuItem
            // 
            this.pagalbaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.užduotisToolStripMenuItem,
            this.nurodymaiVartotojuiToolStripMenuItem});
            this.pagalbaToolStripMenuItem.Name = "pagalbaToolStripMenuItem";
            this.pagalbaToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.pagalbaToolStripMenuItem.Text = "Pagalba";
            // 
            // užduotisToolStripMenuItem
            // 
            this.užduotisToolStripMenuItem.Name = "užduotisToolStripMenuItem";
            this.užduotisToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.užduotisToolStripMenuItem.Text = "Užduotis";
            this.užduotisToolStripMenuItem.Click += new System.EventHandler(this.užduotisToolStripMenuItem_Click);
            // 
            // nurodymaiVartotojuiToolStripMenuItem
            // 
            this.nurodymaiVartotojuiToolStripMenuItem.Name = "nurodymaiVartotojuiToolStripMenuItem";
            this.nurodymaiVartotojuiToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.nurodymaiVartotojuiToolStripMenuItem.Text = "Nurodymai vartotojui";
            this.nurodymaiVartotojuiToolStripMenuItem.Click += new System.EventHandler(this.nurodymaiVartotojuiToolStripMenuItem_Click);
            // 
            // papildomasToolStripMenuItem
            // 
            this.papildomasToolStripMenuItem.Name = "papildomasToolStripMenuItem";
            this.papildomasToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.papildomasToolStripMenuItem.Text = "Papildomas";
            this.papildomasToolStripMenuItem.Click += new System.EventHandler(this.papildomasToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 675);
            this.Controls.Add(this.Ilgis);
            this.Controls.Add(this.breiksme);
            this.Controls.Add(this.areiksme);
            this.Controls.Add(this.nurodytaszodis);
            this.Controls.Add(this.rezultatai);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Viešasis transportas";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rezultatai;
        private System.Windows.Forms.TextBox nurodytaszodis;
        private System.Windows.Forms.TextBox areiksme;
        private System.Windows.Forms.TextBox breiksme;
        private System.Windows.Forms.Label Ilgis;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem failasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem įvestiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baigtiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skaičiavimaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rikiuotiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sąrašasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem šalinimasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagalbaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem užduotisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nurodymaiVartotojuiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rastiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autobusaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem troleibusaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iterpimas2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem papildomasToolStripMenuItem;
    }
}

