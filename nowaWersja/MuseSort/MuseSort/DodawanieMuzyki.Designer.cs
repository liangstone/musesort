namespace MuseSort
{
    partial class DodawanieMuzyki
    {
        //do ponownego merga
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.sciezkaButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.anulujButton = new System.Windows.Forms.Button();
            this.zapiszButton = new System.Windows.Forms.Button();
            this.wykonawcaTextBox = new System.Windows.Forms.TextBox();
            this.tytulTextBox = new System.Windows.Forms.TextBox();
            this.AlbumTextBox = new System.Windows.Forms.TextBox();
            this.rokTextBox = new System.Windows.Forms.TextBox();
            this.gatunekTextBox = new System.Windows.Forms.TextBox();
            this.explorer = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tw Cen MT Condensed", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(198, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(530, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dodawanie piosenki do Bazy Danych";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tw Cen MT Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(38, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 39);
            this.label2.TabIndex = 1;
            this.label2.Text = "Wykonawca:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tw Cen MT Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(38, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 39);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tytuł:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tw Cen MT Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(38, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 39);
            this.label4.TabIndex = 3;
            this.label4.Text = "Album:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tw Cen MT Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(38, 268);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 39);
            this.label5.TabIndex = 4;
            this.label5.Text = "Rok:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tw Cen MT Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(38, 340);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 39);
            this.label6.TabIndex = 5;
            this.label6.Text = "Gatunek:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tw Cen MT Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(38, 410);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 39);
            this.label7.TabIndex = 6;
            this.label7.Text = "Ścieżka:";
            // 
            // sciezkaButton
            // 
            this.sciezkaButton.BackColor = System.Drawing.Color.Blue;
            this.sciezkaButton.Font = new System.Drawing.Font("Tw Cen MT Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sciezkaButton.ForeColor = System.Drawing.Color.White;
            this.sciezkaButton.Location = new System.Drawing.Point(206, 425);
            this.sciezkaButton.Name = "sciezkaButton";
            this.sciezkaButton.Size = new System.Drawing.Size(100, 45);
            this.sciezkaButton.TabIndex = 7;
            this.sciezkaButton.Text = "...";
            this.sciezkaButton.UseVisualStyleBackColor = false;
            this.sciezkaButton.Click += new System.EventHandler(this.sciezkaButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.BackColor = System.Drawing.Color.Blue;
            this.updateButton.Font = new System.Drawing.Font("Tw Cen MT Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.updateButton.ForeColor = System.Drawing.Color.White;
            this.updateButton.Location = new System.Drawing.Point(426, 481);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(126, 45);
            this.updateButton.TabIndex = 8;
            this.updateButton.Text = "Zapisz zmiany";
            this.updateButton.UseVisualStyleBackColor = false;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // anulujButton
            // 
            this.anulujButton.BackColor = System.Drawing.Color.Red;
            this.anulujButton.Font = new System.Drawing.Font("Tw Cen MT Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.anulujButton.ForeColor = System.Drawing.Color.White;
            this.anulujButton.Location = new System.Drawing.Point(612, 481);
            this.anulujButton.Name = "anulujButton";
            this.anulujButton.Size = new System.Drawing.Size(100, 45);
            this.anulujButton.TabIndex = 9;
            this.anulujButton.Text = "Anuluj";
            this.anulujButton.UseVisualStyleBackColor = false;
            this.anulujButton.Click += new System.EventHandler(this.anulujButton_Click);
            // 
            // zapiszButton
            // 
            this.zapiszButton.BackColor = System.Drawing.Color.Blue;
            this.zapiszButton.Font = new System.Drawing.Font("Tw Cen MT Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.zapiszButton.ForeColor = System.Drawing.Color.White;
            this.zapiszButton.Location = new System.Drawing.Point(752, 481);
            this.zapiszButton.Name = "zapiszButton";
            this.zapiszButton.Size = new System.Drawing.Size(100, 45);
            this.zapiszButton.TabIndex = 10;
            this.zapiszButton.Text = "Zapisz";
            this.zapiszButton.UseVisualStyleBackColor = false;
            this.zapiszButton.Click += new System.EventHandler(this.zapiszButton_Click);
            // 
            // wykonawcaTextBox
            // 
            this.wykonawcaTextBox.Location = new System.Drawing.Point(210, 75);
            this.wykonawcaTextBox.Name = "wykonawcaTextBox";
            this.wykonawcaTextBox.Size = new System.Drawing.Size(496, 22);
            this.wykonawcaTextBox.TabIndex = 11;
            // 
            // tytulTextBox
            // 
            this.tytulTextBox.Location = new System.Drawing.Point(210, 132);
            this.tytulTextBox.Name = "tytulTextBox";
            this.tytulTextBox.Size = new System.Drawing.Size(496, 22);
            this.tytulTextBox.TabIndex = 12;
            // 
            // AlbumTextBox
            // 
            this.AlbumTextBox.Location = new System.Drawing.Point(210, 200);
            this.AlbumTextBox.Name = "AlbumTextBox";
            this.AlbumTextBox.Size = new System.Drawing.Size(496, 22);
            this.AlbumTextBox.TabIndex = 13;
            // 
            // rokTextBox
            // 
            this.rokTextBox.Location = new System.Drawing.Point(210, 268);
            this.rokTextBox.Name = "rokTextBox";
            this.rokTextBox.Size = new System.Drawing.Size(100, 22);
            this.rokTextBox.TabIndex = 14;
            // 
            // gatunekTextBox
            // 
            this.gatunekTextBox.Location = new System.Drawing.Point(206, 340);
            this.gatunekTextBox.Name = "gatunekTextBox";
            this.gatunekTextBox.Size = new System.Drawing.Size(500, 22);
            this.gatunekTextBox.TabIndex = 15;
            // 
            // DodawanieMuzyki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MuseSort.Properties.Resources.tlo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(927, 556);
            this.Controls.Add(this.gatunekTextBox);
            this.Controls.Add(this.rokTextBox);
            this.Controls.Add(this.AlbumTextBox);
            this.Controls.Add(this.tytulTextBox);
            this.Controls.Add(this.wykonawcaTextBox);
            this.Controls.Add(this.zapiszButton);
            this.Controls.Add(this.anulujButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.sciezkaButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DodawanieMuzyki";
            this.Text = "DodawanieMuzyki";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button sciezkaButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button anulujButton;
        private System.Windows.Forms.Button zapiszButton;
        private System.Windows.Forms.TextBox wykonawcaTextBox;
        private System.Windows.Forms.TextBox tytulTextBox;
        private System.Windows.Forms.TextBox AlbumTextBox;
        private System.Windows.Forms.TextBox rokTextBox;
        private System.Windows.Forms.TextBox gatunekTextBox;
        private System.Windows.Forms.OpenFileDialog explorer;
    }
}