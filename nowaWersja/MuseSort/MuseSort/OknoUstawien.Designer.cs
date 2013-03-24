namespace MuseSort
{
    partial class OknoUstawien
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Folder główny");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Foldery", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Domyślne ustawienia");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Sortowanie", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Wspierane rozszerzenia");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Rozszerzenia", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Zewnętrzne bazy danych");
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
            this.zmienSposobSortowaniaButton = new System.Windows.Forms.Button();
            this.sposobySortowaniaCheckBox = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.sposobSortowania2Box = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rozszerzeniaPanel = new System.Windows.Forms.Panel();
            this.rozszerzeniaBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.wspieranieRozszerzeniaPanel = new System.Windows.Forms.Panel();
            this.dodajRozszerzenieButton = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.zewnetrzneBazyDanychPanel = new System.Windows.Forms.Panel();
            this.wybierzBazeButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
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
            this.drzewoUstawien.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.drzewoUstawien.Location = new System.Drawing.Point(13, 13);
            this.drzewoUstawien.Name = "drzewoUstawien";
            treeNode1.Name = "folderGlownyNode";
            treeNode1.Text = "Folder główny";
            treeNode2.Name = "folderyNode";
            treeNode2.Text = "Foldery";
            treeNode3.Name = "domyslneSortowanieNode";
            treeNode3.Text = "Domyślne ustawienia";
            treeNode4.Name = "sortowaniaNode";
            treeNode4.Text = "Sortowanie";
            treeNode5.Name = "wspieraneRozszerzeniaNode";
            treeNode5.Text = "Wspierane rozszerzenia";
            treeNode6.Name = "rozszerzeniaNode";
            treeNode6.Text = "Rozszerzenia";
            treeNode7.Name = "bazyDanychNode";
            treeNode7.Text = "Zewnętrzne bazy danych";
            this.drzewoUstawien.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode4,
            treeNode6,
            treeNode7});
            this.drzewoUstawien.Size = new System.Drawing.Size(250, 382);
            this.drzewoUstawien.TabIndex = 0;
            // 
            // przywrocDomyslneButton
            // 
            this.przywrocDomyslneButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.przywrocDomyslneButton.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.przywrocDomyslneButton.ForeColor = System.Drawing.Color.DarkBlue;
            this.przywrocDomyslneButton.Location = new System.Drawing.Point(307, 382);
            this.przywrocDomyslneButton.Name = "przywrocDomyslneButton";
            this.przywrocDomyslneButton.Size = new System.Drawing.Size(137, 29);
            this.przywrocDomyslneButton.TabIndex = 1;
            this.przywrocDomyslneButton.Text = "Przywróć domyślne";
            this.przywrocDomyslneButton.UseVisualStyleBackColor = false;
            // 
            // zapiszButton
            // 
            this.zapiszButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.zapiszButton.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 9F, System.Drawing.FontStyle.Italic);
            this.zapiszButton.ForeColor = System.Drawing.Color.DarkBlue;
            this.zapiszButton.Location = new System.Drawing.Point(450, 382);
            this.zapiszButton.Name = "zapiszButton";
            this.zapiszButton.Size = new System.Drawing.Size(83, 29);
            this.zapiszButton.TabIndex = 2;
            this.zapiszButton.Text = "Zapisz";
            this.zapiszButton.UseVisualStyleBackColor = false;
            // 
            // anulujButton
            // 
            this.anulujButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.anulujButton.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 9F, System.Drawing.FontStyle.Italic);
            this.anulujButton.ForeColor = System.Drawing.Color.DarkBlue;
            this.anulujButton.Location = new System.Drawing.Point(539, 382);
            this.anulujButton.Name = "anulujButton";
            this.anulujButton.Size = new System.Drawing.Size(82, 29);
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
            this.folderyPanel.Location = new System.Drawing.Point(287, 13);
            this.folderyPanel.Name = "folderyPanel";
            this.folderyPanel.Size = new System.Drawing.Size(342, 124);
            this.folderyPanel.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(73, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Aktualny folder główny:";
            // 
            // sciezkaBox
            // 
            this.sciezkaBox.BackColor = System.Drawing.Color.Gray;
            this.sciezkaBox.Enabled = false;
            this.sciezkaBox.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 9F);
            this.sciezkaBox.Location = new System.Drawing.Point(18, 50);
            this.sciezkaBox.Name = "sciezkaBox";
            this.sciezkaBox.Size = new System.Drawing.Size(311, 24);
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
            this.folderGlownyPanel.Location = new System.Drawing.Point(285, 16);
            this.folderGlownyPanel.Name = "folderGlownyPanel";
            this.folderGlownyPanel.Size = new System.Drawing.Size(344, 228);
            this.folderGlownyPanel.TabIndex = 5;
            // 
            // ustawNowyFolderGlownyButton
            // 
            this.ustawNowyFolderGlownyButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ustawNowyFolderGlownyButton.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 9F, System.Drawing.FontStyle.Italic);
            this.ustawNowyFolderGlownyButton.ForeColor = System.Drawing.Color.DarkBlue;
            this.ustawNowyFolderGlownyButton.Location = new System.Drawing.Point(101, 194);
            this.ustawNowyFolderGlownyButton.Name = "ustawNowyFolderGlownyButton";
            this.ustawNowyFolderGlownyButton.Size = new System.Drawing.Size(177, 31);
            this.ustawNowyFolderGlownyButton.TabIndex = 9;
            this.ustawNowyFolderGlownyButton.Text = "Ustaw nowy folder główny";
            this.ustawNowyFolderGlownyButton.UseVisualStyleBackColor = false;
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 9F);
            this.checkBox.ForeColor = System.Drawing.Color.White;
            this.checkBox.Location = new System.Drawing.Point(15, 165);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(289, 22);
            this.checkBox.TabIndex = 8;
            this.checkBox.Text = "Przenieś foldery do nowego folderu głównego";
            this.checkBox.UseVisualStyleBackColor = true;
            // 
            // nowaSciezkaBox
            // 
            this.nowaSciezkaBox.BackColor = System.Drawing.Color.Gray;
            this.nowaSciezkaBox.Enabled = false;
            this.nowaSciezkaBox.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 9F);
            this.nowaSciezkaBox.Location = new System.Drawing.Point(18, 122);
            this.nowaSciezkaBox.Name = "nowaSciezkaBox";
            this.nowaSciezkaBox.Size = new System.Drawing.Size(311, 24);
            this.nowaSciezkaBox.TabIndex = 7;
            // 
            // wybierzNowyFolderGlownyButton
            // 
            this.wybierzNowyFolderGlownyButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.wybierzNowyFolderGlownyButton.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 9F);
            this.wybierzNowyFolderGlownyButton.ForeColor = System.Drawing.Color.DarkBlue;
            this.wybierzNowyFolderGlownyButton.Location = new System.Drawing.Point(215, 80);
            this.wybierzNowyFolderGlownyButton.Name = "wybierzNowyFolderGlownyButton";
            this.wybierzNowyFolderGlownyButton.Size = new System.Drawing.Size(53, 23);
            this.wybierzNowyFolderGlownyButton.TabIndex = 6;
            this.wybierzNowyFolderGlownyButton.Text = "...";
            this.wybierzNowyFolderGlownyButton.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 9F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(15, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Wybierz nowy folder główny:";
            // 
            // sciezka2Box
            // 
            this.sciezka2Box.BackColor = System.Drawing.Color.Gray;
            this.sciezka2Box.Enabled = false;
            this.sciezka2Box.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 9F);
            this.sciezka2Box.Location = new System.Drawing.Point(15, 39);
            this.sciezka2Box.Name = "sciezka2Box";
            this.sciezka2Box.Size = new System.Drawing.Size(311, 24);
            this.sciezka2Box.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(85, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Aktualny folder główny:";
            // 
            // sortowaniaPanel
            // 
            this.sortowaniaPanel.BackColor = System.Drawing.Color.Transparent;
            this.sortowaniaPanel.Controls.Add(this.sposobSortowaniaBox);
            this.sortowaniaPanel.Controls.Add(this.label4);
            this.sortowaniaPanel.Location = new System.Drawing.Point(269, 5);
            this.sortowaniaPanel.Name = "sortowaniaPanel";
            this.sortowaniaPanel.Size = new System.Drawing.Size(342, 302);
            this.sortowaniaPanel.TabIndex = 6;
            // 
            // sposobSortowaniaBox
            // 
            this.sposobSortowaniaBox.BackColor = System.Drawing.Color.Gray;
            this.sposobSortowaniaBox.Enabled = false;
            this.sposobSortowaniaBox.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 9F);
            this.sposobSortowaniaBox.Location = new System.Drawing.Point(27, 66);
            this.sposobSortowaniaBox.Name = "sposobSortowaniaBox";
            this.sposobSortowaniaBox.Size = new System.Drawing.Size(275, 24);
            this.sposobSortowaniaBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 9F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(73, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Aktualny sposób sortowania:";
            // 
            // domyslneSortowaniaPanel
            // 
            this.domyslneSortowaniaPanel.BackColor = System.Drawing.Color.Transparent;
            this.domyslneSortowaniaPanel.Controls.Add(this.zmienSposobSortowaniaButton);
            this.domyslneSortowaniaPanel.Controls.Add(this.sposobySortowaniaCheckBox);
            this.domyslneSortowaniaPanel.Controls.Add(this.label6);
            this.domyslneSortowaniaPanel.Controls.Add(this.sposobSortowania2Box);
            this.domyslneSortowaniaPanel.Controls.Add(this.label5);
            this.domyslneSortowaniaPanel.Location = new System.Drawing.Point(279, 19);
            this.domyslneSortowaniaPanel.Name = "domyslneSortowaniaPanel";
            this.domyslneSortowaniaPanel.Size = new System.Drawing.Size(342, 332);
            this.domyslneSortowaniaPanel.TabIndex = 6;
            // 
            // zmienSposobSortowaniaButton
            // 
            this.zmienSposobSortowaniaButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.zmienSposobSortowaniaButton.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 9F, System.Drawing.FontStyle.Italic);
            this.zmienSposobSortowaniaButton.ForeColor = System.Drawing.Color.DarkBlue;
            this.zmienSposobSortowaniaButton.Location = new System.Drawing.Point(76, 262);
            this.zmienSposobSortowaniaButton.Name = "zmienSposobSortowaniaButton";
            this.zmienSposobSortowaniaButton.Size = new System.Drawing.Size(197, 34);
            this.zmienSposobSortowaniaButton.TabIndex = 9;
            this.zmienSposobSortowaniaButton.Text = "Zmień sposób sortowania";
            this.zmienSposobSortowaniaButton.UseVisualStyleBackColor = false;
            // 
            // sposobySortowaniaCheckBox
            // 
            this.sposobySortowaniaCheckBox.FormattingEnabled = true;
            this.sposobySortowaniaCheckBox.Location = new System.Drawing.Point(108, 120);
            this.sposobySortowaniaCheckBox.Name = "sposobySortowaniaCheckBox";
            this.sposobySortowaniaCheckBox.Size = new System.Drawing.Size(120, 89);
            this.sposobySortowaniaCheckBox.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 9F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(78, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(198, 18);
            this.label6.TabIndex = 7;
            this.label6.Text = "Wybierz inny sposób sortowania:";
            // 
            // sposobSortowania2Box
            // 
            this.sposobSortowania2Box.BackColor = System.Drawing.Color.Gray;
            this.sposobSortowania2Box.Enabled = false;
            this.sposobSortowania2Box.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 9F);
            this.sposobSortowania2Box.Location = new System.Drawing.Point(31, 55);
            this.sposobSortowania2Box.Name = "sposobSortowania2Box";
            this.sposobSortowania2Box.Size = new System.Drawing.Size(281, 24);
            this.sposobSortowania2Box.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 9F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(83, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 18);
            this.label5.TabIndex = 1;
            this.label5.Text = "Aktualny sposób sortowania:";
            // 
            // rozszerzeniaPanel
            // 
            this.rozszerzeniaPanel.BackColor = System.Drawing.Color.Transparent;
            this.rozszerzeniaPanel.Controls.Add(this.rozszerzeniaBox);
            this.rozszerzeniaPanel.Controls.Add(this.label7);
            this.rozszerzeniaPanel.Location = new System.Drawing.Point(279, 16);
            this.rozszerzeniaPanel.Name = "rozszerzeniaPanel";
            this.rozszerzeniaPanel.Size = new System.Drawing.Size(364, 343);
            this.rozszerzeniaPanel.TabIndex = 7;
            // 
            // rozszerzeniaBox
            // 
            this.rozszerzeniaBox.BackColor = System.Drawing.Color.Gray;
            this.rozszerzeniaBox.Enabled = false;
            this.rozszerzeniaBox.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 9F);
            this.rozszerzeniaBox.Location = new System.Drawing.Point(14, 72);
            this.rozszerzeniaBox.Name = "rozszerzeniaBox";
            this.rozszerzeniaBox.Size = new System.Drawing.Size(275, 24);
            this.rozszerzeniaBox.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 9F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(73, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 18);
            this.label7.TabIndex = 0;
            this.label7.Text = "Obsługiwane rozszerzenia";
            // 
            // wspieranieRozszerzeniaPanel
            // 
            this.wspieranieRozszerzeniaPanel.BackColor = System.Drawing.Color.Transparent;
            this.wspieranieRozszerzeniaPanel.Controls.Add(this.dodajRozszerzenieButton);
            this.wspieranieRozszerzeniaPanel.Controls.Add(this.textBox2);
            this.wspieranieRozszerzeniaPanel.Controls.Add(this.label9);
            this.wspieranieRozszerzeniaPanel.Controls.Add(this.textBox1);
            this.wspieranieRozszerzeniaPanel.Controls.Add(this.label8);
            this.wspieranieRozszerzeniaPanel.Location = new System.Drawing.Point(282, 16);
            this.wspieranieRozszerzeniaPanel.Name = "wspieranieRozszerzeniaPanel";
            this.wspieranieRozszerzeniaPanel.Size = new System.Drawing.Size(361, 340);
            this.wspieranieRozszerzeniaPanel.TabIndex = 8;
            // 
            // dodajRozszerzenieButton
            // 
            this.dodajRozszerzenieButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dodajRozszerzenieButton.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 9F, System.Drawing.FontStyle.Italic);
            this.dodajRozszerzenieButton.ForeColor = System.Drawing.Color.DarkBlue;
            this.dodajRozszerzenieButton.Location = new System.Drawing.Point(25, 151);
            this.dodajRozszerzenieButton.Name = "dodajRozszerzenieButton";
            this.dodajRozszerzenieButton.Size = new System.Drawing.Size(163, 39);
            this.dodajRozszerzenieButton.TabIndex = 10;
            this.dodajRozszerzenieButton.Text = "Dodaj nowe rozszerzenie";
            this.dodajRozszerzenieButton.UseVisualStyleBackColor = false;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 9F);
            this.textBox2.Location = new System.Drawing.Point(85, 107);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 24);
            this.textBox2.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 9F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(22, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 18);
            this.label9.TabIndex = 8;
            this.label9.Text = "Nowe rozszerzenie:";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Gray;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 9F);
            this.textBox1.Location = new System.Drawing.Point(34, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(275, 24);
            this.textBox1.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 9F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(19, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 18);
            this.label8.TabIndex = 1;
            this.label8.Text = "Obsługiwane rozszerzenia";
            // 
            // zewnetrzneBazyDanychPanel
            // 
            this.zewnetrzneBazyDanychPanel.BackColor = System.Drawing.Color.Transparent;
            this.zewnetrzneBazyDanychPanel.Controls.Add(this.wybierzBazeButton);
            this.zewnetrzneBazyDanychPanel.Controls.Add(this.listBox1);
            this.zewnetrzneBazyDanychPanel.Controls.Add(this.label10);
            this.zewnetrzneBazyDanychPanel.Location = new System.Drawing.Point(269, 5);
            this.zewnetrzneBazyDanychPanel.Name = "zewnetrzneBazyDanychPanel";
            this.zewnetrzneBazyDanychPanel.Size = new System.Drawing.Size(364, 343);
            this.zewnetrzneBazyDanychPanel.TabIndex = 9;
            // 
            // wybierzBazeButton
            // 
            this.wybierzBazeButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.wybierzBazeButton.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 9F, System.Drawing.FontStyle.Italic);
            this.wybierzBazeButton.ForeColor = System.Drawing.Color.DarkBlue;
            this.wybierzBazeButton.Location = new System.Drawing.Point(104, 252);
            this.wybierzBazeButton.Name = "wybierzBazeButton";
            this.wybierzBazeButton.Size = new System.Drawing.Size(109, 47);
            this.wybierzBazeButton.TabIndex = 2;
            this.wybierzBazeButton.Text = "Wybierz bazę";
            this.wybierzBazeButton.UseVisualStyleBackColor = false;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(145, 85);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 84);
            this.listBox1.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 9F);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(119, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 18);
            this.label10.TabIndex = 0;
            this.label10.Text = "Wybierz bazę danych:";
            // 
            // OknoUstawien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MuseSort.Properties.Resources.tlo;
            this.ClientSize = new System.Drawing.Size(658, 423);
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
        private System.Windows.Forms.CheckedListBox sposobySortowaniaCheckBox;
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
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button dodajRozszerzenieButton;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
    }
}