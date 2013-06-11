namespace MuseSort
{
    partial class MainGUI
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zamknijToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opcjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ustawieniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wzorcePlikówAudioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wzorcePlikówVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.samouczekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drzewoFolderow = new System.Windows.Forms.TreeView();
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
            this.niestandardoweSortowaniePanel = new System.Windows.Forms.Panel();
            this.sortujNiestandardowoButton = new System.Windows.Forms.Button();
            this.flacCheckBox = new System.Windows.Forms.CheckBox();
            this.mp3checkBox = new System.Windows.Forms.CheckBox();
            this.sortowanieNiestandardoweListBox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.logiTextBox = new System.Windows.Forms.TextBox();
            this.otworzBibliotekeButton = new System.Windows.Forms.Button();
            this.dodajPlikDoBiblitekiButton = new System.Windows.Forms.Button();
            this.sortowanieNiestanradoweButton = new System.Windows.Forms.Button();
            this.pokazSzczegolyPlikuButton = new System.Windows.Forms.Button();
            this.sortujPlikiButton = new System.Windows.Forms.Button();
            this.dodajPiosenkiDoFoldeuButton = new System.Windows.Forms.Button();
            this.dodajPlikDoGlownegoFolderuButton = new System.Windows.Forms.Button();
            this.modyfikujTagiButton = new System.Windows.Forms.Button();
            this.drzewoLabel = new System.Windows.Forms.Label();
            this.folderLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.dodajPanel.SuspendLayout();
            this.niestandardoweSortowaniePanel.SuspendLayout();
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1208, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zamknijToolStripMenuItem});
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.programToolStripMenuItem.Text = "Program";
            // 
            // zamknijToolStripMenuItem
            // 
            this.zamknijToolStripMenuItem.Name = "zamknijToolStripMenuItem";
            this.zamknijToolStripMenuItem.Size = new System.Drawing.Size(131, 24);
            this.zamknijToolStripMenuItem.Text = "Zamknij";
            this.zamknijToolStripMenuItem.Click += new System.EventHandler(this.zamknijToolStripMenuItem_Click);
            // 
            // opcjeToolStripMenuItem
            // 
            this.opcjeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ustawieniaToolStripMenuItem,
            this.wzorcePlikówAudioToolStripMenuItem,
            this.wzorcePlikówVideoToolStripMenuItem,
            this.samouczekToolStripMenuItem});
            this.opcjeToolStripMenuItem.Name = "opcjeToolStripMenuItem";
            this.opcjeToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.opcjeToolStripMenuItem.Text = "Opcje";
            // 
            // ustawieniaToolStripMenuItem
            // 
            this.ustawieniaToolStripMenuItem.Name = "ustawieniaToolStripMenuItem";
            this.ustawieniaToolStripMenuItem.Size = new System.Drawing.Size(218, 24);
            this.ustawieniaToolStripMenuItem.Text = "Ustawienia";
            this.ustawieniaToolStripMenuItem.Click += new System.EventHandler(this.ustawieniaToolStripMenuItem_Click);
            // 
            // wzorcePlikówAudioToolStripMenuItem
            // 
            this.wzorcePlikówAudioToolStripMenuItem.Name = "wzorcePlikówAudioToolStripMenuItem";
            this.wzorcePlikówAudioToolStripMenuItem.Size = new System.Drawing.Size(218, 24);
            this.wzorcePlikówAudioToolStripMenuItem.Text = "Wzorce plików audio";
            this.wzorcePlikówAudioToolStripMenuItem.Click += new System.EventHandler(this.wzorcePlikówAudioToolStripMenuItem_Click);
            // 
            // wzorcePlikówVideoToolStripMenuItem
            // 
            this.wzorcePlikówVideoToolStripMenuItem.Name = "wzorcePlikówVideoToolStripMenuItem";
            this.wzorcePlikówVideoToolStripMenuItem.Size = new System.Drawing.Size(218, 24);
            this.wzorcePlikówVideoToolStripMenuItem.Text = "Wzorce plików video";
            this.wzorcePlikówVideoToolStripMenuItem.Click += new System.EventHandler(this.wzorcePlikówVideoToolStripMenuItem_Click);
            // 
            // samouczekToolStripMenuItem
            // 
            this.samouczekToolStripMenuItem.Name = "samouczekToolStripMenuItem";
            this.samouczekToolStripMenuItem.Size = new System.Drawing.Size(218, 24);
            this.samouczekToolStripMenuItem.Text = "Samouczek";
            this.samouczekToolStripMenuItem.Click += new System.EventHandler(this.samouczekToolStripMenuItem_Click);
            // 
            // drzewoFolderow
            // 
            this.drzewoFolderow.BackColor = System.Drawing.Color.LightSteelBlue;
            this.drzewoFolderow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.drzewoFolderow.Location = new System.Drawing.Point(16, 114);
            this.drzewoFolderow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.drzewoFolderow.Name = "drzewoFolderow";
            this.drzewoFolderow.Size = new System.Drawing.Size(281, 381);
            this.drzewoFolderow.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 673);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1208, 26);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(165, 21);
            this.toolStripStatusLabel1.Text = "Wykonywanie operacji: ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(17, 21);
            this.toolStripStatusLabel2.Text = "  ";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(400, 20);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MuseSort.Properties.Resources.logo1;
            this.pictureBox1.InitialImage = global::MuseSort.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(1032, 114);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(147, 162);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // aktualnyFolder
            // 
            this.aktualnyFolder.BackColor = System.Drawing.Color.LightSteelBlue;
            this.aktualnyFolder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nazwa,
            this.rozszerzenie,
            this.rozmiar});
            this.aktualnyFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.aktualnyFolder.Location = new System.Drawing.Point(329, 114);
            this.aktualnyFolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.aktualnyFolder.Name = "aktualnyFolder";
            this.aktualnyFolder.Size = new System.Drawing.Size(665, 381);
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
            this.rozszerzenie.Width = 152;
            // 
            // rozmiar
            // 
            this.rozmiar.Text = "Rozmiar";
            this.rozmiar.Width = 134;
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
            this.dodajPanel.Location = new System.Drawing.Point(12, 505);
            this.dodajPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dodajPanel.Name = "dodajPanel";
            this.dodajPanel.Size = new System.Drawing.Size(1007, 165);
            this.dodajPanel.TabIndex = 6;
            this.dodajPanel.Visible = false;
            // 
            // dodajButton
            // 
            this.dodajButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dodajButton.Location = new System.Drawing.Point(748, 107);
            this.dodajButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dodajButton.Name = "dodajButton";
            this.dodajButton.Size = new System.Drawing.Size(205, 36);
            this.dodajButton.TabIndex = 6;
            this.dodajButton.Text = "Dodaj";
            this.dodajButton.UseVisualStyleBackColor = true;
            this.dodajButton.Click += new System.EventHandler(this.dodajButton_Click);
            // 
            // ustalDestinationButton
            // 
            this.ustalDestinationButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ustalDestinationButton.Location = new System.Drawing.Point(853, 57);
            this.ustalDestinationButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ustalDestinationButton.Name = "ustalDestinationButton";
            this.ustalDestinationButton.Size = new System.Drawing.Size(149, 32);
            this.ustalDestinationButton.TabIndex = 5;
            this.ustalDestinationButton.Text = "Ustal";
            this.ustalDestinationButton.UseVisualStyleBackColor = true;
            this.ustalDestinationButton.Click += new System.EventHandler(this.ustalDestinationButton_Click);
            // 
            // ustalSourceButton
            // 
            this.ustalSourceButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ustalSourceButton.Location = new System.Drawing.Point(853, 10);
            this.ustalSourceButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ustalSourceButton.Name = "ustalSourceButton";
            this.ustalSourceButton.Size = new System.Drawing.Size(149, 32);
            this.ustalSourceButton.TabIndex = 4;
            this.ustalSourceButton.Text = "Ustal";
            this.ustalSourceButton.UseVisualStyleBackColor = true;
            this.ustalSourceButton.Click += new System.EventHandler(this.ustalSourceButton_Click);
            // 
            // destinationFolderTextBox
            // 
            this.destinationFolderTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.destinationFolderTextBox.Location = new System.Drawing.Point(244, 57);
            this.destinationFolderTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.destinationFolderTextBox.Name = "destinationFolderTextBox";
            this.destinationFolderTextBox.Size = new System.Drawing.Size(600, 30);
            this.destinationFolderTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(32, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Folder docelowy:";
            // 
            // sourceFolderTextBox
            // 
            this.sourceFolderTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sourceFolderTextBox.Location = new System.Drawing.Point(244, 10);
            this.sourceFolderTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sourceFolderTextBox.Name = "sourceFolderTextBox";
            this.sourceFolderTextBox.Size = new System.Drawing.Size(600, 30);
            this.sourceFolderTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(31, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Folder źródłowy:";
            // 
            // niestandardoweSortowaniePanel
            // 
            this.niestandardoweSortowaniePanel.BackColor = System.Drawing.Color.Transparent;
            this.niestandardoweSortowaniePanel.Controls.Add(this.sortujNiestandardowoButton);
            this.niestandardoweSortowaniePanel.Controls.Add(this.flacCheckBox);
            this.niestandardoweSortowaniePanel.Controls.Add(this.mp3checkBox);
            this.niestandardoweSortowaniePanel.Controls.Add(this.sortowanieNiestandardoweListBox);
            this.niestandardoweSortowaniePanel.Controls.Add(this.label4);
            this.niestandardoweSortowaniePanel.Controls.Add(this.label3);
            this.niestandardoweSortowaniePanel.Location = new System.Drawing.Point(12, 517);
            this.niestandardoweSortowaniePanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.niestandardoweSortowaniePanel.Name = "niestandardoweSortowaniePanel";
            this.niestandardoweSortowaniePanel.Size = new System.Drawing.Size(1195, 146);
            this.niestandardoweSortowaniePanel.TabIndex = 7;
            this.niestandardoweSortowaniePanel.Visible = false;
            // 
            // sortujNiestandardowoButton
            // 
            this.sortujNiestandardowoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sortujNiestandardowoButton.Location = new System.Drawing.Point(1025, 86);
            this.sortujNiestandardowoButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sortujNiestandardowoButton.Name = "sortujNiestandardowoButton";
            this.sortujNiestandardowoButton.Size = new System.Drawing.Size(160, 39);
            this.sortujNiestandardowoButton.TabIndex = 5;
            this.sortujNiestandardowoButton.Text = "Sortuj";
            this.sortujNiestandardowoButton.UseVisualStyleBackColor = true;
            this.sortujNiestandardowoButton.Click += new System.EventHandler(this.sortujNiestandardowoButton_Click);
            // 
            // flacCheckBox
            // 
            this.flacCheckBox.AutoSize = true;
            this.flacCheckBox.ForeColor = System.Drawing.Color.White;
            this.flacCheckBox.Location = new System.Drawing.Point(1131, 39);
            this.flacCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flacCheckBox.Name = "flacCheckBox";
            this.flacCheckBox.Size = new System.Drawing.Size(61, 21);
            this.flacCheckBox.TabIndex = 4;
            this.flacCheckBox.Text = "*.flac";
            this.flacCheckBox.UseVisualStyleBackColor = true;
            // 
            // mp3checkBox
            // 
            this.mp3checkBox.ForeColor = System.Drawing.Color.White;
            this.mp3checkBox.Location = new System.Drawing.Point(1021, 36);
            this.mp3checkBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mp3checkBox.Name = "mp3checkBox";
            this.mp3checkBox.Size = new System.Drawing.Size(104, 25);
            this.mp3checkBox.TabIndex = 3;
            this.mp3checkBox.Text = "*.mp3";
            this.mp3checkBox.UseVisualStyleBackColor = true;
            // 
            // sortowanieNiestandardoweListBox
            // 
            this.sortowanieNiestandardoweListBox.FormattingEnabled = true;
            this.sortowanieNiestandardoweListBox.ItemHeight = 16;
            this.sortowanieNiestandardoweListBox.Items.AddRange(new object[] {
            "Wykonawca\\Album\\Piosenki",
            "Wykonawca\\Rok\\Album\\Piosenki",
            "Gatunek\\Wykonawca\\Album\\Piosenki",
            "Gatunek\\Wykonawca\\Piosenki",
            "Rok\\Gatunek\\Wykonawca\\Album\\Piosenki",
            "Rok\\Wykonawca\\Album\\Piosenki",
            "Piosenki\\Alfabetycznie"});
            this.sortowanieNiestandardoweListBox.Location = new System.Drawing.Point(345, 14);
            this.sortowanieNiestandardoweListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sortowanieNiestandardoweListBox.Name = "sortowanieNiestandardoweListBox";
            this.sortowanieNiestandardoweListBox.Size = new System.Drawing.Size(303, 116);
            this.sortowanieNiestandardoweListBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(667, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(306, 24);
            this.label4.TabIndex = 1;
            this.label4.Text = "Wybierz typ sortowanych plików";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(49, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(265, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Wybierz sposób sortowania";
            // 
            // logiTextBox
            // 
            this.logiTextBox.BackColor = System.Drawing.Color.DodgerBlue;
            this.logiTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.logiTextBox.ForeColor = System.Drawing.Color.Navy;
            this.logiTextBox.Location = new System.Drawing.Point(1032, 286);
            this.logiTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.logiTextBox.Multiline = true;
            this.logiTextBox.Name = "logiTextBox";
            this.logiTextBox.Size = new System.Drawing.Size(147, 210);
            this.logiTextBox.TabIndex = 8;
            // 
            // otworzBibliotekeButton
            // 
            this.otworzBibliotekeButton.BackColor = System.Drawing.Color.MediumBlue;
            this.otworzBibliotekeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.otworzBibliotekeButton.ForeColor = System.Drawing.Color.White;
            this.otworzBibliotekeButton.Location = new System.Drawing.Point(1081, 42);
            this.otworzBibliotekeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.otworzBibliotekeButton.Name = "otworzBibliotekeButton";
            this.otworzBibliotekeButton.Size = new System.Drawing.Size(99, 55);
            this.otworzBibliotekeButton.TabIndex = 24;
            this.otworzBibliotekeButton.Text = "Otwórz bibliotekę";
            this.otworzBibliotekeButton.UseVisualStyleBackColor = false;
            this.otworzBibliotekeButton.Click += new System.EventHandler(this.otworzBibliotekeButton_Click);
            // 
            // dodajPlikDoBiblitekiButton
            // 
            this.dodajPlikDoBiblitekiButton.BackColor = System.Drawing.Color.MediumBlue;
            this.dodajPlikDoBiblitekiButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dodajPlikDoBiblitekiButton.ForeColor = System.Drawing.Color.White;
            this.dodajPlikDoBiblitekiButton.Location = new System.Drawing.Point(949, 42);
            this.dodajPlikDoBiblitekiButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dodajPlikDoBiblitekiButton.Name = "dodajPlikDoBiblitekiButton";
            this.dodajPlikDoBiblitekiButton.Size = new System.Drawing.Size(125, 55);
            this.dodajPlikDoBiblitekiButton.TabIndex = 23;
            this.dodajPlikDoBiblitekiButton.Text = "Dodaj plik do biblioteki";
            this.dodajPlikDoBiblitekiButton.UseVisualStyleBackColor = false;
            this.dodajPlikDoBiblitekiButton.Click += new System.EventHandler(this.dodajPlikDoBiblitekiButton_Click);
            // 
            // sortowanieNiestanradoweButton
            // 
            this.sortowanieNiestanradoweButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.sortowanieNiestanradoweButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sortowanieNiestanradoweButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.sortowanieNiestanradoweButton.Location = new System.Drawing.Point(768, 42);
            this.sortowanieNiestanradoweButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sortowanieNiestanradoweButton.Name = "sortowanieNiestanradoweButton";
            this.sortowanieNiestanradoweButton.Size = new System.Drawing.Size(144, 55);
            this.sortowanieNiestanradoweButton.TabIndex = 22;
            this.sortowanieNiestanradoweButton.Text = "Sortowanie niestandardowe";
            this.sortowanieNiestanradoweButton.UseVisualStyleBackColor = false;
            this.sortowanieNiestanradoweButton.Click += new System.EventHandler(this.sortowanieNiestanradoweButton_Click);
            // 
            // pokazSzczegolyPlikuButton
            // 
            this.pokazSzczegolyPlikuButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.pokazSzczegolyPlikuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pokazSzczegolyPlikuButton.Location = new System.Drawing.Point(433, 42);
            this.pokazSzczegolyPlikuButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pokazSzczegolyPlikuButton.Name = "pokazSzczegolyPlikuButton";
            this.pokazSzczegolyPlikuButton.Size = new System.Drawing.Size(148, 55);
            this.pokazSzczegolyPlikuButton.TabIndex = 21;
            this.pokazSzczegolyPlikuButton.Text = "Przeczytaj szczegóły pliku";
            this.pokazSzczegolyPlikuButton.UseVisualStyleBackColor = false;
            this.pokazSzczegolyPlikuButton.Click += new System.EventHandler(this.pokazSzczegolyPlikuButton_Click);
            // 
            // sortujPlikiButton
            // 
            this.sortujPlikiButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.sortujPlikiButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sortujPlikiButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.sortujPlikiButton.Location = new System.Drawing.Point(633, 42);
            this.sortujPlikiButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sortujPlikiButton.Name = "sortujPlikiButton";
            this.sortujPlikiButton.Size = new System.Drawing.Size(129, 55);
            this.sortujPlikiButton.TabIndex = 20;
            this.sortujPlikiButton.Text = "Sortuj pliki";
            this.sortujPlikiButton.UseVisualStyleBackColor = false;
            this.sortujPlikiButton.Click += new System.EventHandler(this.sortujPlikiButton_Click);
            // 
            // dodajPiosenkiDoFoldeuButton
            // 
            this.dodajPiosenkiDoFoldeuButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dodajPiosenkiDoFoldeuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dodajPiosenkiDoFoldeuButton.Location = new System.Drawing.Point(283, 42);
            this.dodajPiosenkiDoFoldeuButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dodajPiosenkiDoFoldeuButton.Name = "dodajPiosenkiDoFoldeuButton";
            this.dodajPiosenkiDoFoldeuButton.Size = new System.Drawing.Size(112, 55);
            this.dodajPiosenkiDoFoldeuButton.TabIndex = 19;
            this.dodajPiosenkiDoFoldeuButton.Text = "Dodaj plik do folderu";
            this.dodajPiosenkiDoFoldeuButton.UseVisualStyleBackColor = false;
            this.dodajPiosenkiDoFoldeuButton.Visible = false;
            this.dodajPiosenkiDoFoldeuButton.Click += new System.EventHandler(this.dodajPiosenkiDoFoldeuButton_Click);
            // 
            // dodajPlikDoGlownegoFolderuButton
            // 
            this.dodajPlikDoGlownegoFolderuButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dodajPlikDoGlownegoFolderuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dodajPlikDoGlownegoFolderuButton.Location = new System.Drawing.Point(123, 42);
            this.dodajPlikDoGlownegoFolderuButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dodajPlikDoGlownegoFolderuButton.Name = "dodajPlikDoGlownegoFolderuButton";
            this.dodajPlikDoGlownegoFolderuButton.Size = new System.Drawing.Size(153, 55);
            this.dodajPlikDoGlownegoFolderuButton.TabIndex = 18;
            this.dodajPlikDoGlownegoFolderuButton.Text = "Dodaj folder do folderu głównego";
            this.dodajPlikDoGlownegoFolderuButton.UseVisualStyleBackColor = false;
            this.dodajPlikDoGlownegoFolderuButton.Click += new System.EventHandler(this.dodajPlikDoGlownegoFolderuButton_Click);
            // 
            // modyfikujTagiButton
            // 
            this.modyfikujTagiButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.modyfikujTagiButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modyfikujTagiButton.Location = new System.Drawing.Point(7, 42);
            this.modyfikujTagiButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.modyfikujTagiButton.Name = "modyfikujTagiButton";
            this.modyfikujTagiButton.Size = new System.Drawing.Size(105, 55);
            this.modyfikujTagiButton.TabIndex = 17;
            this.modyfikujTagiButton.Text = "Modyfikuj tagi pliku";
            this.modyfikujTagiButton.UseVisualStyleBackColor = false;
            this.modyfikujTagiButton.Click += new System.EventHandler(this.modyfikujTagiButton_Click);
            // 
            // drzewoLabel
            // 
            this.drzewoLabel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.drzewoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.drzewoLabel.ForeColor = System.Drawing.Color.Black;
            this.drzewoLabel.Location = new System.Drawing.Point(141, 126);
            this.drzewoLabel.Name = "drzewoLabel";
            this.drzewoLabel.Size = new System.Drawing.Size(156, 47);
            this.drzewoLabel.TabIndex = 25;
            this.drzewoLabel.Text = "Tu wyświetlane jest drzewo folderów";
            // 
            // folderLabel
            // 
            this.folderLabel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.folderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.folderLabel.ForeColor = System.Drawing.Color.Black;
            this.folderLabel.Location = new System.Drawing.Point(844, 151);
            this.folderLabel.Name = "folderLabel";
            this.folderLabel.Size = new System.Drawing.Size(139, 78);
            this.folderLabel.TabIndex = 26;
            this.folderLabel.Text = "Tu widoczna jest zawartość zaznaczonego folderu";
            this.folderLabel.Click += new System.EventHandler(this.folderLabel_Click);
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MuseSort.Properties.Resources.tlo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1208, 699);
            this.Controls.Add(this.folderLabel);
            this.Controls.Add(this.drzewoLabel);
            this.Controls.Add(this.otworzBibliotekeButton);
            this.Controls.Add(this.dodajPlikDoBiblitekiButton);
            this.Controls.Add(this.sortowanieNiestanradoweButton);
            this.Controls.Add(this.pokazSzczegolyPlikuButton);
            this.Controls.Add(this.sortujPlikiButton);
            this.Controls.Add(this.dodajPiosenkiDoFoldeuButton);
            this.Controls.Add(this.dodajPlikDoGlownegoFolderuButton);
            this.Controls.Add(this.modyfikujTagiButton);
            this.Controls.Add(this.logiTextBox);
            this.Controls.Add(this.niestandardoweSortowaniePanel);
            this.Controls.Add(this.aktualnyFolder);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.drzewoFolderow);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dodajPanel);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "MainGUI";
            this.Text = "MuseSort";
            this.Load += new System.EventHandler(this.MainGUI_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.dodajPanel.ResumeLayout(false);
            this.dodajPanel.PerformLayout();
            this.niestandardoweSortowaniePanel.ResumeLayout(false);
            this.niestandardoweSortowaniePanel.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem wzorcePlikówAudioToolStripMenuItem;
        private System.Windows.Forms.Panel niestandardoweSortowaniePanel;
        private System.Windows.Forms.Button sortujNiestandardowoButton;
        private System.Windows.Forms.CheckBox flacCheckBox;
        private System.Windows.Forms.CheckBox mp3checkBox;
        private System.Windows.Forms.ListBox sortowanieNiestandardoweListBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox logiTextBox;
        private System.Windows.Forms.ToolStripMenuItem wzorcePlikówVideoToolStripMenuItem;
        private System.Windows.Forms.Button otworzBibliotekeButton;
        private System.Windows.Forms.Button dodajPlikDoBiblitekiButton;
        private System.Windows.Forms.Button sortowanieNiestanradoweButton;
        private System.Windows.Forms.Button pokazSzczegolyPlikuButton;
        private System.Windows.Forms.Button sortujPlikiButton;
        private System.Windows.Forms.Button dodajPiosenkiDoFoldeuButton;
        private System.Windows.Forms.Button dodajPlikDoGlownegoFolderuButton;
        private System.Windows.Forms.Button modyfikujTagiButton;
        private System.Windows.Forms.Label drzewoLabel;
        private System.Windows.Forms.Label folderLabel;
        private System.Windows.Forms.ToolStripMenuItem samouczekToolStripMenuItem;

    }
}