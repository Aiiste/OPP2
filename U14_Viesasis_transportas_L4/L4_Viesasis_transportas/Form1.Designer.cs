namespace L4_Viesasis_transportas
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.įvedimasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autobusaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.troleibusaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skaičiavimaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagalbaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rezultatai = new System.Windows.Forms.RichTextBox();
            this.areiksme = new System.Windows.Forms.TextBox();
            this.breiksme = new System.Windows.Forms.TextBox();
            this.nurodytaszodis = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.įvedimasToolStripMenuItem,
            this.skaičiavimaiToolStripMenuItem,
            this.pagalbaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(699, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // įvedimasToolStripMenuItem
            // 
            this.įvedimasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autobusaiToolStripMenuItem,
            this.troleibusaiToolStripMenuItem});
            this.įvedimasToolStripMenuItem.Name = "įvedimasToolStripMenuItem";
            this.įvedimasToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.įvedimasToolStripMenuItem.Text = "Įvedimas";
            // 
            // autobusaiToolStripMenuItem
            // 
            this.autobusaiToolStripMenuItem.Name = "autobusaiToolStripMenuItem";
            this.autobusaiToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.autobusaiToolStripMenuItem.Text = "Autobusai";
            this.autobusaiToolStripMenuItem.Click += new System.EventHandler(this.autobusaiToolStripMenuItem_Click);
            // 
            // troleibusaiToolStripMenuItem
            // 
            this.troleibusaiToolStripMenuItem.Name = "troleibusaiToolStripMenuItem";
            this.troleibusaiToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.troleibusaiToolStripMenuItem.Text = "Troleibusai";
            this.troleibusaiToolStripMenuItem.Click += new System.EventHandler(this.troleibusaiToolStripMenuItem_Click);
            // 
            // skaičiavimaiToolStripMenuItem
            // 
            this.skaičiavimaiToolStripMenuItem.Name = "skaičiavimaiToolStripMenuItem";
            this.skaičiavimaiToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.skaičiavimaiToolStripMenuItem.Text = "Skaičiavimai";
            this.skaičiavimaiToolStripMenuItem.Click += new System.EventHandler(this.skaičiavimaiToolStripMenuItem_Click);
            // 
            // pagalbaToolStripMenuItem
            // 
            this.pagalbaToolStripMenuItem.Name = "pagalbaToolStripMenuItem";
            this.pagalbaToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.pagalbaToolStripMenuItem.Text = "Pagalba";
            this.pagalbaToolStripMenuItem.Click += new System.EventHandler(this.pagalbaToolStripMenuItem_Click);
            // 
            // rezultatai
            // 
            this.rezultatai.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.rezultatai.Location = new System.Drawing.Point(13, 26);
            this.rezultatai.Name = "rezultatai";
            this.rezultatai.Size = new System.Drawing.Size(662, 391);
            this.rezultatai.TabIndex = 1;
            this.rezultatai.Text = "";
            // 
            // areiksme
            // 
            this.areiksme.Location = new System.Drawing.Point(25, 423);
            this.areiksme.Name = "areiksme";
            this.areiksme.Size = new System.Drawing.Size(90, 20);
            this.areiksme.TabIndex = 2;
            this.areiksme.Text = "Įveskite a reikšmę";
            // 
            // breiksme
            // 
            this.breiksme.Location = new System.Drawing.Point(166, 423);
            this.breiksme.Name = "breiksme";
            this.breiksme.Size = new System.Drawing.Size(95, 20);
            this.breiksme.TabIndex = 3;
            this.breiksme.Text = "Įveskite b reikšmę";
            // 
            // nurodytaszodis
            // 
            this.nurodytaszodis.Location = new System.Drawing.Point(25, 462);
            this.nurodytaszodis.Name = "nurodytaszodis";
            this.nurodytaszodis.Size = new System.Drawing.Size(236, 20);
            this.nurodytaszodis.TabIndex = 4;
            this.nurodytaszodis.Text = "Nurodykite pavadinimą";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 504);
            this.Controls.Add(this.nurodytaszodis);
            this.Controls.Add(this.breiksme);
            this.Controls.Add(this.areiksme);
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

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem įvedimasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autobusaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem troleibusaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skaičiavimaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagalbaToolStripMenuItem;
        private System.Windows.Forms.RichTextBox rezultatai;
        private System.Windows.Forms.TextBox areiksme;
        private System.Windows.Forms.TextBox breiksme;
        private System.Windows.Forms.TextBox nurodytaszodis;
    }
}

