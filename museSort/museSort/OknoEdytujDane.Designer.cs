namespace museSort
{
    partial class OknoEdytujDane
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.WykonawcaBox = new System.Windows.Forms.TextBox();
            this.AlbumBox = new System.Windows.Forms.TextBox();
            this.RokWydaniaBox = new System.Windows.Forms.TextBox();
            this.TytulBox = new System.Windows.Forms.TextBox();
            this.NazwaPlikuLabel = new System.Windows.Forms.Label();
            this.NazwaPlikuBox = new System.Windows.Forms.TextBox();
            this.otwoz_plik_button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.GatunkiLabel = new System.Windows.Forms.Label();
            this.GatunkiBox = new System.Windows.Forms.TextBox();
            this.NrSciezkiLabel = new System.Windows.Forms.Label();
            this.NrSciezkiBox = new System.Windows.Forms.TextBox();
            this.AktualizujButton = new System.Windows.Forms.Button();
            this.PrzywrocDomyslneButton = new System.Windows.Forms.Button();
            this.ZamknijButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(210, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Tytuł";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(210, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Wykonawca";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Album";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(213, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Rok wydania";
            // 
            // WykonawcaBox
            // 
            this.WykonawcaBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WykonawcaBox.Location = new System.Drawing.Point(213, 145);
            this.WykonawcaBox.Name = "WykonawcaBox";
            this.WykonawcaBox.Size = new System.Drawing.Size(398, 20);
            this.WykonawcaBox.TabIndex = 17;
            this.WykonawcaBox.TextChanged += new System.EventHandler(this.Box_TextChanged);
            // 
            // AlbumBox
            // 
            this.AlbumBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AlbumBox.Location = new System.Drawing.Point(213, 200);
            this.AlbumBox.Name = "AlbumBox";
            this.AlbumBox.Size = new System.Drawing.Size(398, 20);
            this.AlbumBox.TabIndex = 16;
            this.AlbumBox.TextChanged += new System.EventHandler(this.Box_TextChanged);
            // 
            // RokWydaniaBox
            // 
            this.RokWydaniaBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RokWydaniaBox.Location = new System.Drawing.Point(213, 255);
            this.RokWydaniaBox.Name = "RokWydaniaBox";
            this.RokWydaniaBox.Size = new System.Drawing.Size(398, 20);
            this.RokWydaniaBox.TabIndex = 15;
            // 
            // TytulBox
            // 
            this.TytulBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TytulBox.Location = new System.Drawing.Point(213, 86);
            this.TytulBox.Name = "TytulBox";
            this.TytulBox.Size = new System.Drawing.Size(398, 20);
            this.TytulBox.TabIndex = 14;
            this.TytulBox.TextChanged += new System.EventHandler(this.Box_TextChanged);
            // 
            // NazwaPlikuLabel
            // 
            this.NazwaPlikuLabel.AutoSize = true;
            this.NazwaPlikuLabel.Location = new System.Drawing.Point(210, 19);
            this.NazwaPlikuLabel.Name = "NazwaPlikuLabel";
            this.NazwaPlikuLabel.Size = new System.Drawing.Size(66, 13);
            this.NazwaPlikuLabel.TabIndex = 13;
            this.NazwaPlikuLabel.Text = "Nazwa Pliku";
            // 
            // NazwaPlikuBox
            // 
            this.NazwaPlikuBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NazwaPlikuBox.Location = new System.Drawing.Point(213, 35);
            this.NazwaPlikuBox.Name = "NazwaPlikuBox";
            this.NazwaPlikuBox.Size = new System.Drawing.Size(398, 20);
            this.NazwaPlikuBox.TabIndex = 12;
            this.NazwaPlikuBox.TextChanged += new System.EventHandler(this.Box_TextChanged);
            // 
            // otwoz_plik_button
            // 
            this.otwoz_plik_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.otwoz_plik_button.Font = new System.Drawing.Font("Book Antiqua", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.otwoz_plik_button.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.otwoz_plik_button.Location = new System.Drawing.Point(506, 456);
            this.otwoz_plik_button.Name = "otwoz_plik_button";
            this.otwoz_plik_button.Size = new System.Drawing.Size(105, 35);
            this.otwoz_plik_button.TabIndex = 11;
            this.otwoz_plik_button.Text = "Otwórz plik";
            this.otwoz_plik_button.UseVisualStyleBackColor = false;
            this.otwoz_plik_button.Click += new System.EventHandler(this.otwoz_plik_button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::museSort.Properties.Resources.logo1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(5, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(199, 231);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // GatunkiLabel
            // 
            this.GatunkiLabel.AutoSize = true;
            this.GatunkiLabel.Location = new System.Drawing.Point(213, 293);
            this.GatunkiLabel.Name = "GatunkiLabel";
            this.GatunkiLabel.Size = new System.Drawing.Size(44, 13);
            this.GatunkiLabel.TabIndex = 24;
            this.GatunkiLabel.Text = "Gatunki";
            // 
            // GatunkiBox
            // 
            this.GatunkiBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GatunkiBox.Location = new System.Drawing.Point(213, 309);
            this.GatunkiBox.Name = "GatunkiBox";
            this.GatunkiBox.Size = new System.Drawing.Size(398, 20);
            this.GatunkiBox.TabIndex = 23;
            this.GatunkiBox.TextChanged += new System.EventHandler(this.Box_TextChanged);
            // 
            // NrSciezkiLabel
            // 
            this.NrSciezkiLabel.AutoSize = true;
            this.NrSciezkiLabel.Location = new System.Drawing.Point(213, 351);
            this.NrSciezkiLabel.Name = "NrSciezkiLabel";
            this.NrSciezkiLabel.Size = new System.Drawing.Size(53, 13);
            this.NrSciezkiLabel.TabIndex = 26;
            this.NrSciezkiLabel.Text = "Nr ścieżki";
            // 
            // NrSciezkiBox
            // 
            this.NrSciezkiBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NrSciezkiBox.Location = new System.Drawing.Point(213, 367);
            this.NrSciezkiBox.Name = "NrSciezkiBox";
            this.NrSciezkiBox.Size = new System.Drawing.Size(398, 20);
            this.NrSciezkiBox.TabIndex = 25;
            this.NrSciezkiBox.TextChanged += new System.EventHandler(this.Box_TextChanged);
            // 
            // AktualizujButton
            // 
            this.AktualizujButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AktualizujButton.Enabled = false;
            this.AktualizujButton.Font = new System.Drawing.Font("Book Antiqua", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.AktualizujButton.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.AktualizujButton.Location = new System.Drawing.Point(395, 456);
            this.AktualizujButton.Name = "AktualizujButton";
            this.AktualizujButton.Size = new System.Drawing.Size(105, 35);
            this.AktualizujButton.TabIndex = 27;
            this.AktualizujButton.Text = "Aktualizuj";
            this.AktualizujButton.UseVisualStyleBackColor = false;
            this.AktualizujButton.Click += new System.EventHandler(this.AktualizujButton_Click);
            // 
            // PrzywrocDomyslneButton
            // 
            this.PrzywrocDomyslneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PrzywrocDomyslneButton.Enabled = false;
            this.PrzywrocDomyslneButton.Font = new System.Drawing.Font("Book Antiqua", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.PrzywrocDomyslneButton.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.PrzywrocDomyslneButton.Location = new System.Drawing.Point(284, 456);
            this.PrzywrocDomyslneButton.Name = "PrzywrocDomyslneButton";
            this.PrzywrocDomyslneButton.Size = new System.Drawing.Size(105, 35);
            this.PrzywrocDomyslneButton.TabIndex = 28;
            this.PrzywrocDomyslneButton.Text = "Przywróć domyślne";
            this.PrzywrocDomyslneButton.UseVisualStyleBackColor = false;
            this.PrzywrocDomyslneButton.Click += new System.EventHandler(this.PrzywrocDomyslneButton_Click);
            // 
            // ZamknijButton
            // 
            this.ZamknijButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ZamknijButton.Font = new System.Drawing.Font("Book Antiqua", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.ZamknijButton.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.ZamknijButton.Location = new System.Drawing.Point(12, 456);
            this.ZamknijButton.Name = "ZamknijButton";
            this.ZamknijButton.Size = new System.Drawing.Size(105, 35);
            this.ZamknijButton.TabIndex = 29;
            this.ZamknijButton.Text = "Zamknij";
            this.ZamknijButton.UseVisualStyleBackColor = false;
            this.ZamknijButton.Click += new System.EventHandler(this.ZamknijButton_Click);
            // 
            // OknoEdytujDane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::museSort.Properties.Resources.Blue_fractal_rework_by_elfy001;
            this.ClientSize = new System.Drawing.Size(634, 503);
            this.Controls.Add(this.ZamknijButton);
            this.Controls.Add(this.PrzywrocDomyslneButton);
            this.Controls.Add(this.AktualizujButton);
            this.Controls.Add(this.NrSciezkiLabel);
            this.Controls.Add(this.NrSciezkiBox);
            this.Controls.Add(this.GatunkiLabel);
            this.Controls.Add(this.GatunkiBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WykonawcaBox);
            this.Controls.Add(this.AlbumBox);
            this.Controls.Add(this.RokWydaniaBox);
            this.Controls.Add(this.TytulBox);
            this.Controls.Add(this.NazwaPlikuLabel);
            this.Controls.Add(this.NazwaPlikuBox);
            this.Controls.Add(this.otwoz_plik_button);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "OknoEdytujDane";
            this.Text = "Edytuj Dane";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OknoEdytujDane_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox WykonawcaBox;
        private System.Windows.Forms.TextBox AlbumBox;
        private System.Windows.Forms.TextBox RokWydaniaBox;
        private System.Windows.Forms.TextBox TytulBox;
        private System.Windows.Forms.Label NazwaPlikuLabel;
        private System.Windows.Forms.TextBox NazwaPlikuBox;
        private System.Windows.Forms.Button otwoz_plik_button;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label GatunkiLabel;
        private System.Windows.Forms.TextBox GatunkiBox;
        private System.Windows.Forms.Label NrSciezkiLabel;
        private System.Windows.Forms.TextBox NrSciezkiBox;
        private System.Windows.Forms.Button AktualizujButton;
        private System.Windows.Forms.Button PrzywrocDomyslneButton;
        private System.Windows.Forms.Button ZamknijButton;

    }
}