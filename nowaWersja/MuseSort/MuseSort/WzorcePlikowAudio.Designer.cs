namespace MuseSort
{
    partial class WzorcePlikowAudio
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "String",
            "Regex"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "String",
            "Regex"}, -1);
            this.label1 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.usunButton = new System.Windows.Forms.Button();
            this.dodajButton = new System.Windows.Forms.Button();
            this.listaWzorcowNazwy = new System.Windows.Forms.ListView();
            this.wzorzecListViewName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.regexListViewName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listaWzorcowSciezki = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.usunNazwyButton = new System.Windows.Forms.Button();
            this.dodajNazwyButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(28, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(406, 31);
            this.label1.TabIndex = 9;
            this.label1.Text = "Lista wzorców nazwy plików audio:";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(744, 533);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(138, 36);
            this.closeButton.TabIndex = 8;
            this.closeButton.Text = "Zamknij";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // usunButton
            // 
            this.usunButton.Location = new System.Drawing.Point(591, 533);
            this.usunButton.Name = "usunButton";
            this.usunButton.Size = new System.Drawing.Size(136, 36);
            this.usunButton.TabIndex = 7;
            this.usunButton.Text = "Usun wzorzec";
            this.usunButton.UseVisualStyleBackColor = true;
            this.usunButton.Click += new System.EventHandler(this.usunButton_Click);
            // 
            // dodajButton
            // 
            this.dodajButton.Location = new System.Drawing.Point(443, 533);
            this.dodajButton.Name = "dodajButton";
            this.dodajButton.Size = new System.Drawing.Size(132, 36);
            this.dodajButton.TabIndex = 6;
            this.dodajButton.Text = "Dodaj wzorzec";
            this.dodajButton.UseVisualStyleBackColor = true;
            this.dodajButton.Click += new System.EventHandler(this.dodajButton_Click);
            // 
            // listaWzorcowNazwy
            // 
            this.listaWzorcowNazwy.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.wzorzecListViewName,
            this.regexListViewName});
            this.listaWzorcowNazwy.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listaWzorcowNazwy.Location = new System.Drawing.Point(28, 71);
            this.listaWzorcowNazwy.Name = "listaWzorcowNazwy";
            this.listaWzorcowNazwy.Size = new System.Drawing.Size(857, 170);
            this.listaWzorcowNazwy.TabIndex = 5;
            this.listaWzorcowNazwy.UseCompatibleStateImageBehavior = false;
            this.listaWzorcowNazwy.View = System.Windows.Forms.View.Details;
            // 
            // wzorzecListViewName
            // 
            this.wzorzecListViewName.Text = "Wzorzec";
            this.wzorzecListViewName.Width = 350;
            // 
            // regexListViewName
            // 
            this.regexListViewName.Text = "Regex wzorca";
            this.regexListViewName.Width = 500;
            // 
            // listaWzorcowSciezki
            // 
            this.listaWzorcowSciezki.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listaWzorcowSciezki.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.listaWzorcowSciezki.Location = new System.Drawing.Point(28, 357);
            this.listaWzorcowSciezki.Name = "listaWzorcowSciezki";
            this.listaWzorcowSciezki.Size = new System.Drawing.Size(854, 170);
            this.listaWzorcowSciezki.TabIndex = 10;
            this.listaWzorcowSciezki.UseCompatibleStateImageBehavior = false;
            this.listaWzorcowSciezki.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Wzorzec";
            this.columnHeader1.Width = 350;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Regex wzorca";
            this.columnHeader2.Width = 500;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(28, 311);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(409, 31);
            this.label2.TabIndex = 11;
            this.label2.Text = "Lista wzorców ścieżki plików audio:";
            // 
            // usunNazwyButton
            // 
            this.usunNazwyButton.Location = new System.Drawing.Point(746, 260);
            this.usunNazwyButton.Name = "usunNazwyButton";
            this.usunNazwyButton.Size = new System.Drawing.Size(136, 36);
            this.usunNazwyButton.TabIndex = 13;
            this.usunNazwyButton.Text = "Usun wzorzec";
            this.usunNazwyButton.UseVisualStyleBackColor = true;
            this.usunNazwyButton.Click += new System.EventHandler(this.usunNazwyButton_Click);
            // 
            // dodajNazwyButton
            // 
            this.dodajNazwyButton.Location = new System.Drawing.Point(598, 260);
            this.dodajNazwyButton.Name = "dodajNazwyButton";
            this.dodajNazwyButton.Size = new System.Drawing.Size(132, 36);
            this.dodajNazwyButton.TabIndex = 12;
            this.dodajNazwyButton.Text = "Dodaj wzorzec";
            this.dodajNazwyButton.UseVisualStyleBackColor = true;
            this.dodajNazwyButton.Click += new System.EventHandler(this.dodajNazwyButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // WzorcePlikowAudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MuseSort.Properties.Resources.tlo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(915, 582);
            this.Controls.Add(this.usunNazwyButton);
            this.Controls.Add(this.dodajNazwyButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listaWzorcowSciezki);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.usunButton);
            this.Controls.Add(this.dodajButton);
            this.Controls.Add(this.listaWzorcowNazwy);
            this.Name = "WzorcePlikowAudio";
            this.Text = "WzorcePlikowAudio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button usunButton;
        private System.Windows.Forms.Button dodajButton;
        private System.Windows.Forms.ListView listaWzorcowNazwy;
        private System.Windows.Forms.ColumnHeader wzorzecListViewName;
        private System.Windows.Forms.ColumnHeader regexListViewName;
        private System.Windows.Forms.ListView listaWzorcowSciezki;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button usunNazwyButton;
        private System.Windows.Forms.Button dodajNazwyButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}