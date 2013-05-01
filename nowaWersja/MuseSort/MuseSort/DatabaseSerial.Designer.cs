namespace MuseSort
{
    partial class DatabaseSerial
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
            this.wrocButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // wrocButton
            // 
            this.wrocButton.BackColor = System.Drawing.Color.MediumBlue;
            this.wrocButton.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wrocButton.ForeColor = System.Drawing.Color.Transparent;
            this.wrocButton.Location = new System.Drawing.Point(802, 12);
            this.wrocButton.Name = "wrocButton";
            this.wrocButton.Size = new System.Drawing.Size(177, 61);
            this.wrocButton.TabIndex = 1;
            this.wrocButton.Text = "Wróć do biblioteki";
            this.wrocButton.UseVisualStyleBackColor = false;
            this.wrocButton.Click += new System.EventHandler(this.wrocButton_Click);
            // 
            // DatabaseSerial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MuseSort.Properties.Resources.tlo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(991, 520);
            this.Controls.Add(this.wrocButton);
            this.Name = "DatabaseSerial";
            this.Text = "Twoje Seriale";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button wrocButton;
    }
}