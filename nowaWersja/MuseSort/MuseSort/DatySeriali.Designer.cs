namespace MuseSort
{
    partial class DatySeriali
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.odBox = new System.Windows.Forms.TextBox();
            this.doBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.edytujButton = new System.Windows.Forms.Button();
            this.anulujButton = new System.Windows.Forms.Button();
            this.tabela = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tabela)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tw Cen MT Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(284, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(442, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seriale według interesujących Cię dat";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tw Cen MT Condensed", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(33, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(284, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Podaj interesujące Cię daty:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tw Cen MT Condensed", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(339, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "OD";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tw Cen MT Condensed", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(559, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 32);
            this.label4.TabIndex = 3;
            this.label4.Text = "DO";
            // 
            // odBox
            // 
            this.odBox.Location = new System.Drawing.Point(407, 98);
            this.odBox.Name = "odBox";
            this.odBox.Size = new System.Drawing.Size(100, 22);
            this.odBox.TabIndex = 4;
            // 
            // doBox
            // 
            this.doBox.Location = new System.Drawing.Point(640, 99);
            this.doBox.Name = "doBox";
            this.doBox.Size = new System.Drawing.Size(100, 22);
            this.doBox.TabIndex = 5;
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.Color.Blue;
            this.okButton.Font = new System.Drawing.Font("Tw Cen MT Condensed", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.okButton.Location = new System.Drawing.Point(820, 97);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(82, 48);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // edytujButton
            // 
            this.edytujButton.BackColor = System.Drawing.Color.Blue;
            this.edytujButton.Font = new System.Drawing.Font("Tw Cen MT Condensed", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.edytujButton.Location = new System.Drawing.Point(972, 270);
            this.edytujButton.Name = "edytujButton";
            this.edytujButton.Size = new System.Drawing.Size(98, 103);
            this.edytujButton.TabIndex = 7;
            this.edytujButton.Text = "Edytuj daty";
            this.edytujButton.UseVisualStyleBackColor = false;
            this.edytujButton.Click += new System.EventHandler(this.edytujButton_Click);
            // 
            // anulujButton
            // 
            this.anulujButton.BackColor = System.Drawing.Color.Red;
            this.anulujButton.Font = new System.Drawing.Font("Tw Cen MT Condensed", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.anulujButton.Location = new System.Drawing.Point(945, 12);
            this.anulujButton.Name = "anulujButton";
            this.anulujButton.Size = new System.Drawing.Size(125, 48);
            this.anulujButton.TabIndex = 8;
            this.anulujButton.Text = "Anuluj";
            this.anulujButton.UseVisualStyleBackColor = false;
            this.anulujButton.Click += new System.EventHandler(this.anulujButton_Click);
            // 
            // tabela
            // 
            this.tabela.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tabela.BackgroundColor = System.Drawing.SystemColors.Highlight;
            this.tabela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabela.GridColor = System.Drawing.SystemColors.MenuHighlight;
            this.tabela.Location = new System.Drawing.Point(12, 151);
            this.tabela.Name = "tabela";
            this.tabela.RowTemplate.Height = 24;
            this.tabela.Size = new System.Drawing.Size(944, 413);
            this.tabela.TabIndex = 9;
            // 
            // DatySeriali
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MuseSort.Properties.Resources.tlo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1082, 566);
            this.Controls.Add(this.tabela);
            this.Controls.Add(this.anulujButton);
            this.Controls.Add(this.edytujButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.doBox);
            this.Controls.Add(this.odBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DatySeriali";
            this.Text = "DatySeriali";
            ((System.ComponentModel.ISupportInitialize)(this.tabela)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox odBox;
        private System.Windows.Forms.TextBox doBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button edytujButton;
        private System.Windows.Forms.Button anulujButton;
        private System.Windows.Forms.DataGridView tabela;
    }
}