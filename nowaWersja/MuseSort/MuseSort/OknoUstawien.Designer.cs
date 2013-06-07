namespace MuseSort
{
    partial class OknoUstawien
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
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Folder główny");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("Foldery", new System.Windows.Forms.TreeNode[] {
            treeNode29});
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Domyślne ustawienia");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Sortowanie", new System.Windows.Forms.TreeNode[] {
            treeNode31});
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("Wspierane rozszerzenia");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("Rozszerzenia", new System.Windows.Forms.TreeNode[] {
            treeNode33});
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("Zewnętrzne bazy danych");
            this.drzewoUstawien = new System.Windows.Forms.TreeView();
            this.przywrocDomyslneButton = new System.Windows.Forms.Button();
            this.zapiszButton = new System.Windows.Forms.Button();
            this.anulujButton = new System.Windows.Forms.Button();
            this.folderyPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.sciezkaBox = new System.Windows.Forms.TextBox();
            this.folderGlownyPanel = new System.Windows.Forms.Panel();
            this.ustawNowyFolderGlownyButton = new System.Windows.Forms.Button();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.nowaSciezkaBox = new System.Windows.Forms.TextBox();
            this.wybierzNowyFolderGlownyButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.sciezka2Box = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sortowaniaPanel = new System.Windows.Forms.Panel();
            this.sposobSortowaniaBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.domyslneSortowaniaPanel = new System.Windows.Forms.Panel();
            this.sortowaniaListBox = new System.Windows.Forms.ListBox();
            this.zmienSposobSortowaniaButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.sposobSortowania2Box = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rozszerzeniaPanel = new System.Windows.Forms.Panel();
            this.rozszerzeniaBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.wspieranieRozszerzeniaPanel = new System.Windows.Forms.Panel();
            this.dodajRozszerzenieButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.zewnetrzneBazyDanychPanel = new System.Windows.Forms.Panel();
            this.wybierzBazeButton = new System.Windows.Forms.Button();
            this.dataBaseListBox = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.explorer = new System.Windows.Forms.FolderBrowserDialog();
            this.mp3CheckBox = new System.Windows.Forms.CheckBox();
            this.flacCheckBox = new System.Windows.Forms.CheckBox();
            this.folderyPanel.SuspendLayout();
            this.folderGlownyPanel.SuspendLayout();
            this.sortowaniaPanel.SuspendLayout();
            this.domyslneSortowaniaPanel.SuspendLayout();
            this.rozszerzeniaPanel.SuspendLayout();
            this.wspieranieRozszerzeniaPanel.SuspendLayout();
            this.zewnetrzneBazyDanychPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // drzewoUstawien
            // 
            this.drzewoUstawien.BackColor = System.Drawing.Color.LightSkyBlue;
            this.drzewoUstawien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.drzewoUstawien.Location = new System.Drawing.Point(10, 11);
            this.drzewoUstawien.Margin = new System.Windows.Forms.Padding(2);
            this.drzewoUstawien.Name = "drzewoUstawien";
            treeNode29.Name = "folderGlownyNode";
            treeNode29.Text = "Folder główny";
            treeNode30.Name = "folderyNode";
            treeNode30.Text = "Foldery";
            treeNode31.Name = "domyslneSortowanieNode";
            treeNode31.Text = "Domyślne ustawienia";
            treeNode32.Name = "sortowaniaNode";
            treeNode32.Text = "Sortowanie";
            treeNode33.Name = "wspieraneRozszerzeniaNode";
            treeNode33.Text = "Wspierane rozszerzenia";
            treeNode34.Name = "rozszerzeniaNode";
            treeNode34.Text = "Rozszerzenia";
            treeNode35.Name = "bazyDanychNode";
            treeNode35.Text = "Zewnętrzne bazy danych";
            this.drzewoUstawien.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode30,
            treeNode32,
            treeNode34,
            treeNode35});
            this.drzewoUstawien.Size = new System.Drawing.Size(188, 311);
            this.drzewoUstawien.TabIndex = 0;
            // 
            // przywrocDomyslneButton
            // 
            this.przywrocDomyslneButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.przywrocDomyslneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.przywrocDomyslneButton.ForeColor = System.Drawing.Color.DarkBlue;
            this.przywrocDomyslneButton.Location = new System.Drawing.Point(230, 310);
            this.przywrocDomyslneButton.Margin = new System.Windows.Forms.Padding(2);
            this.przywrocDomyslneButton.Name = "przywrocDomyslneButton";
            this.przywrocDomyslneButton.Size = new System.Drawing.Size(103, 24);
            this.przywrocDomyslneButton.TabIndex = 1;
            this.przywrocDomyslneButton.Text = "Przywróć domyślne";
            this.przywrocDomyslneButton.UseVisualStyleBackColor = false;
            this.przywrocDomyslneButton.Click += new System.EventHandler(this.przywrocDomyslneButton_Click);
            // 
            // zapiszButton
            // 
            this.zapiszButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.zapiszButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.zapiszButton.ForeColor = System.Drawing.Color.DarkBlue;
            this.zapiszButton.Location = new System.Drawing.Point(338, 310);
            this.zapiszButton.Margin = new System.Windows.Forms.Padding(2);
            this.zapiszButton.Name = "zapiszButton";
            this.zapiszButton.Size = new System.Drawing.Size(62, 24);
            this.zapiszButton.TabIndex = 2;
            this.zapiszButton.Text = "Zapisz";
            this.zapiszButton.UseVisualStyleBackColor = false;
            this.zapiszButton.Click += new System.EventHandler(this.zapiszButton_Click);
            // 
            // anulujButton
            // 
            this.anulujButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.anulujButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.anulujButton.ForeColor = System.Drawing.Color.DarkBlue;
            this.anulujButton.Location = new System.Drawing.Point(404, 310);
            this.anulujButton.Margin = new System.Windows.Forms.Padding(2);
            this.anulujButton.Name = "anulujButton";
            this.anulujButton.Size = new System.Drawing.Size(62, 24);
            this.anulujButton.TabIndex = 3;
            this.anulujButton.Text = "Anuluj";
            this.anulujButton.UseVisualStyleBackColor = false;
            this.anulujButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.anulujButton_MouseClick);
            // 
            // folderyPanel
            // 
            this.folderyPanel.BackColor = System.Drawing.Color.Transparent;
            this.folderyPanel.Controls.Add(this.label1);
            this.folderyPanel.Controls.Add(this.sciezkaBox);
            this.folderyPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.folderyPanel.Location = new System.Drawing.Point(215, 11);
            this.folderyPanel.Margin = new System.Windows.Forms.Padding(2);
            this.folderyPanel.Name = "folderyPanel";
            this.folderyPanel.Size = new System.Drawing.Size(256, 101);
            this.folderyPanel.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(55, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Aktualny folder główny:";
            // 
            // sciezkaBox
            // 
            this.sciezkaBox.BackColor = System.Drawing.Color.Gray;
            this.sciezkaBox.Enabled = false;
            this.sciezkaBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sciezkaBox.ForeColor = System.Drawing.Color.White;
            this.sciezkaBox.Location = new System.Drawing.Point(14, 41);
            this.sciezkaBox.Margin = new System.Windows.Forms.Padding(2);
            this.sciezkaBox.Name = "sciezkaBox";
            this.sciezkaBox.Size = new System.Drawing.Size(234, 21);
            this.sciezkaBox.TabIndex = 1;
            // 
            // folderGlownyPanel
            // 
            this.folderGlownyPanel.BackColor = System.Drawing.Color.Transparent;
            this.folderGlownyPanel.Controls.Add(this.ustawNowyFolderGlownyButton);
            this.folderGlownyPanel.Controls.Add(this.checkBox);
            this.folderGlownyPanel.Controls.Add(this.nowaSciezkaBox);
            this.folderGlownyPanel.Controls.Add(this.wybierzNowyFolderGlownyButton);
            this.folderGlownyPanel.Controls.Add(this.label3);
            this.folderGlownyPanel.Controls.Add(this.sciezka2Box);
            this.folderGlownyPanel.Controls.Add(this.label2);
            this.folderGlownyPanel.Location = new System.Drawing.Point(214, 13);
            this.folderGlownyPanel.Margin = new System.Windows.Forms.Padding(2);
            this.folderGlownyPanel.Name = "folderGlownyPanel";
            this.folderGlownyPanel.Size = new System.Drawing.Size(283, 211);
            this.folderGlownyPanel.TabIndex = 5;
            // 
            // ustawNowyFolderGlownyButton
            // 
            this.ustawNowyFolderGlownyButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ustawNowyFolderGlownyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.ustawNowyFolderGlownyButton.ForeColor = System.Drawing.Color.DarkBlue;
            this.ustawNowyFolderGlownyButton.Location = new System.Drawing.Point(76, 158);
            this.ustawNowyFolderGlownyButton.Margin = new System.Windows.Forms.Padding(2);
            this.ustawNowyFolderGlownyButton.Name = "ustawNowyFolderGlownyButton";
            this.ustawNowyFolderGlownyButton.Size = new System.Drawing.Size(133, 25);
            this.ustawNowyFolderGlownyButton.TabIndex = 9;
            this.ustawNowyFolderGlownyButton.Text = "Ustaw nowy folder główny";
            this.ustawNowyFolderGlownyButton.UseVisualStyleBackColor = false;
            this.ustawNowyFolderGlownyButton.Click += new System.EventHandler(this.ustawNowyFolderGlownyButton_Click);
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.checkBox.ForeColor = System.Drawing.Color.White;
            this.checkBox.Location = new System.Drawing.Point(2, 133);
            this.checkBox.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(275, 19);
            this.checkBox.TabIndex = 8;
            this.checkBox.Text = "Przenieś foldery do nowego folderu głównego";
            this.checkBox.UseVisualStyleBackColor = true;
            // 
            // nowaSciezkaBox
            // 
            this.nowaSciezkaBox.BackColor = System.Drawing.Color.Gray;
            this.nowaSciezkaBox.Enabled = false;
            this.nowaSciezkaBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nowaSciezkaBox.ForeColor = System.Drawing.Color.Black;
            this.nowaSciezkaBox.Location = new System.Drawing.Point(14, 99);
            this.nowaSciezkaBox.Margin = new System.Windows.Forms.Padding(2);
            this.nowaSciezkaBox.Name = "nowaSciezkaBox";
            this.nowaSciezkaBox.Size = new System.Drawing.Size(234, 21);
            this.nowaSciezkaBox.TabIndex = 7;
            // 
            // wybierzNowyFolderGlownyButton
            // 
            this.wybierzNowyFolderGlownyButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.wybierzNowyFolderGlownyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.wybierzNowyFolderGlownyButton.ForeColor = System.Drawing.Color.DarkBlue;
            this.wybierzNowyFolderGlownyButton.Location = new System.Drawing.Point(175, 58);
            this.wybierzNowyFolderGlownyButton.Margin = new System.Windows.Forms.Padding(2);
            this.wybierzNowyFolderGlownyButton.Name = "wybierzNowyFolderGlownyButton";
            this.wybierzNowyFolderGlownyButton.Size = new System.Drawing.Size(56, 26);
            this.wybierzNowyFolderGlownyButton.TabIndex = 6;
            this.wybierzNowyFolderGlownyButton.Text = "...";
            this.wybierzNowyFolderGlownyButton.UseVisualStyleBackColor = false;
            this.wybierzNowyFolderGlownyButton.Click += new System.EventHandler(this.wybierzNowyFolderGlownyButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(11, 67);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Wybierz nowy folder główny:";
            // 
            // sciezka2Box
            // 
            this.sciezka2Box.BackColor = System.Drawing.Color.Gray;
            this.sciezka2Box.Enabled = false;
            this.sciezka2Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sciezka2Box.ForeColor = System.Drawing.Color.Black;
            this.sciezka2Box.Location = new System.Drawing.Point(11, 32);
            this.sciezka2Box.Margin = new System.Windows.Forms.Padding(2);
            this.sciezka2Box.Name = "sciezka2Box";
            this.sciezka2Box.Size = new System.Drawing.Size(234, 21);
            this.sciezka2Box.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(64, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Aktualny folder główny:";
            // 
            // sortowaniaPanel
            // 
            this.sortowaniaPanel.BackColor = System.Drawing.Color.Transparent;
            this.sortowaniaPanel.Controls.Add(this.sposobSortowaniaBox);
            this.sortowaniaPanel.Controls.Add(this.label4);
            this.sortowaniaPanel.Location = new System.Drawing.Point(202, 4);
            this.sortowaniaPanel.Margin = new System.Windows.Forms.Padding(2);
            this.sortowaniaPanel.Name = "sortowaniaPanel";
            this.sortowaniaPanel.Size = new System.Drawing.Size(256, 245);
            this.sortowaniaPanel.TabIndex = 6;
            // 
            // sposobSortowaniaBox
            // 
            this.sposobSortowaniaBox.BackColor = System.Drawing.Color.Gray;
            this.sposobSortowaniaBox.Enabled = false;
            this.sposobSortowaniaBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sposobSortowaniaBox.ForeColor = System.Drawing.Color.Black;
            this.sposobSortowaniaBox.Location = new System.Drawing.Point(20, 54);
            this.sposobSortowaniaBox.Margin = new System.Windows.Forms.Padding(2);
            this.sposobSortowaniaBox.Name = "sposobSortowaniaBox";
            this.sposobSortowaniaBox.Size = new System.Drawing.Size(207, 21);
            this.sposobSortowaniaBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(55, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Aktualny sposób sortowania:";
            // 
            // domyslneSortowaniaPanel
            // 
            this.domyslneSortowaniaPanel.BackColor = System.Drawing.Color.Transparent;
            this.domyslneSortowaniaPanel.Controls.Add(this.sortowaniaListBox);
            this.domyslneSortowaniaPanel.Controls.Add(this.zmienSposobSortowaniaButton);
            this.domyslneSortowaniaPanel.Controls.Add(this.label6);
            this.domyslneSortowaniaPanel.Controls.Add(this.sposobSortowania2Box);
            this.domyslneSortowaniaPanel.Controls.Add(this.label5);
            this.domyslneSortowaniaPanel.Location = new System.Drawing.Point(209, 15);
            this.domyslneSortowaniaPanel.Margin = new System.Windows.Forms.Padding(2);
            this.domyslneSortowaniaPanel.Name = "domyslneSortowaniaPanel";
            this.domyslneSortowaniaPanel.Size = new System.Drawing.Size(256, 270);
            this.domyslneSortowaniaPanel.TabIndex = 6;
            // 
            // sortowaniaListBox
            // 
            this.sortowaniaListBox.FormattingEnabled = true;
            this.sortowaniaListBox.Items.AddRange(new object[] {
            "Wykonawca\\Album\\Piosenki",
            "Wykonawca\\Rok\\Album\\Piosenki",
            "Gatunek\\Wykonawca\\Album\\Piosenki",
            "Gatunek\\Wykonawca\\Piosenki",
            "Rok\\Gatunek\\Wykonawca\\Album\\Piosenki",
            "Rok\\Wykonawca\\Album\\Piosenki",
            "Piosenki\\Alfabetycznie",
            "Piosenki\\Wykonawca"});
            this.sortowaniaListBox.Location = new System.Drawing.Point(14, 97);
            this.sortowaniaListBox.Margin = new System.Windows.Forms.Padding(2);
            this.sortowaniaListBox.Name = "sortowaniaListBox";
            this.sortowaniaListBox.Size = new System.Drawing.Size(235, 121);
            this.sortowaniaListBox.TabIndex = 10;
            // 
            // zmienSposobSortowaniaButton
            // 
            this.zmienSposobSortowaniaButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.zmienSposobSortowaniaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.zmienSposobSortowaniaButton.ForeColor = System.Drawing.Color.DarkBlue;
            this.zmienSposobSortowaniaButton.Location = new System.Drawing.Point(58, 236);
            this.zmienSposobSortowaniaButton.Margin = new System.Windows.Forms.Padding(2);
            this.zmienSposobSortowaniaButton.Name = "zmienSposobSortowaniaButton";
            this.zmienSposobSortowaniaButton.Size = new System.Drawing.Size(148, 28);
            this.zmienSposobSortowaniaButton.TabIndex = 9;
            this.zmienSposobSortowaniaButton.Text = "Zmień sposób sortowania";
            this.zmienSposobSortowaniaButton.UseVisualStyleBackColor = false;
            this.zmienSposobSortowaniaButton.Click += new System.EventHandler(this.zmienSposobSortowaniaButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(39, 79);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(184, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "Wybierz inny sposób sortowania:";
            // 
            // sposobSortowania2Box
            // 
            this.sposobSortowania2Box.BackColor = System.Drawing.Color.Gray;
            this.sposobSortowania2Box.Enabled = false;
            this.sposobSortowania2Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sposobSortowania2Box.ForeColor = System.Drawing.Color.Black;
            this.sposobSortowania2Box.Location = new System.Drawing.Point(23, 45);
            this.sposobSortowania2Box.Margin = new System.Windows.Forms.Padding(2);
            this.sposobSortowania2Box.Name = "sposobSortowania2Box";
            this.sposobSortowania2Box.Size = new System.Drawing.Size(212, 21);
            this.sposobSortowania2Box.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(62, 21);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Aktualny sposób sortowania:";
            // 
            // rozszerzeniaPanel
            // 
            this.rozszerzeniaPanel.BackColor = System.Drawing.Color.Transparent;
            this.rozszerzeniaPanel.Controls.Add(this.rozszerzeniaBox);
            this.rozszerzeniaPanel.Controls.Add(this.label7);
            this.rozszerzeniaPanel.Location = new System.Drawing.Point(209, 13);
            this.rozszerzeniaPanel.Margin = new System.Windows.Forms.Padding(2);
            this.rozszerzeniaPanel.Name = "rozszerzeniaPanel";
            this.rozszerzeniaPanel.Size = new System.Drawing.Size(273, 279);
            this.rozszerzeniaPanel.TabIndex = 7;
            // 
            // rozszerzeniaBox
            // 
            this.rozszerzeniaBox.BackColor = System.Drawing.Color.Gray;
            this.rozszerzeniaBox.Enabled = false;
            this.rozszerzeniaBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rozszerzeniaBox.ForeColor = System.Drawing.Color.Black;
            this.rozszerzeniaBox.Location = new System.Drawing.Point(10, 58);
            this.rozszerzeniaBox.Margin = new System.Windows.Forms.Padding(2);
            this.rozszerzeniaBox.Name = "rozszerzeniaBox";
            this.rozszerzeniaBox.Size = new System.Drawing.Size(207, 21);
            this.rozszerzeniaBox.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(55, 28);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Obsługiwane rozszerzenia";
            // 
            // wspieranieRozszerzeniaPanel
            // 
            this.wspieranieRozszerzeniaPanel.BackColor = System.Drawing.Color.Transparent;
            this.wspieranieRozszerzeniaPanel.Controls.Add(this.flacCheckBox);
            this.wspieranieRozszerzeniaPanel.Controls.Add(this.mp3CheckBox);
            this.wspieranieRozszerzeniaPanel.Controls.Add(this.dodajRozszerzenieButton);
            this.wspieranieRozszerzeniaPanel.Controls.Add(this.textBox1);
            this.wspieranieRozszerzeniaPanel.Controls.Add(this.label8);
            this.wspieranieRozszerzeniaPanel.Location = new System.Drawing.Point(212, 13);
            this.wspieranieRozszerzeniaPanel.Margin = new System.Windows.Forms.Padding(2);
            this.wspieranieRozszerzeniaPanel.Name = "wspieranieRozszerzeniaPanel";
            this.wspieranieRozszerzeniaPanel.Size = new System.Drawing.Size(271, 276);
            this.wspieranieRozszerzeniaPanel.TabIndex = 8;
            // 
            // dodajRozszerzenieButton
            // 
            this.dodajRozszerzenieButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dodajRozszerzenieButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.dodajRozszerzenieButton.ForeColor = System.Drawing.Color.DarkBlue;
            this.dodajRozszerzenieButton.Location = new System.Drawing.Point(43, 160);
            this.dodajRozszerzenieButton.Margin = new System.Windows.Forms.Padding(2);
            this.dodajRozszerzenieButton.Name = "dodajRozszerzenieButton";
            this.dodajRozszerzenieButton.Size = new System.Drawing.Size(171, 32);
            this.dodajRozszerzenieButton.TabIndex = 10;
            this.dodajRozszerzenieButton.Text = "Zapisz rozszerzenia";
            this.dodajRozszerzenieButton.UseVisualStyleBackColor = false;
            this.dodajRozszerzenieButton.Click += new System.EventHandler(this.dodajRozszerzenieButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Gray;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(26, 37);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(207, 21);
            this.textBox1.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(14, 16);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(152, 15);
            this.label8.TabIndex = 1;
            this.label8.Text = "Obsługiwane rozszerzenia";
            // 
            // zewnetrzneBazyDanychPanel
            // 
            this.zewnetrzneBazyDanychPanel.BackColor = System.Drawing.Color.Transparent;
            this.zewnetrzneBazyDanychPanel.Controls.Add(this.wybierzBazeButton);
            this.zewnetrzneBazyDanychPanel.Controls.Add(this.dataBaseListBox);
            this.zewnetrzneBazyDanychPanel.Controls.Add(this.label10);
            this.zewnetrzneBazyDanychPanel.Location = new System.Drawing.Point(202, 4);
            this.zewnetrzneBazyDanychPanel.Margin = new System.Windows.Forms.Padding(2);
            this.zewnetrzneBazyDanychPanel.Name = "zewnetrzneBazyDanychPanel";
            this.zewnetrzneBazyDanychPanel.Size = new System.Drawing.Size(273, 279);
            this.zewnetrzneBazyDanychPanel.TabIndex = 9;
            // 
            // wybierzBazeButton
            // 
            this.wybierzBazeButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.wybierzBazeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.wybierzBazeButton.ForeColor = System.Drawing.Color.DarkBlue;
            this.wybierzBazeButton.Location = new System.Drawing.Point(78, 205);
            this.wybierzBazeButton.Margin = new System.Windows.Forms.Padding(2);
            this.wybierzBazeButton.Name = "wybierzBazeButton";
            this.wybierzBazeButton.Size = new System.Drawing.Size(82, 38);
            this.wybierzBazeButton.TabIndex = 2;
            this.wybierzBazeButton.Text = "Wybierz bazę";
            this.wybierzBazeButton.UseVisualStyleBackColor = false;
            this.wybierzBazeButton.Click += new System.EventHandler(this.wybierzBazeButton_Click);
            // 
            // dataBaseListBox
            // 
            this.dataBaseListBox.FormattingEnabled = true;
            this.dataBaseListBox.Items.AddRange(new object[] {
            "MusicBrainz"});
            this.dataBaseListBox.Location = new System.Drawing.Point(49, 90);
            this.dataBaseListBox.Margin = new System.Windows.Forms.Padding(2);
            this.dataBaseListBox.Name = "dataBaseListBox";
            this.dataBaseListBox.Size = new System.Drawing.Size(205, 108);
            this.dataBaseListBox.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(89, 57);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "Wybierz bazę danych:";
            // 
            // mp3CheckBox
            // 
            this.mp3CheckBox.AutoSize = true;
            this.mp3CheckBox.ForeColor = System.Drawing.Color.White;
            this.mp3CheckBox.Location = new System.Drawing.Point(39, 85);
            this.mp3CheckBox.Name = "mp3CheckBox";
            this.mp3CheckBox.Size = new System.Drawing.Size(53, 17);
            this.mp3CheckBox.TabIndex = 11;
            this.mp3CheckBox.Text = "*.mp3";
            this.mp3CheckBox.UseVisualStyleBackColor = true;
            // 
            // flacCheckBox
            // 
            this.flacCheckBox.AutoSize = true;
            this.flacCheckBox.ForeColor = System.Drawing.Color.White;
            this.flacCheckBox.Location = new System.Drawing.Point(152, 84);
            this.flacCheckBox.Name = "flacCheckBox";
            this.flacCheckBox.Size = new System.Drawing.Size(50, 17);
            this.flacCheckBox.TabIndex = 12;
            this.flacCheckBox.Text = "*.flac";
            this.flacCheckBox.UseVisualStyleBackColor = true;
            // 
            // OknoUstawien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MuseSort.Properties.Resources.tlo;
            this.ClientSize = new System.Drawing.Size(494, 344);
            this.Controls.Add(this.anulujButton);
            this.Controls.Add(this.zapiszButton);
            this.Controls.Add(this.przywrocDomyslneButton);
            this.Controls.Add(this.drzewoUstawien);
            this.Controls.Add(this.wspieranieRozszerzeniaPanel);
            this.Controls.Add(this.rozszerzeniaPanel);
            this.Controls.Add(this.folderGlownyPanel);
            this.Controls.Add(this.domyslneSortowaniaPanel);
            this.Controls.Add(this.folderyPanel);
            this.Controls.Add(this.sortowaniaPanel);
            this.Controls.Add(this.zewnetrzneBazyDanychPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "OknoUstawien";
            this.Text = "OknoUstawien";
            this.folderyPanel.ResumeLayout(false);
            this.folderyPanel.PerformLayout();
            this.folderGlownyPanel.ResumeLayout(false);
            this.folderGlownyPanel.PerformLayout();
            this.sortowaniaPanel.ResumeLayout(false);
            this.sortowaniaPanel.PerformLayout();
            this.domyslneSortowaniaPanel.ResumeLayout(false);
            this.domyslneSortowaniaPanel.PerformLayout();
            this.rozszerzeniaPanel.ResumeLayout(false);
            this.rozszerzeniaPanel.PerformLayout();
            this.wspieranieRozszerzeniaPanel.ResumeLayout(false);
            this.wspieranieRozszerzeniaPanel.PerformLayout();
            this.zewnetrzneBazyDanychPanel.ResumeLayout(false);
            this.zewnetrzneBazyDanychPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView drzewoUstawien;
        private System.Windows.Forms.Button przywrocDomyslneButton;
        private System.Windows.Forms.Button zapiszButton;
        private System.Windows.Forms.Button anulujButton;
        private System.Windows.Forms.Panel folderyPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sciezkaBox;
        private System.Windows.Forms.Panel folderGlownyPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox sciezka2Box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel sortowaniaPanel;
        private System.Windows.Forms.TextBox sposobSortowaniaBox;
        private System.Windows.Forms.Panel domyslneSortowaniaPanel;
        private System.Windows.Forms.Button zmienSposobSortowaniaButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox sposobSortowania2Box;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ustawNowyFolderGlownyButton;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.TextBox nowaSciezkaBox;
        private System.Windows.Forms.Button wybierzNowyFolderGlownyButton;
        private System.Windows.Forms.Panel rozszerzeniaPanel;
        private System.Windows.Forms.TextBox rozszerzeniaBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel wspieranieRozszerzeniaPanel;
        private System.Windows.Forms.Panel zewnetrzneBazyDanychPanel;
        private System.Windows.Forms.Button wybierzBazeButton;
        private System.Windows.Forms.ListBox dataBaseListBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button dodajRozszerzenieButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.FolderBrowserDialog explorer;
        private System.Windows.Forms.ListBox sortowaniaListBox;
        private System.Windows.Forms.CheckBox flacCheckBox;
        private System.Windows.Forms.CheckBox mp3CheckBox;
    }
}