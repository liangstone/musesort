namespace MuseSort
{
    partial class DatabaseMuzyka
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.gatunkiButton = new System.Windows.Forms.Button();
            this.wykonawcyButton = new System.Windows.Forms.Button();
            this.dodajButton = new System.Windows.Forms.Button();
            this.usunButton = new System.Windows.Forms.Button();
            this.muzykaPanel = new System.Windows.Forms.Panel();
            this.tabela = new System.Windows.Forms.DataGridView();
            this.explorer = new System.Windows.Forms.OpenFileDialog();
            this.edytujButton = new System.Windows.Forms.Button();
            this.muzykaPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabela)).BeginInit();
            this.SuspendLayout();
            // 
            // wrocButton
            // 
            this.wrocButton.BackColor = System.Drawing.Color.MediumBlue;
            this.wrocButton.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wrocButton.ForeColor = System.Drawing.Color.Transparent;
            this.wrocButton.Location = new System.Drawing.Point(773, 12);
            this.wrocButton.Name = "wrocButton";
            this.wrocButton.Size = new System.Drawing.Size(177, 61);
            this.wrocButton.TabIndex = 0;
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
            this.label1.Location = new System.Drawing.Point(25, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Twoja Muzyka";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumBlue;
            this.button1.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(101, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 54);
            this.button1.TabIndex = 2;
            this.button1.Text = "Piosenki";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gatunkiButton
            // 
            this.gatunkiButton.BackColor = System.Drawing.Color.MediumBlue;
            this.gatunkiButton.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gatunkiButton.ForeColor = System.Drawing.Color.White;
            this.gatunkiButton.Location = new System.Drawing.Point(291, 103);
            this.gatunkiButton.Name = "gatunkiButton";
            this.gatunkiButton.Size = new System.Drawing.Size(154, 54);
            this.gatunkiButton.TabIndex = 3;
            this.gatunkiButton.Text = "Gatunki";
            this.gatunkiButton.UseVisualStyleBackColor = false;
            this.gatunkiButton.Click += new System.EventHandler(this.gatunkiButton_Click);
            // 
            // wykonawcyButton
            // 
            this.wykonawcyButton.BackColor = System.Drawing.Color.MediumBlue;
            this.wykonawcyButton.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wykonawcyButton.ForeColor = System.Drawing.Color.White;
            this.wykonawcyButton.Location = new System.Drawing.Point(471, 103);
            this.wykonawcyButton.Name = "wykonawcyButton";
            this.wykonawcyButton.Size = new System.Drawing.Size(185, 54);
            this.wykonawcyButton.TabIndex = 4;
            this.wykonawcyButton.Text = "Wykonawcy";
            this.wykonawcyButton.UseVisualStyleBackColor = false;
            this.wykonawcyButton.Click += new System.EventHandler(this.wykonawcyButton_Click);
            // 
            // dodajButton
            // 
            this.dodajButton.BackColor = System.Drawing.Color.MediumBlue;
            this.dodajButton.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.dodajButton.ForeColor = System.Drawing.Color.Snow;
            this.dodajButton.Location = new System.Drawing.Point(820, 277);
            this.dodajButton.Name = "dodajButton";
            this.dodajButton.Size = new System.Drawing.Size(121, 48);
            this.dodajButton.TabIndex = 11;
            this.dodajButton.Text = "DODAJ";
            this.dodajButton.UseVisualStyleBackColor = false;
            this.dodajButton.Click += new System.EventHandler(this.dodajButton_Click);
            // 
            // usunButton
            // 
            this.usunButton.BackColor = System.Drawing.Color.MediumBlue;
            this.usunButton.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.usunButton.ForeColor = System.Drawing.Color.Snow;
            this.usunButton.Location = new System.Drawing.Point(820, 205);
            this.usunButton.Name = "usunButton";
            this.usunButton.Size = new System.Drawing.Size(121, 48);
            this.usunButton.TabIndex = 10;
            this.usunButton.Text = "USUŃ";
            this.usunButton.UseVisualStyleBackColor = false;
            this.usunButton.Click += new System.EventHandler(this.usunButton_Click);
            // 
            // muzykaPanel
            // 
            this.muzykaPanel.BackColor = System.Drawing.Color.Transparent;
            this.muzykaPanel.Controls.Add(this.tabela);
            this.muzykaPanel.Location = new System.Drawing.Point(22, 193);
            this.muzykaPanel.Name = "muzykaPanel";
            this.muzykaPanel.Size = new System.Drawing.Size(764, 336);
            this.muzykaPanel.TabIndex = 12;
            // 
            // tabela
            // 
            this.tabela.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tabela.BackgroundColor = System.Drawing.SystemColors.MenuHighlight;
            this.tabela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabela.GridColor = System.Drawing.SystemColors.MenuHighlight;
            this.tabela.Location = new System.Drawing.Point(3, 3);
            this.tabela.Name = "tabela";
            this.tabela.RowTemplate.Height = 24;
            this.tabela.Size = new System.Drawing.Size(747, 330);
            this.tabela.TabIndex = 1;
            // 
            // edytujButton
            // 
            this.edytujButton.BackColor = System.Drawing.Color.MediumBlue;
            this.edytujButton.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.edytujButton.ForeColor = System.Drawing.Color.White;
            this.edytujButton.Location = new System.Drawing.Point(820, 344);
            this.edytujButton.Name = "edytujButton";
            this.edytujButton.Size = new System.Drawing.Size(121, 43);
            this.edytujButton.TabIndex = 13;
            this.edytujButton.Text = "Edytuj";
            this.edytujButton.UseVisualStyleBackColor = false;
            this.edytujButton.Click += new System.EventHandler(this.edytujButton_Click);
            // 
            // DatabaseMuzyka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MuseSort.Properties.Resources.tlo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(953, 541);
            this.Controls.Add(this.edytujButton);
            this.Controls.Add(this.muzykaPanel);
            this.Controls.Add(this.dodajButton);
            this.Controls.Add(this.usunButton);
            this.Controls.Add(this.wykonawcyButton);
            this.Controls.Add(this.gatunkiButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.wrocButton);
            this.Name = "DatabaseMuzyka";
            this.Text = "Twoja Muzyka";
            this.muzykaPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabela)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button wrocButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button gatunkiButton;
        private System.Windows.Forms.Button wykonawcyButton;
        private System.Windows.Forms.Button dodajButton;
        private System.Windows.Forms.Button usunButton;
        private System.Windows.Forms.Panel muzykaPanel;
        private System.Windows.Forms.DataGridView tabela;
        private System.Windows.Forms.OpenFileDialog explorer;
        private System.Windows.Forms.Button edytujButton;
    }
}