namespace MuseSort
{
    partial class MainGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGUI));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zamknijToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opcjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ustawieniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drzewoFolderow = new System.Windows.Forms.TreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.modyfikujButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dodajDoGlownegoFolderuButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dodajPiosenkiButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.sortujButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.aktualnyFolder = new System.Windows.Forms.ListView();
            this.nazwa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rozszerzenie = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rozmiar = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dodajPanel = new System.Windows.Forms.Panel();
            this.dodajButton = new System.Windows.Forms.Button();
            this.ustalDestinationButton = new System.Windows.Forms.Button();
            this.ustalSourceButton = new System.Windows.Forms.Button();
            this.destinationFolderTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sourceFolderTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sortujCustom = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.dodajPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Highlight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItem,
            this.opcjeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(988, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zamknijToolStripMenuItem});
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.programToolStripMenuItem.Text = "Program";
            // 
            // zamknijToolStripMenuItem
            // 
            this.zamknijToolStripMenuItem.Name = "zamknijToolStripMenuItem";
            this.zamknijToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.zamknijToolStripMenuItem.Text = "Zamknij";
            this.zamknijToolStripMenuItem.Click += new System.EventHandler(this.zamknijToolStripMenuItem_Click);
            // 
            // opcjeToolStripMenuItem
            // 
            this.opcjeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ustawieniaToolStripMenuItem});
            this.opcjeToolStripMenuItem.Name = "opcjeToolStripMenuItem";
            this.opcjeToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.opcjeToolStripMenuItem.Text = "Opcje";
            // 
            // ustawieniaToolStripMenuItem
            // 
            this.ustawieniaToolStripMenuItem.Name = "ustawieniaToolStripMenuItem";
            this.ustawieniaToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.ustawieniaToolStripMenuItem.Text = "Ustawienia";
            this.ustawieniaToolStripMenuItem.Click += new System.EventHandler(this.ustawieniaToolStripMenuItem_Click);
            // 
            // drzewoFolderow
            // 
            this.drzewoFolderow.Location = new System.Drawing.Point(12, 63);
            this.drzewoFolderow.Name = "drzewoFolderow";
            this.drzewoFolderow.Size = new System.Drawing.Size(233, 396);
            this.drzewoFolderow.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modyfikujButton,
            this.toolStripSeparator1,
            this.dodajDoGlownegoFolderuButton,
            this.toolStripSeparator2,
            this.dodajPiosenkiButton,
            this.toolStripSeparator3,
            this.toolStripButton5,
            this.sortujCustom});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1319, 32);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // modyfikujButton
            // 
            this.modyfikujButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.modyfikujButton.Image = ((System.Drawing.Image)(resources.GetObject("modyfikujButton.Image")));
            this.modyfikujButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.modyfikujButton.Name = "modyfikujButton";
            this.modyfikujButton.Size = new System.Drawing.Size(29, 29);
            this.modyfikujButton.Text = "Modyfikuj tagi";
            this.modyfikujButton.Click += new System.EventHandler(this.modyfikujButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // dodajDoGlownegoFolderuButton
            // 
            this.dodajDoGlownegoFolderuButton.BackColor = System.Drawing.Color.Transparent;
            this.dodajDoGlownegoFolderuButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dodajDoGlownegoFolderuButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dodajDoGlownegoFolderuButton.Image = ((System.Drawing.Image)(resources.GetObject("dodajDoGlownegoFolderuButton.Image")));
            this.dodajDoGlownegoFolderuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dodajDoGlownegoFolderuButton.Name = "dodajDoGlownegoFolderuButton";
            this.dodajDoGlownegoFolderuButton.Size = new System.Drawing.Size(29, 29);
            this.dodajDoGlownegoFolderuButton.Text = "Dodaj do głównego folderu";
            this.dodajDoGlownegoFolderuButton.Click += new System.EventHandler(this.dodajDoGlownegoFolderuButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // dodajPiosenkiButton
            // 
            this.dodajPiosenkiButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dodajPiosenkiButton.Image = ((System.Drawing.Image)(resources.GetObject("dodajPiosenkiButton.Image")));
            this.dodajPiosenkiButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dodajPiosenkiButton.Name = "dodajPiosenkiButton";
            this.dodajPiosenkiButton.Size = new System.Drawing.Size(29, 29);
            this.dodajPiosenkiButton.Text = "Dodaj piosenki";
            this.dodajPiosenkiButton.Click += new System.EventHandler(this.dodajPiosenkiButton_Click);
            //this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            //this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            //this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            //this.toolStripButton3.Name = "toolStripButton3";
            //this.toolStripButton3.Size = new System.Drawing.Size(29, 29);
            //this.toolStripButton3.Text = "Dodaj piosenki";
            //this.toolStripButton3.Click += new System.EventHandler(this.dodajPiosenkiButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 32);
            // 
            // sortujButton
            // 
            this.sortujButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.sortujButton.Image = ((System.Drawing.Image)(resources.GetObject("sortujButton.Image")));
            this.sortujButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sortujButton.Name = "sortujButton";
            this.sortujButton.Size = new System.Drawing.Size(29, 29);
            this.sortujButton.Text = "Sortuj";
            this.sortujButton.Click += new System.EventHandler(this.sortujButton_Click);
            //this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            //this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            //this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            //this.toolStripButton5.Name = "toolStripButton5";
            //this.toolStripButton5.Size = new System.Drawing.Size(29, 29);
            //this.toolStripButton5.Text = "Sortuj";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 603);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(988, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(132, 17);
            this.toolStripStatusLabel1.Text = "Wykonywanie operacji: ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(13, 17);
            this.toolStripStatusLabel2.Text = "  ";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(300, 16);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MuseSort.Properties.Resources.logo1;
            this.pictureBox1.InitialImage = global::MuseSort.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(783, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(194, 219);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // aktualnyFolder
            // 
            this.aktualnyFolder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nazwa,
            this.rozszerzenie,
            this.rozmiar});
            this.aktualnyFolder.Location = new System.Drawing.Point(260, 63);
            this.aktualnyFolder.Name = "aktualnyFolder";
            this.aktualnyFolder.Size = new System.Drawing.Size(507, 396);
            this.aktualnyFolder.TabIndex = 5;
            this.aktualnyFolder.UseCompatibleStateImageBehavior = false;
            this.aktualnyFolder.View = System.Windows.Forms.View.Details;
            // 
            // nazwa
            // 
            this.nazwa.Text = "Nazwa";
            this.nazwa.Width = 329;
            // 
            // rozszerzenie
            // 
            this.rozszerzenie.Text = "Rozszerzenie";
            this.rozszerzenie.Width = 92;
            // 
            // rozmiar
            // 
            this.rozmiar.Text = "Rozmiar";
            this.rozmiar.Width = 81;
            // 
            // dodajPanel
            // 
            this.dodajPanel.BackColor = System.Drawing.Color.Transparent;
            this.dodajPanel.Controls.Add(this.dodajButton);
            this.dodajPanel.Controls.Add(this.ustalDestinationButton);
            this.dodajPanel.Controls.Add(this.ustalSourceButton);
            this.dodajPanel.Controls.Add(this.destinationFolderTextBox);
            this.dodajPanel.Controls.Add(this.label2);
            this.dodajPanel.Controls.Add(this.sourceFolderTextBox);
            this.dodajPanel.Controls.Add(this.label1);
            this.dodajPanel.Location = new System.Drawing.Point(12, 466);
            this.dodajPanel.Name = "dodajPanel";
            this.dodajPanel.Size = new System.Drawing.Size(755, 134);
            this.dodajPanel.TabIndex = 6;
            this.dodajPanel.Visible = false;
            // 
            // dodajButton
            // 
            this.dodajButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dodajButton.Location = new System.Drawing.Point(561, 87);
            this.dodajButton.Name = "dodajButton";
            this.dodajButton.Size = new System.Drawing.Size(154, 29);
            this.dodajButton.TabIndex = 6;
            this.dodajButton.Text = "Dodaj";
            this.dodajButton.UseVisualStyleBackColor = true;
            this.dodajButton.Click += new System.EventHandler(this.dodajButton_Click);
            // 
            // ustalDestinationButton
            // 
            this.ustalDestinationButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ustalDestinationButton.Location = new System.Drawing.Point(640, 46);
            this.ustalDestinationButton.Name = "ustalDestinationButton";
            this.ustalDestinationButton.Size = new System.Drawing.Size(112, 26);
            this.ustalDestinationButton.TabIndex = 5;
            this.ustalDestinationButton.Text = "Ustal";
            this.ustalDestinationButton.UseVisualStyleBackColor = true;
            this.ustalDestinationButton.Click += new System.EventHandler(this.ustalDestinationButton_Click);
            // 
            // ustalSourceButton
            // 
            this.ustalSourceButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ustalSourceButton.Location = new System.Drawing.Point(640, 8);
            this.ustalSourceButton.Name = "ustalSourceButton";
            this.ustalSourceButton.Size = new System.Drawing.Size(112, 26);
            this.ustalSourceButton.TabIndex = 4;
            this.ustalSourceButton.Text = "Ustal";
            this.ustalSourceButton.UseVisualStyleBackColor = true;
            this.ustalSourceButton.Click += new System.EventHandler(this.ustalSourceButton_Click);
            // 
            // destinationFolderTextBox
            // 
            this.destinationFolderTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.destinationFolderTextBox.Location = new System.Drawing.Point(183, 46);
            this.destinationFolderTextBox.Name = "destinationFolderTextBox";
            this.destinationFolderTextBox.Size = new System.Drawing.Size(451, 26);
            this.destinationFolderTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(24, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Folder docelowy:";
            // 
            // sourceFolderTextBox
            // 
            this.sourceFolderTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sourceFolderTextBox.Location = new System.Drawing.Point(183, 8);
            this.sourceFolderTextBox.Name = "sourceFolderTextBox";
            this.sourceFolderTextBox.Size = new System.Drawing.Size(451, 26);
            this.sourceFolderTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(23, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Folder źródłowy:";
            // sortujCustom
            // 
            this.sortujCustom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.sortujCustom.Image = ((System.Drawing.Image)(resources.GetObject("sortujCustom.Image")));
            this.sortujCustom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sortujCustom.Name = "sortujCustom";
            this.sortujCustom.Size = new System.Drawing.Size(29, 29);
            this.sortujCustom.Text = "Sortowanie niestandardowe";
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MuseSort.Properties.Resources.tlo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(988, 625);
            this.Controls.Add(this.aktualnyFolder);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.drzewoFolderow);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dodajPanel);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainGUI";
            this.Text = "MuseSort";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.dodajPanel.ResumeLayout(false);
            this.dodajPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zamknijToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opcjeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ustawieniaToolStripMenuItem;
        private System.Windows.Forms.TreeView drzewoFolderow;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton modyfikujButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton dodajDoGlownegoFolderuButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton dodajPiosenkiButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton sortujButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView aktualnyFolder;
        public System.Windows.Forms.ColumnHeader nazwa;
        public System.Windows.Forms.ColumnHeader rozszerzenie;
        public System.Windows.Forms.ColumnHeader rozmiar;
        private System.Windows.Forms.Panel dodajPanel;
        private System.Windows.Forms.Button dodajButton;
        private System.Windows.Forms.Button ustalDestinationButton;
        private System.Windows.Forms.Button ustalSourceButton;
        private System.Windows.Forms.TextBox destinationFolderTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sourceFolderTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton sortujCustom;

    }
}