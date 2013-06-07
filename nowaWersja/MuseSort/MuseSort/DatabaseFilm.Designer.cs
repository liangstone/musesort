namespace MuseSort
{
    partial class DatabaseFilm
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
            this.wrocButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.filmyButton = new System.Windows.Forms.Button();
            this.gatunkiButton = new System.Windows.Forms.Button();
            this.produkcjaButton = new System.Windows.Forms.Button();
            this.rokButton = new System.Windows.Forms.Button();
            this.filmyPanel = new System.Windows.Forms.Panel();
            this.tabela = new System.Windows.Forms.DataGridView();
            this.usunButton = new System.Windows.Forms.Button();
            this.dodajButton = new System.Windows.Forms.Button();
            this.edytujButton = new System.Windows.Forms.Button();
            this.filmyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabela)).BeginInit();
            this.SuspendLayout();
            // 
            // wrocButton
            // 
            this.wrocButton.BackColor = System.Drawing.Color.MediumBlue;
            this.wrocButton.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wrocButton.ForeColor = System.Drawing.Color.Transparent;
            this.wrocButton.Location = new System.Drawing.Point(809, 12);
            this.wrocButton.Name = "wrocButton";
            this.wrocButton.Size = new System.Drawing.Size(177, 61);
            this.wrocButton.TabIndex = 1;
            this.wrocButton.Text = "Wróć do biblioteki";
            this.wrocButton.UseVisualStyleBackColor = false;
            this.wrocButton.Click += new System.EventHandler(this.wrocButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Perpetua Titling MT", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "Twoje Filmy";
            // 
            // filmyButton
            // 
            this.filmyButton.BackColor = System.Drawing.Color.Blue;
            this.filmyButton.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filmyButton.ForeColor = System.Drawing.Color.Transparent;
            this.filmyButton.Location = new System.Drawing.Point(54, 78);
            this.filmyButton.Name = "filmyButton";
            this.filmyButton.Size = new System.Drawing.Size(152, 41);
            this.filmyButton.TabIndex = 3;
            this.filmyButton.Text = "Filmy";
            this.filmyButton.UseVisualStyleBackColor = false;
            this.filmyButton.Click += new System.EventHandler(this.filmyButton_Click);
            // 
            // gatunkiButton
            // 
            this.gatunkiButton.BackColor = System.Drawing.Color.Blue;
            this.gatunkiButton.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gatunkiButton.ForeColor = System.Drawing.Color.Transparent;
            this.gatunkiButton.Location = new System.Drawing.Point(228, 78);
            this.gatunkiButton.Name = "gatunkiButton";
            this.gatunkiButton.Size = new System.Drawing.Size(152, 41);
            this.gatunkiButton.TabIndex = 4;
            this.gatunkiButton.Text = "Gatunki";
            this.gatunkiButton.UseVisualStyleBackColor = false;
            this.gatunkiButton.Click += new System.EventHandler(this.gatunkiButton_Click);
            // 
            // produkcjaButton
            // 
            this.produkcjaButton.BackColor = System.Drawing.Color.Blue;
            this.produkcjaButton.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.produkcjaButton.ForeColor = System.Drawing.Color.Transparent;
            this.produkcjaButton.Location = new System.Drawing.Point(415, 78);
            this.produkcjaButton.Name = "produkcjaButton";
            this.produkcjaButton.Size = new System.Drawing.Size(152, 41);
            this.produkcjaButton.TabIndex = 5;
            this.produkcjaButton.Text = "Produkcja";
            this.produkcjaButton.UseVisualStyleBackColor = false;
            this.produkcjaButton.Click += new System.EventHandler(this.produkcjaButton_Click);
            // 
            // rokButton
            // 
            this.rokButton.BackColor = System.Drawing.Color.Blue;
            this.rokButton.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rokButton.ForeColor = System.Drawing.Color.Transparent;
            this.rokButton.Location = new System.Drawing.Point(595, 78);
            this.rokButton.Name = "rokButton";
            this.rokButton.Size = new System.Drawing.Size(152, 41);
            this.rokButton.TabIndex = 6;
            this.rokButton.Text = "Rok";
            this.rokButton.UseVisualStyleBackColor = false;
            this.rokButton.Click += new System.EventHandler(this.rokButton_Click);
            // 
            // filmyPanel
            // 
            this.filmyPanel.BackColor = System.Drawing.Color.Transparent;
            this.filmyPanel.Controls.Add(this.tabela);
            this.filmyPanel.Location = new System.Drawing.Point(12, 125);
            this.filmyPanel.Name = "filmyPanel";
            this.filmyPanel.Size = new System.Drawing.Size(836, 392);
            this.filmyPanel.TabIndex = 7;
            // 
            // tabela
            // 
            this.tabela.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tabela.BackgroundColor = System.Drawing.SystemColors.MenuHighlight;
            this.tabela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabela.GridColor = System.Drawing.SystemColors.Highlight;
            this.tabela.Location = new System.Drawing.Point(10, 3);
            this.tabela.Name = "tabela";
            this.tabela.RowTemplate.Height = 24;
            this.tabela.Size = new System.Drawing.Size(806, 386);
            this.tabela.TabIndex = 1;
            // 
            // usunButton
            // 
            this.usunButton.BackColor = System.Drawing.Color.MediumBlue;
            this.usunButton.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.usunButton.ForeColor = System.Drawing.Color.Snow;
            this.usunButton.Location = new System.Drawing.Point(854, 183);
            this.usunButton.Name = "usunButton";
            this.usunButton.Size = new System.Drawing.Size(121, 48);
            this.usunButton.TabIndex = 8;
            this.usunButton.Text = "USUŃ";
            this.usunButton.UseVisualStyleBackColor = false;
            this.usunButton.Click += new System.EventHandler(this.usunButton_Click);
            // 
            // dodajButton
            // 
            this.dodajButton.BackColor = System.Drawing.Color.MediumBlue;
            this.dodajButton.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.dodajButton.ForeColor = System.Drawing.Color.Snow;
            this.dodajButton.Location = new System.Drawing.Point(854, 252);
            this.dodajButton.Name = "dodajButton";
            this.dodajButton.Size = new System.Drawing.Size(121, 48);
            this.dodajButton.TabIndex = 9;
            this.dodajButton.Text = "DODAJ";
            this.dodajButton.UseVisualStyleBackColor = false;
            this.dodajButton.Click += new System.EventHandler(this.dodajButton_Click);
            // 
            // edytujButton
            // 
            this.edytujButton.BackColor = System.Drawing.Color.MediumBlue;
            this.edytujButton.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.edytujButton.ForeColor = System.Drawing.Color.White;
            this.edytujButton.Location = new System.Drawing.Point(855, 317);
            this.edytujButton.Name = "edytujButton";
            this.edytujButton.Size = new System.Drawing.Size(120, 41);
            this.edytujButton.TabIndex = 10;
            this.edytujButton.Text = "Edytuj";
            this.edytujButton.UseVisualStyleBackColor = false;
            this.edytujButton.Click += new System.EventHandler(this.edytujButton_Click);
            // 
            // DatabaseFilm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MuseSort.Properties.Resources.tlo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(987, 514);
            this.Controls.Add(this.edytujButton);
            this.Controls.Add(this.dodajButton);
            this.Controls.Add(this.usunButton);
            this.Controls.Add(this.filmyPanel);
            this.Controls.Add(this.rokButton);
            this.Controls.Add(this.produkcjaButton);
            this.Controls.Add(this.gatunkiButton);
            this.Controls.Add(this.filmyButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.wrocButton);
            this.Name = "DatabaseFilm";
            this.Text = "Twoje Filmy";
            this.filmyPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabela)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button wrocButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button filmyButton;
        private System.Windows.Forms.Button gatunkiButton;
        private System.Windows.Forms.Button produkcjaButton;
        private System.Windows.Forms.Button rokButton;
        private System.Windows.Forms.Panel filmyPanel;
        private System.Windows.Forms.DataGridView tabela;
        private System.Windows.Forms.Button usunButton;
        private System.Windows.Forms.Button dodajButton;
        private System.Windows.Forms.Button edytujButton;
    }
}