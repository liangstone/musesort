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
            this.button1 = new System.Windows.Forms.Button();
            this.Logi = new System.Windows.Forms.TextBox();
            this.Dodaj_Do_Głównego = new System.Windows.Forms.Button();
            this.Ustal_glowny = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::museSort.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(588, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(196, 233);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(785, 24);
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
            this.Modyfikuj.Font = new System.Drawing.Font("Tempus Sans ITC", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Modyfikuj.Location = new System.Drawing.Point(12, 37);
            this.Modyfikuj.Name = "Modyfikuj";
            this.Modyfikuj.Size = new System.Drawing.Size(243, 37);
            this.Modyfikuj.TabIndex = 4;
            this.Modyfikuj.Text = "Modyfikuj tagi";
            this.Modyfikuj.UseVisualStyleBackColor = false;
            this.Modyfikuj.Click += new System.EventHandler(this.Modyfikuj_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.SkyBlue;
            this.button2.Font = new System.Drawing.Font("Tempus Sans ITC", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(12, 80);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(243, 38);
            this.button2.TabIndex = 5;
            this.button2.Text = "Sortuj";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(36, 593);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(708, 31);
            this.progressBar2.TabIndex = 6;
            // 
            // Eksport
            // 
            this.Eksport.BackColor = System.Drawing.Color.SkyBlue;
            this.Eksport.Font = new System.Drawing.Font("Tempus Sans ITC", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Eksport.Location = new System.Drawing.Point(588, 424);
            this.Eksport.Name = "Eksport";
            this.Eksport.Size = new System.Drawing.Size(173, 63);
            this.Eksport.TabIndex = 7;
            this.Eksport.Text = "Eksport logów do pliku";
            this.Eksport.UseVisualStyleBackColor = false;
            this.Eksport.Click += new System.EventHandler(this.Eksport_Click);
            // 
            // directoryTreeView
            // 
            this.directoryTreeView.Location = new System.Drawing.Point(12, 136);
            this.directoryTreeView.Name = "directoryTreeView";
            this.directoryTreeView.Size = new System.Drawing.Size(217, 342);
            this.directoryTreeView.TabIndex = 8;
            // 
            // otwartyFolder
            // 
            this.otwartyFolder.FormattingEnabled = true;
            this.otwartyFolder.Location = new System.Drawing.Point(253, 136);
            this.otwartyFolder.Name = "otwartyFolder";
            this.otwartyFolder.Size = new System.Drawing.Size(316, 342);
            this.otwartyFolder.TabIndex = 9;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.schematy);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.format);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(29, 504);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(729, 83);
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
            this.schematy.Items.AddRange(new object[] {
            "Wykonawca\\Album\\Piosenki",
            "Wykonawca\\Rok\\Album\\Piosenki",
            "Gatunek\\Wykonawca\\Album\\Piosenki",
            "Gatunek\\Wykonawca\\Piosenki",
            "Rok\\Gatunek\\Wykonawca\\Album\\Piosenki",
            "Rok\\Wykonawca\\Album\\Piosenki",
            "Piosenki\\Alfabetycznie",
            "Piosenki\\Wykonawca"});
            this.schematy.Location = new System.Drawing.Point(136, 3);
            this.schematy.Name = "schematy";
            this.schematy.Size = new System.Drawing.Size(335, 21);
            this.schematy.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(477, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Format plików";
            // 
            // format
            // 
            this.format.FormattingEnabled = true;
            this.format.Items.AddRange(new object[] {
            "Najlepszy",
            "MP3",
            "FLAC"});
            this.format.Location = new System.Drawing.Point(590, 3);
            this.format.Name = "format";
            this.format.Size = new System.Drawing.Size(107, 21);
            this.format.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SkyBlue;
            this.button1.Font = new System.Drawing.Font("Tempus Sans ITC", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(3, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 34);
            this.button1.TabIndex = 4;
            this.button1.Text = "Posortuj";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Logi
            // 
            this.Logi.Location = new System.Drawing.Point(588, 266);
            this.Logi.Multiline = true;
            this.Logi.Name = "Logi";
            this.Logi.Size = new System.Drawing.Size(185, 152);
            this.Logi.TabIndex = 11;
            // 
            // Dodaj_Do_Głównego
            // 
            this.Dodaj_Do_Głównego.BackColor = System.Drawing.Color.SkyBlue;
            this.Dodaj_Do_Głównego.Font = new System.Drawing.Font("Tempus Sans ITC", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dodaj_Do_Głównego.Location = new System.Drawing.Point(295, 37);
            this.Dodaj_Do_Głównego.Name = "Dodaj_Do_Głównego";
            this.Dodaj_Do_Głównego.Size = new System.Drawing.Size(274, 37);
            this.Dodaj_Do_Głównego.TabIndex = 12;
            this.Dodaj_Do_Głównego.Text = "Dodaj do głównego folderu";
            this.Dodaj_Do_Głównego.UseVisualStyleBackColor = false;
            this.Dodaj_Do_Głównego.Click += new System.EventHandler(this.Dodaj_Do_Głównego_Click);
            // 
            // Ustal_glowny
            // 
            this.Ustal_glowny.BackColor = System.Drawing.Color.SkyBlue;
            this.Ustal_glowny.Font = new System.Drawing.Font("Tempus Sans ITC", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ustal_glowny.Location = new System.Drawing.Point(295, 80);
            this.Ustal_glowny.Name = "Ustal_glowny";
            this.Ustal_glowny.Size = new System.Drawing.Size(274, 37);
            this.Ustal_glowny.TabIndex = 13;
            this.Ustal_glowny.Text = "Ustal główny folder z muzyką";
            this.Ustal_glowny.UseVisualStyleBackColor = false;
            this.Ustal_glowny.Click += new System.EventHandler(this.Ustal_glowny_Click);
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::museSort.Properties.Resources.tlo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(785, 639);
            this.Controls.Add(this.Ustal_glowny);
            this.Controls.Add(this.Dodaj_Do_Głównego);
            this.Controls.Add(this.Logi);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.otwartyFolder);
            this.Controls.Add(this.directoryTreeView);
            this.Controls.Add(this.Eksport);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Modyfikuj);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Logi;
        private System.Windows.Forms.Button Dodaj_Do_Głównego;
        private System.Windows.Forms.Button Ustal_glowny;
    }
}