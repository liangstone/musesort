namespace MuseSort
{
    partial class UtworzUstawienia
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
            this.label1 = new System.Windows.Forms.Label();
            this.infoLabel = new System.Windows.Forms.Label();
            this.sciezka = new System.Windows.Forms.TextBox();
            this.wyborSciezki = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.dalej = new System.Windows.Forms.Button();
            this.folderyPanel = new System.Windows.Forms.Panel();
            this.rozszerzeniaPanel = new System.Windows.Forms.Panel();
            this.flacCheckBox = new System.Windows.Forms.CheckBox();
            this.mp3CheckBox = new System.Windows.Forms.CheckBox();
            this.bazyDanychPanel = new System.Windows.Forms.Panel();
            this.bazyDanychListBox = new System.Windows.Forms.ListBox();
            this.sortowaniaPanel = new System.Windows.Forms.Panel();
            this.sortowaniaListBox = new System.Windows.Forms.ListBox();
            this.explorer = new System.Windows.Forms.FolderBrowserDialog();
            this.folderyPanel.SuspendLayout();
            this.rozszerzeniaPanel.SuspendLayout();
            this.bazyDanychPanel.SuspendLayout();
            this.sortowaniaPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(176, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Foldery programu";
            // 
            // infoLabel
            // 
            this.infoLabel.BackColor = System.Drawing.Color.Transparent;
            this.infoLabel.ForeColor = System.Drawing.Color.White;
            this.infoLabel.Location = new System.Drawing.Point(141, 68);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(252, 64);
            this.infoLabel.TabIndex = 4;
            this.infoLabel.Text = "Ustal główny folder programu, w którym będą przechowywane posortowane foldery";
            // 
            // sciezka
            // 
            this.sciezka.Location = new System.Drawing.Point(3, 15);
            this.sciezka.Name = "sciezka";
            this.sciezka.Size = new System.Drawing.Size(218, 22);
            this.sciezka.TabIndex = 5;
            // 
            // wyborSciezki
            // 
            this.wyborSciezki.Location = new System.Drawing.Point(251, 14);
            this.wyborSciezki.Name = "wyborSciezki";
            this.wyborSciezki.Size = new System.Drawing.Size(75, 23);
            this.wyborSciezki.TabIndex = 6;
            this.wyborSciezki.Text = "...";
            this.wyborSciezki.UseVisualStyleBackColor = true;
            this.wyborSciezki.Click += new System.EventHandler(this.wyborSciezki_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(40, 98);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(248, 21);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "użyj domyślnego folderu programu";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // dalej
            // 
            this.dalej.Location = new System.Drawing.Point(360, 342);
            this.dalej.Name = "dalej";
            this.dalej.Size = new System.Drawing.Size(75, 23);
            this.dalej.TabIndex = 8;
            this.dalej.Text = "Dalej";
            this.dalej.UseVisualStyleBackColor = true;
            // 
            // folderyPanel
            // 
            this.folderyPanel.BackColor = System.Drawing.Color.Transparent;
            this.folderyPanel.Controls.Add(this.sciezka);
            this.folderyPanel.Controls.Add(this.wyborSciezki);
            this.folderyPanel.Controls.Add(this.checkBox1);
            this.folderyPanel.Location = new System.Drawing.Point(49, 148);
            this.folderyPanel.Name = "folderyPanel";
            this.folderyPanel.Size = new System.Drawing.Size(363, 163);
            this.folderyPanel.TabIndex = 9;
            // 
            // rozszerzeniaPanel
            // 
            this.rozszerzeniaPanel.BackColor = System.Drawing.Color.Transparent;
            this.rozszerzeniaPanel.Controls.Add(this.flacCheckBox);
            this.rozszerzeniaPanel.Controls.Add(this.mp3CheckBox);
            this.rozszerzeniaPanel.Location = new System.Drawing.Point(12, 123);
            this.rozszerzeniaPanel.Name = "rozszerzeniaPanel";
            this.rozszerzeniaPanel.Size = new System.Drawing.Size(427, 213);
            this.rozszerzeniaPanel.TabIndex = 10;
            // 
            // flacCheckBox
            // 
            this.flacCheckBox.AutoSize = true;
            this.flacCheckBox.Location = new System.Drawing.Point(258, 69);
            this.flacCheckBox.Name = "flacCheckBox";
            this.flacCheckBox.Size = new System.Drawing.Size(61, 21);
            this.flacCheckBox.TabIndex = 1;
            this.flacCheckBox.Text = "*.flac";
            this.flacCheckBox.UseVisualStyleBackColor = true;
            // 
            // mp3CheckBox
            // 
            this.mp3CheckBox.AutoSize = true;
            this.mp3CheckBox.Location = new System.Drawing.Point(56, 69);
            this.mp3CheckBox.Name = "mp3CheckBox";
            this.mp3CheckBox.Size = new System.Drawing.Size(66, 21);
            this.mp3CheckBox.TabIndex = 0;
            this.mp3CheckBox.Text = "*.mp3\r\n";
            this.mp3CheckBox.UseVisualStyleBackColor = true;
            // 
            // bazyDanychPanel
            // 
            this.bazyDanychPanel.BackColor = System.Drawing.Color.Transparent;
            this.bazyDanychPanel.Controls.Add(this.bazyDanychListBox);
            this.bazyDanychPanel.Location = new System.Drawing.Point(12, 123);
            this.bazyDanychPanel.Name = "bazyDanychPanel";
            this.bazyDanychPanel.Size = new System.Drawing.Size(427, 213);
            this.bazyDanychPanel.TabIndex = 11;
            // 
            // bazyDanychListBox
            // 
            this.bazyDanychListBox.FormattingEnabled = true;
            this.bazyDanychListBox.ItemHeight = 16;
            this.bazyDanychListBox.Location = new System.Drawing.Point(77, 40);
            this.bazyDanychListBox.Name = "bazyDanychListBox";
            this.bazyDanychListBox.Size = new System.Drawing.Size(120, 84);
            this.bazyDanychListBox.TabIndex = 0;
            // 
            // sortowaniaPanel
            // 
            this.sortowaniaPanel.BackColor = System.Drawing.Color.Transparent;
            this.sortowaniaPanel.Controls.Add(this.sortowaniaListBox);
            this.sortowaniaPanel.Location = new System.Drawing.Point(26, 135);
            this.sortowaniaPanel.Name = "sortowaniaPanel";
            this.sortowaniaPanel.Size = new System.Drawing.Size(399, 193);
            this.sortowaniaPanel.TabIndex = 12;
            // 
            // sortowaniaListBox
            // 
            this.sortowaniaListBox.FormattingEnabled = true;
            this.sortowaniaListBox.ItemHeight = 16;
            this.sortowaniaListBox.Location = new System.Drawing.Point(42, 43);
            this.sortowaniaListBox.Name = "sortowaniaListBox";
            this.sortowaniaListBox.Size = new System.Drawing.Size(120, 84);
            this.sortowaniaListBox.TabIndex = 0;
            // 
            // UtworzUstawienia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MuseSort.Properties.Resources.tlo;
            this.ClientSize = new System.Drawing.Size(491, 400);
            this.Controls.Add(this.folderyPanel);
            this.Controls.Add(this.dalej);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sortowaniaPanel);
            this.Controls.Add(this.bazyDanychPanel);
            this.Controls.Add(this.rozszerzeniaPanel);
            this.Name = "UtworzUstawienia";
            this.Text = "UtworzUstawienia";
            this.folderyPanel.ResumeLayout(false);
            this.folderyPanel.PerformLayout();
            this.rozszerzeniaPanel.ResumeLayout(false);
            this.rozszerzeniaPanel.PerformLayout();
            this.bazyDanychPanel.ResumeLayout(false);
            this.sortowaniaPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.TextBox sciezka;
        private System.Windows.Forms.Button wyborSciezki;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button dalej;
        private System.Windows.Forms.Panel folderyPanel;
        private System.Windows.Forms.Panel rozszerzeniaPanel;
        private System.Windows.Forms.Panel bazyDanychPanel;
        private System.Windows.Forms.Panel sortowaniaPanel;
        private System.Windows.Forms.ListBox sortowaniaListBox;
        private System.Windows.Forms.CheckBox flacCheckBox;
        private System.Windows.Forms.CheckBox mp3CheckBox;
        private System.Windows.Forms.ListBox bazyDanychListBox;
        private System.Windows.Forms.FolderBrowserDialog explorer;
    }
}