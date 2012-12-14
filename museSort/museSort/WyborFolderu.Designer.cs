namespace museSort
{
    partial class WyborFolderu
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
            this.sciezka_box = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.wybor_folderu_button = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.zamknij_button = new System.Windows.Forms.Button();
            this.wykonaj_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lista_plikow_box = new System.Windows.Forms.ListBox();
            this.schemat_box = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.format_box = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.progress_bar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // sciezka_box
            // 
            this.sciezka_box.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sciezka_box.Location = new System.Drawing.Point(69, 284);
            this.sciezka_box.Name = "sciezka_box";
            this.sciezka_box.Size = new System.Drawing.Size(334, 20);
            this.sciezka_box.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::museSort.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(198, 233);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // wybor_folderu_button
            // 
            this.wybor_folderu_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.wybor_folderu_button.Font = new System.Drawing.Font("Book Antiqua", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.wybor_folderu_button.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.wybor_folderu_button.Location = new System.Drawing.Point(414, 280);
            this.wybor_folderu_button.Name = "wybor_folderu_button";
            this.wybor_folderu_button.Size = new System.Drawing.Size(83, 24);
            this.wybor_folderu_button.TabIndex = 2;
            this.wybor_folderu_button.Text = "Wyszukaj";
            this.wybor_folderu_button.UseVisualStyleBackColor = true;
            this.wybor_folderu_button.Click += new System.EventHandler(this.wyszukaj_Click);
            // 
            // zamknij_button
            // 
            this.zamknij_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.zamknij_button.Font = new System.Drawing.Font("Book Antiqua", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.zamknij_button.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.zamknij_button.Location = new System.Drawing.Point(12, 363);
            this.zamknij_button.Name = "zamknij_button";
            this.zamknij_button.Size = new System.Drawing.Size(123, 30);
            this.zamknij_button.TabIndex = 4;
            this.zamknij_button.Text = "Zamknij";
            this.zamknij_button.UseVisualStyleBackColor = true;
            this.zamknij_button.Click += new System.EventHandler(this.zamknij_button_Click);
            // 
            // wykonaj_button
            // 
            this.wykonaj_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.wykonaj_button.Font = new System.Drawing.Font("Book Antiqua", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.wykonaj_button.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.wykonaj_button.Location = new System.Drawing.Point(371, 363);
            this.wykonaj_button.Name = "wykonaj_button";
            this.wykonaj_button.Size = new System.Drawing.Size(128, 30);
            this.wykonaj_button.TabIndex = 5;
            this.wykonaj_button.Text = "Wykonaj";
            this.wykonaj_button.UseVisualStyleBackColor = true;
            this.wykonaj_button.Click += new System.EventHandler(this.wykonaj_button_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(7, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ścieżka: ";
            // 
            // lista_plikow_box
            // 
            this.lista_plikow_box.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lista_plikow_box.FormattingEnabled = true;
            this.lista_plikow_box.Location = new System.Drawing.Point(216, 12);
            this.lista_plikow_box.Name = "lista_plikow_box";
            this.lista_plikow_box.Size = new System.Drawing.Size(283, 264);
            this.lista_plikow_box.TabIndex = 8;
            // 
            // schemat_box
            // 
            this.schemat_box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.schemat_box.FormattingEnabled = true;
            this.schemat_box.Items.AddRange(new object[] {
            "Wykonawca\\Album\\Piosenki",
            "Wykonawca\\Rok\\Album\\Piosenki",
            "Gatunek\\Wykonawca\\Album\\Piosenki",
            "Gatunek\\Wykonawca\\Piosenki",
            "Rok\\Gatunek\\Wykonawca\\Album\\Piosenki",
            "Rok\\Wykonawca\\Album\\Piosenki",
            "Piosenki\\Alfabetycznie",
            "Piosenki\\Wykonawca"});
            this.schemat_box.Location = new System.Drawing.Point(111, 320);
            this.schemat_box.Name = "schemat_box";
            this.schemat_box.Size = new System.Drawing.Size(235, 21);
            this.schemat_box.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(7, 326);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Schemat zapisu:";
            // 
            // format_box
            // 
            this.format_box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.format_box.FormattingEnabled = true;
            this.format_box.Items.AddRange(new object[] {
            "Najlepszy",
            "MP3",
            "FLAC"});
            this.format_box.Location = new System.Drawing.Point(407, 320);
            this.format_box.Name = "format_box";
            this.format_box.Size = new System.Drawing.Size(89, 21);
            this.format_box.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.Location = new System.Drawing.Point(352, 326);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Format:";
            // 
            // progress_bar
            // 
            this.progress_bar.Enabled = false;
            this.progress_bar.Location = new System.Drawing.Point(13, 252);
            this.progress_bar.Name = "progress_bar";
            this.progress_bar.Size = new System.Drawing.Size(197, 23);
            this.progress_bar.TabIndex = 13;
            // 
            // WyborFolderu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::museSort.Properties.Resources.tlo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(509, 403);
            this.Controls.Add(this.progress_bar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.format_box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.schemat_box);
            this.Controls.Add(this.lista_plikow_box);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.wykonaj_button);
            this.Controls.Add(this.zamknij_button);
            this.Controls.Add(this.wybor_folderu_button);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.sciezka_box);
            this.MinimumSize = new System.Drawing.Size(525, 441);
            this.Name = "WyborFolderu";
            this.Text = "WyborFolderuPoczatkowego";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sciezka_box;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button wybor_folderu_button;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button zamknij_button;
        private System.Windows.Forms.Button wykonaj_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lista_plikow_box;
        private System.Windows.Forms.ComboBox schemat_box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox format_box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progress_bar;
    }
}