namespace L14_Automobiliu_parkas
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.įvedimasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skaičiavimaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagalbaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nurodytaspalva = new System.Windows.Forms.TextBox();
            this.areiksme = new System.Windows.Forms.TextBox();
            this.breiksme = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rezultatai
            // 
            this.rezultatai.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.rezultatai.Location = new System.Drawing.Point(12, 27);
            this.rezultatai.Name = "rezultatai";
            this.rezultatai.Size = new System.Drawing.Size(729, 361);
            this.rezultatai.TabIndex = 0;
            this.rezultatai.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.įvedimasToolStripMenuItem,
            this.skaičiavimaiToolStripMenuItem,
            this.pagalbaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(808, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // įvedimasToolStripMenuItem
            // 
            this.įvedimasToolStripMenuItem.Name = "įvedimasToolStripMenuItem";
            this.įvedimasToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.įvedimasToolStripMenuItem.Text = "Įvedimas";
            this.įvedimasToolStripMenuItem.Click += new System.EventHandler(this.įvedimasToolStripMenuItem_Click);
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
            // nurodytaspalva
            // 
            this.nurodytaspalva.Location = new System.Drawing.Point(26, 405);
            this.nurodytaspalva.Name = "nurodytaspalva";
            this.nurodytaspalva.Size = new System.Drawing.Size(182, 20);
            this.nurodytaspalva.TabIndex = 2;
            this.nurodytaspalva.Text = "Nurodykite spalvą";
            // 
            // areiksme
            // 
            this.areiksme.Location = new System.Drawing.Point(26, 461);
            this.areiksme.Name = "areiksme";
            this.areiksme.Size = new System.Drawing.Size(117, 20);
            this.areiksme.TabIndex = 3;
            this.areiksme.Text = "Iveskite a reiksme";
            // 
            // breiksme
            // 
            this.breiksme.Location = new System.Drawing.Point(164, 461);
            this.breiksme.Name = "breiksme";
            this.breiksme.Size = new System.Drawing.Size(119, 20);
            this.breiksme.TabIndex = 4;
            this.breiksme.Text = "Iveskite b reiksme";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 434);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Įveskite metų intervalo [a;b] reikšmes naujam sąrašui sudaryti";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 504);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.breiksme);
            this.Controls.Add(this.areiksme);
            this.Controls.Add(this.nurodytaspalva);
            this.Controls.Add(this.rezultatai);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Automobilių parkas";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rezultatai;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem įvedimasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skaičiavimaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagalbaToolStripMenuItem;
        private System.Windows.Forms.TextBox nurodytaspalva;
        private System.Windows.Forms.TextBox areiksme;
        private System.Windows.Forms.TextBox breiksme;
        private System.Windows.Forms.Label label1;
    }
}

