namespace MuseSort
{
    partial class EdycjaPliku
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
            this.tytulBox = new System.Windows.Forms.TextBox();
            this.rozszerzenieBox = new System.Windows.Forms.TextBox();
            this.wykonawcaBox = new System.Windows.Forms.TextBox();
            this.albumBox = new System.Windows.Forms.TextBox();
            this.rokWydaniaBox = new System.Windows.Forms.TextBox();
            this.gatunekBox = new System.Windows.Forms.TextBox();
            this.numerBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.zamknijButton = new System.Windows.Forms.Button();
            this.przwrocButton = new System.Windows.Forms.Button();
            this.zapiszButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tytuł: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Numer utwotu: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Gatunek: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Rok wydania: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Album: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Wykonawca: ";
            // 
            // tytulBox
            // 
            this.tytulBox.Location = new System.Drawing.Point(153, 31);
            this.tytulBox.Name = "tytulBox";
            this.tytulBox.Size = new System.Drawing.Size(211, 20);
            this.tytulBox.TabIndex = 6;
            this.tytulBox.TextChanged += new System.EventHandler(this.tytulTextChanged);
            // 
            // rozszerzenieBox
            // 
            this.rozszerzenieBox.Location = new System.Drawing.Point(396, 31);
            this.rozszerzenieBox.Name = "rozszerzenieBox";
            this.rozszerzenieBox.Size = new System.Drawing.Size(42, 20);
            this.rozszerzenieBox.TabIndex = 7;
            // 
            // wykonawcaBox
            // 
            this.wykonawcaBox.Location = new System.Drawing.Point(153, 58);
            this.wykonawcaBox.Name = "wykonawcaBox";
            this.wykonawcaBox.Size = new System.Drawing.Size(285, 20);
            this.wykonawcaBox.TabIndex = 8;
            this.wykonawcaBox.TextChanged += new System.EventHandler(this.wykonawcaTextChanged);
            // 
            // albumBox
            // 
            this.albumBox.Location = new System.Drawing.Point(153, 85);
            this.albumBox.Name = "albumBox";
            this.albumBox.Size = new System.Drawing.Size(285, 20);
            this.albumBox.TabIndex = 9;
            this.albumBox.TextChanged += new System.EventHandler(this.albumTextChanged);
            // 
            // rokWydaniaBox
            // 
            this.rokWydaniaBox.Location = new System.Drawing.Point(153, 112);
            this.rokWydaniaBox.Name = "rokWydaniaBox";
            this.rokWydaniaBox.Size = new System.Drawing.Size(285, 20);
            this.rokWydaniaBox.TabIndex = 10;
            this.rokWydaniaBox.TextChanged += new System.EventHandler(this.rokTextChanged);
            // 
            // gatunekBox
            // 
            this.gatunekBox.Location = new System.Drawing.Point(153, 139);
            this.gatunekBox.Name = "gatunekBox";
            this.gatunekBox.Size = new System.Drawing.Size(285, 20);
            this.gatunekBox.TabIndex = 11;
            this.gatunekBox.TextChanged += new System.EventHandler(this.gatunekTextChanged);
            // 
            // numerBox
            // 
            this.numerBox.Location = new System.Drawing.Point(153, 166);
            this.numerBox.Name = "numerBox";
            this.numerBox.Size = new System.Drawing.Size(285, 20);
            this.numerBox.TabIndex = 12;
            this.numerBox.TextChanged += new System.EventHandler(this.numerTextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(370, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = " . ";
            // 
            // zamknijButton
            // 
            this.zamknijButton.Location = new System.Drawing.Point(338, 234);
            this.zamknijButton.Name = "zamknijButton";
            this.zamknijButton.Size = new System.Drawing.Size(100, 28);
            this.zamknijButton.TabIndex = 14;
            this.zamknijButton.Text = "Zamknij";
            this.zamknijButton.UseVisualStyleBackColor = true;
            this.zamknijButton.Click += new System.EventHandler(this.zamknijClick);
            // 
            // przwrocButton
            // 
            this.przwrocButton.Location = new System.Drawing.Point(12, 234);
            this.przwrocButton.Name = "przwrocButton";
            this.przwrocButton.Size = new System.Drawing.Size(88, 28);
            this.przwrocButton.TabIndex = 15;
            this.przwrocButton.Text = "Przywróć";
            this.przwrocButton.UseVisualStyleBackColor = true;
            this.przwrocButton.Click += new System.EventHandler(this.przywrocClick);
            // 
            // zapiszButton
            // 
            this.zapiszButton.Location = new System.Drawing.Point(106, 234);
            this.zapiszButton.Name = "zapiszButton";
            this.zapiszButton.Size = new System.Drawing.Size(91, 28);
            this.zapiszButton.TabIndex = 16;
            this.zapiszButton.Text = "Zapisz";
            this.zapiszButton.UseVisualStyleBackColor = true;
            this.zapiszButton.Click += new System.EventHandler(this.zapiszClick);
            // 
            // EdycjaPliku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MuseSort.Properties.Resources.tlo;
            this.ClientSize = new System.Drawing.Size(450, 274);
            this.Controls.Add(this.zapiszButton);
            this.Controls.Add(this.przwrocButton);
            this.Controls.Add(this.zamknijButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numerBox);
            this.Controls.Add(this.gatunekBox);
            this.Controls.Add(this.rokWydaniaBox);
            this.Controls.Add(this.albumBox);
            this.Controls.Add(this.wykonawcaBox);
            this.Controls.Add(this.rozszerzenieBox);
            this.Controls.Add(this.tytulBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EdycjaPliku";
            this.Text = "EdycjaPliku";
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
        private System.Windows.Forms.TextBox tytulBox;
        private System.Windows.Forms.TextBox rozszerzenieBox;
        private System.Windows.Forms.TextBox wykonawcaBox;
        private System.Windows.Forms.TextBox albumBox;
        private System.Windows.Forms.TextBox rokWydaniaBox;
        private System.Windows.Forms.TextBox gatunekBox;
        private System.Windows.Forms.TextBox numerBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button zamknijButton;
        private System.Windows.Forms.Button przwrocButton;
        private System.Windows.Forms.Button zapiszButton;
    }
}