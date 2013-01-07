namespace museSort
{
    partial class MainGUI
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Logi = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.Modyfikuj = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.Eksport = new System.Windows.Forms.Button();
            this.directoryTreeView = new System.Windows.Forms.TreeView();
            this.otwartyFolder = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.schematy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.format = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.NazwaPliku = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Tytul = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.wykonawca = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Album = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Rok = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Gatunki = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.NumerSciezki = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::museSort.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(1000, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(196, 233);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Logi
            // 
            this.Logi.FormattingEnabled = true;
            this.Logi.Location = new System.Drawing.Point(994, 275);
            this.Logi.Name = "Logi";
            this.Logi.Size = new System.Drawing.Size(215, 290);
            this.Logi.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1221, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(38, 20);
            this.toolStripMenuItem1.Text = "Plik";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(52, 20);
            this.toolStripMenuItem2.Text = "Edytuj";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(86, 20);
            this.toolStripMenuItem3.Text = "O programie";
            // 
            // Modyfikuj
            // 
            this.Modyfikuj.BackColor = System.Drawing.Color.SkyBlue;
            this.Modyfikuj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Modyfikuj.Location = new System.Drawing.Point(97, 36);
            this.Modyfikuj.Name = "Modyfikuj";
            this.Modyfikuj.Size = new System.Drawing.Size(145, 51);
            this.Modyfikuj.TabIndex = 4;
            this.Modyfikuj.Text = "Modyfikuj tagi";
            this.Modyfikuj.UseVisualStyleBackColor = false;
            this.Modyfikuj.Click += new System.EventHandler(this.Modyfikuj_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DodgerBlue;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(286, 36);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 51);
            this.button2.TabIndex = 5;
            this.button2.Text = "Sortuj";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(12, 633);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(1184, 31);
            this.progressBar2.TabIndex = 6;
            // 
            // Eksport
            // 
            this.Eksport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Eksport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Eksport.Location = new System.Drawing.Point(1000, 585);
            this.Eksport.Name = "Eksport";
            this.Eksport.Size = new System.Drawing.Size(173, 29);
            this.Eksport.TabIndex = 7;
            this.Eksport.Text = "Eksport do pliku";
            this.Eksport.UseVisualStyleBackColor = false;
            // 
            // directoryTreeView
            // 
            this.directoryTreeView.Location = new System.Drawing.Point(69, 113);
            this.directoryTreeView.Name = "directoryTreeView";
            this.directoryTreeView.Size = new System.Drawing.Size(281, 352);
            this.directoryTreeView.TabIndex = 8;
            // 
            // otwartyFolder
            // 
            this.otwartyFolder.FormattingEnabled = true;
            this.otwartyFolder.Location = new System.Drawing.Point(419, 110);
            this.otwartyFolder.Name = "otwartyFolder";
            this.otwartyFolder.Size = new System.Drawing.Size(516, 355);
            this.otwartyFolder.TabIndex = 9;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.schematy);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.format);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(29, 504);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(906, 110);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Schemat zapisu:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // schematy
            // 
            this.schematy.FormattingEnabled = true;
            this.schematy.Location = new System.Drawing.Point(136, 3);
            this.schematy.Name = "schematy";
            this.schematy.Size = new System.Drawing.Size(121, 21);
            this.schematy.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(263, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Format plików";
            // 
            // format
            // 
            this.format.FormattingEnabled = true;
            this.format.Location = new System.Drawing.Point(376, 3);
            this.format.Name = "format";
            this.format.Size = new System.Drawing.Size(121, 21);
            this.format.TabIndex = 3;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel2.Controls.Add(this.label3);
            this.flowLayoutPanel2.Controls.Add(this.NazwaPliku);
            this.flowLayoutPanel2.Controls.Add(this.label4);
            this.flowLayoutPanel2.Controls.Add(this.Tytul);
            this.flowLayoutPanel2.Controls.Add(this.label5);
            this.flowLayoutPanel2.Controls.Add(this.wykonawca);
            this.flowLayoutPanel2.Controls.Add(this.label6);
            this.flowLayoutPanel2.Controls.Add(this.Album);
            this.flowLayoutPanel2.Controls.Add(this.label7);
            this.flowLayoutPanel2.Controls.Add(this.Rok);
            this.flowLayoutPanel2.Controls.Add(this.label8);
            this.flowLayoutPanel2.Controls.Add(this.Gatunki);
            this.flowLayoutPanel2.Controls.Add(this.label9);
            this.flowLayoutPanel2.Controls.Add(this.NumerSciezki);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(29, 482);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(923, 132);
            this.flowLayoutPanel2.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nazwa pliku:";
            // 
            // NazwaPliku
            // 
            this.NazwaPliku.FormattingEnabled = true;
            this.NazwaPliku.Location = new System.Drawing.Point(106, 3);
            this.NazwaPliku.Name = "NazwaPliku";
            this.NazwaPliku.Size = new System.Drawing.Size(297, 17);
            this.NazwaPliku.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(409, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Tytuł:";
            // 
            // Tytul
            // 
            this.Tytul.FormattingEnabled = true;
            this.Tytul.Location = new System.Drawing.Point(462, 3);
            this.Tytul.Name = "Tytul";
            this.Tytul.Size = new System.Drawing.Size(402, 17);
            this.Tytul.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(3, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Wykonawca:";
            // 
            // wykonawca
            // 
            this.wykonawca.FormattingEnabled = true;
            this.wykonawca.Location = new System.Drawing.Point(107, 26);
            this.wykonawca.Name = "wykonawca";
            this.wykonawca.Size = new System.Drawing.Size(302, 17);
            this.wykonawca.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Location = new System.Drawing.Point(415, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Album:";
            // 
            // Album
            // 
            this.Album.FormattingEnabled = true;
            this.Album.Location = new System.Drawing.Point(479, 26);
            this.Album.Name = "Album";
            this.Album.Size = new System.Drawing.Size(391, 17);
            this.Album.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label7.Location = new System.Drawing.Point(3, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Rok wydania:";
            // 
            // Rok
            // 
            this.Rok.FormattingEnabled = true;
            this.Rok.Location = new System.Drawing.Point(112, 49);
            this.Rok.Name = "Rok";
            this.Rok.Size = new System.Drawing.Size(294, 17);
            this.Rok.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label8.Location = new System.Drawing.Point(412, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 20);
            this.label8.TabIndex = 5;
            this.label8.Text = "Gatunki:";
            // 
            // Gatunki
            // 
            this.Gatunki.FormattingEnabled = true;
            this.Gatunki.Location = new System.Drawing.Point(487, 49);
            this.Gatunki.Name = "Gatunki";
            this.Gatunki.Size = new System.Drawing.Size(382, 17);
            this.Gatunki.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label9.Location = new System.Drawing.Point(3, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 20);
            this.label9.TabIndex = 6;
            this.label9.Text = "Numer ścieżki";
            // 
            // NumerSciezki
            // 
            this.NumerSciezki.FormattingEnabled = true;
            this.NumerSciezki.Location = new System.Drawing.Point(116, 72);
            this.NumerSciezki.Name = "NumerSciezki";
            this.NumerSciezki.Size = new System.Drawing.Size(290, 17);
            this.NumerSciezki.TabIndex = 13;
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::museSort.Properties.Resources.tlo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1221, 695);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.otwartyFolder);
            this.Controls.Add(this.directoryTreeView);
            this.Controls.Add(this.Eksport);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Modyfikuj);
            this.Controls.Add(this.Logi);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainGUI";
            this.Text = "MuseSort";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox Logi;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.Button Modyfikuj;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Button Eksport;
        private System.Windows.Forms.TreeView directoryTreeView;
        private System.Windows.Forms.ListBox otwartyFolder;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox schematy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox format;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox NazwaPliku;
        private System.Windows.Forms.ListBox Tytul;
        private System.Windows.Forms.ListBox wykonawca;
        private System.Windows.Forms.ListBox Album;
        private System.Windows.Forms.ListBox Rok;
        private System.Windows.Forms.ListBox Gatunki;
        private System.Windows.Forms.ListBox NumerSciezki;
    }
}