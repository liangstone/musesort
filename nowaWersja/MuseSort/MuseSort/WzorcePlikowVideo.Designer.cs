namespace MuseSort
{
    partial class WzorcePlikowVideo
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
            this.listaWzorcow = new System.Windows.Forms.ListView();
            this.wzorzecListViewName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.regexListViewName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dodajButton = new System.Windows.Forms.Button();
            this.usunButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // listaWzorcow
            // 
            this.listaWzorcow.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.wzorzecListViewName,
            this.regexListViewName});
            this.listaWzorcow.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listaWzorcow.Location = new System.Drawing.Point(23, 60);
            this.listaWzorcow.Name = "listaWzorcow";
            this.listaWzorcow.Size = new System.Drawing.Size(857, 170);
            this.listaWzorcow.TabIndex = 0;
            this.listaWzorcow.UseCompatibleStateImageBehavior = false;
            this.listaWzorcow.View = System.Windows.Forms.View.Details;
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
            // dodajButton
            // 
            this.dodajButton.Location = new System.Drawing.Point(452, 257);
            this.dodajButton.Name = "dodajButton";
            this.dodajButton.Size = new System.Drawing.Size(132, 36);
            this.dodajButton.TabIndex = 1;
            this.dodajButton.Text = "Dodaj wzorzec";
            this.dodajButton.UseVisualStyleBackColor = true;
            this.dodajButton.Click += new System.EventHandler(this.dodajButton_Click);
            // 
            // usunButton
            // 
            this.usunButton.Location = new System.Drawing.Point(600, 257);
            this.usunButton.Name = "usunButton";
            this.usunButton.Size = new System.Drawing.Size(136, 36);
            this.usunButton.TabIndex = 2;
            this.usunButton.Text = "Usun wzorzec";
            this.usunButton.UseVisualStyleBackColor = true;
            this.usunButton.Click += new System.EventHandler(this.usunButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(753, 257);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(138, 36);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "Zamknij";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(23, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "Lista wzorców plików video:";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // WzorcePlikowVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MuseSort.Properties.Resources.tlo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(915, 323);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.usunButton);
            this.Controls.Add(this.dodajButton);
            this.Controls.Add(this.listaWzorcow);
            this.Name = "WzorcePlikowVideo";
            this.Text = "WzorcePlikowVideo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listaWzorcow;
        private System.Windows.Forms.ColumnHeader wzorzecListViewName;
        private System.Windows.Forms.ColumnHeader regexListViewName;
        private System.Windows.Forms.Button dodajButton;
        private System.Windows.Forms.Button usunButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;

    }
}