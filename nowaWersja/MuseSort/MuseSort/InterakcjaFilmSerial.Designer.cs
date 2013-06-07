namespace MuseSort
{
    partial class InterakcjaFilmSerial
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
            this.filmyButton = new System.Windows.Forms.Button();
            this.serialeButton = new System.Windows.Forms.Button();
            this.anulujButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tw Cen MT", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(549, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dodać plik do bazy z filmami czy z serialami?";
            // 
            // filmyButton
            // 
            this.filmyButton.BackColor = System.Drawing.Color.Blue;
            this.filmyButton.Font = new System.Drawing.Font("Tw Cen MT Condensed", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.filmyButton.ForeColor = System.Drawing.Color.White;
            this.filmyButton.Location = new System.Drawing.Point(35, 165);
            this.filmyButton.Name = "filmyButton";
            this.filmyButton.Size = new System.Drawing.Size(99, 42);
            this.filmyButton.TabIndex = 1;
            this.filmyButton.Text = "z filmami";
            this.filmyButton.UseVisualStyleBackColor = false;
            this.filmyButton.Click += new System.EventHandler(this.filmyButton_Click);
            // 
            // serialeButton
            // 
            this.serialeButton.BackColor = System.Drawing.Color.Blue;
            this.serialeButton.Font = new System.Drawing.Font("Tw Cen MT Condensed", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.serialeButton.ForeColor = System.Drawing.Color.White;
            this.serialeButton.Location = new System.Drawing.Point(229, 165);
            this.serialeButton.Name = "serialeButton";
            this.serialeButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.serialeButton.Size = new System.Drawing.Size(99, 42);
            this.serialeButton.TabIndex = 2;
            this.serialeButton.Text = "z serialami";
            this.serialeButton.UseVisualStyleBackColor = false;
            this.serialeButton.Click += new System.EventHandler(this.serialeButton_Click);
            // 
            // anulujButton
            // 
            this.anulujButton.BackColor = System.Drawing.Color.Red;
            this.anulujButton.Font = new System.Drawing.Font("Tw Cen MT Condensed", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.anulujButton.ForeColor = System.Drawing.Color.White;
            this.anulujButton.Location = new System.Drawing.Point(429, 165);
            this.anulujButton.Name = "anulujButton";
            this.anulujButton.Size = new System.Drawing.Size(99, 42);
            this.anulujButton.TabIndex = 3;
            this.anulujButton.Text = "Anuluj";
            this.anulujButton.UseVisualStyleBackColor = false;
            this.anulujButton.Click += new System.EventHandler(this.anulujButton_Click);
            // 
            // InterakcjaFilmSerial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MuseSort.Properties.Resources.tlo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(587, 285);
            this.Controls.Add(this.anulujButton);
            this.Controls.Add(this.serialeButton);
            this.Controls.Add(this.filmyButton);
            this.Controls.Add(this.label1);
            this.Name = "InterakcjaFilmSerial";
            this.Text = "InterakcjaFilmSerial";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button filmyButton;
        private System.Windows.Forms.Button serialeButton;
        private System.Windows.Forms.Button anulujButton;
    }
}