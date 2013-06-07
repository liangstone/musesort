namespace MuseSort
{
    partial class DatabaseStart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseStart));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.muzykaButton = new System.Windows.Forms.Button();
            this.filmyButton = new System.Windows.Forms.Button();
            this.serialeButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Perpetua Titling MT", 25.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(209, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(481, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "Twoja Biblioteka";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(752, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 258);
            this.label2.TabIndex = 1;
            // 
            // muzykaButton
            // 
            this.muzykaButton.BackColor = System.Drawing.Color.MediumBlue;
            this.muzykaButton.Font = new System.Drawing.Font("Perpetua Titling MT", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.muzykaButton.ForeColor = System.Drawing.Color.Transparent;
            this.muzykaButton.Location = new System.Drawing.Point(71, 206);
            this.muzykaButton.Name = "muzykaButton";
            this.muzykaButton.Size = new System.Drawing.Size(195, 101);
            this.muzykaButton.TabIndex = 2;
            this.muzykaButton.Text = "Twoja Muzyka";
            this.muzykaButton.UseVisualStyleBackColor = false;
            this.muzykaButton.Click += new System.EventHandler(this.muzykaButton_Click);
            // 
            // filmyButton
            // 
            this.filmyButton.BackColor = System.Drawing.Color.MediumBlue;
            this.filmyButton.Font = new System.Drawing.Font("Perpetua Titling MT", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filmyButton.ForeColor = System.Drawing.Color.Transparent;
            this.filmyButton.Location = new System.Drawing.Point(313, 206);
            this.filmyButton.Name = "filmyButton";
            this.filmyButton.Size = new System.Drawing.Size(189, 101);
            this.filmyButton.TabIndex = 3;
            this.filmyButton.Text = "Twoje Filmy";
            this.filmyButton.UseVisualStyleBackColor = false;
            this.filmyButton.Click += new System.EventHandler(this.filmyButton_Click);
            // 
            // serialeButton
            // 
            this.serialeButton.BackColor = System.Drawing.Color.MediumBlue;
            this.serialeButton.Font = new System.Drawing.Font("Perpetua Titling MT", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialeButton.ForeColor = System.Drawing.Color.Transparent;
            this.serialeButton.Location = new System.Drawing.Point(555, 206);
            this.serialeButton.Name = "serialeButton";
            this.serialeButton.Size = new System.Drawing.Size(166, 101);
            this.serialeButton.TabIndex = 4;
            this.serialeButton.Text = "Twoje Seriale";
            this.serialeButton.UseVisualStyleBackColor = false;
            this.serialeButton.Click += new System.EventHandler(this.serialeButton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumTurquoise;
            this.button1.Font = new System.Drawing.Font("Perpetua Titling MT", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(768, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 58);
            this.button1.TabIndex = 5;
            this.button1.Text = "Zamknij";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DatabaseStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MuseSort.Properties.Resources.tlo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(977, 441);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.serialeButton);
            this.Controls.Add(this.filmyButton);
            this.Controls.Add(this.muzykaButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DatabaseStart";
            this.Text = "Twoja Biblioteka";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button muzykaButton;
        private System.Windows.Forms.Button filmyButton;
        private System.Windows.Forms.Button serialeButton;
        private System.Windows.Forms.Button button1;
    }
}