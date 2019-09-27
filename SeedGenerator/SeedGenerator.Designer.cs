namespace SeedGenerator
{
    partial class SeedGenerator
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
            this.lblInfo = new System.Windows.Forms.Label();
            this.btStart = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbEnt = new System.Windows.Forms.TextBox();
            this.tbSalt = new System.Windows.Forms.TextBox();
            this.tbSeed = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMnemonic = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ddIle = new System.Windows.Forms.ComboBox();
            this.btRestart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(16, 13);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(593, 17);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Przygotuj talię 52 kart i potasuj ją co najmniej 7x metodą \"riffle shuffle\". Mnem" +
    "onic na ile słów:";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(670, 7);
            this.btStart.Margin = new System.Windows.Forms.Padding(4);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(100, 28);
            this.btStart.TabIndex = 1;
            this.btStart.Text = "Zaczynamy";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.BtStart_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(16, 41);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1071, 538);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 590);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "entropia:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 622);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "salt:";
            // 
            // tbEnt
            // 
            this.tbEnt.Location = new System.Drawing.Point(88, 586);
            this.tbEnt.Margin = new System.Windows.Forms.Padding(4);
            this.tbEnt.Name = "tbEnt";
            this.tbEnt.Size = new System.Drawing.Size(997, 22);
            this.tbEnt.TabIndex = 5;
            this.tbEnt.Click += new System.EventHandler(this.CopyOn_Click);
            // 
            // tbSalt
            // 
            this.tbSalt.Location = new System.Drawing.Point(88, 618);
            this.tbSalt.Margin = new System.Windows.Forms.Padding(4);
            this.tbSalt.Name = "tbSalt";
            this.tbSalt.Size = new System.Drawing.Size(997, 22);
            this.tbSalt.TabIndex = 6;
            this.tbSalt.Click += new System.EventHandler(this.CopyOn_Click);
            // 
            // tbSeed
            // 
            this.tbSeed.Location = new System.Drawing.Point(88, 650);
            this.tbSeed.Margin = new System.Windows.Forms.Padding(4);
            this.tbSeed.Name = "tbSeed";
            this.tbSeed.Size = new System.Drawing.Size(997, 22);
            this.tbSeed.TabIndex = 7;
            this.tbSeed.Click += new System.EventHandler(this.CopyOn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 654);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "seed:";
            // 
            // tbMnemonic
            // 
            this.tbMnemonic.Location = new System.Drawing.Point(101, 682);
            this.tbMnemonic.Margin = new System.Windows.Forms.Padding(4);
            this.tbMnemonic.Multiline = true;
            this.tbMnemonic.Name = "tbMnemonic";
            this.tbMnemonic.Size = new System.Drawing.Size(984, 66);
            this.tbMnemonic.TabIndex = 9;
            this.tbMnemonic.Click += new System.EventHandler(this.CopyOn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 686);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "mnemonic:";
            // 
            // ddIle
            // 
            this.ddIle.FormattingEnabled = true;
            this.ddIle.Items.AddRange(new object[] {
            "12",
            "15",
            "18",
            "21",
            "24"});
            this.ddIle.Location = new System.Drawing.Point(614, 9);
            this.ddIle.Margin = new System.Windows.Forms.Padding(4);
            this.ddIle.Name = "ddIle";
            this.ddIle.Size = new System.Drawing.Size(48, 24);
            this.ddIle.TabIndex = 11;
            // 
            // btRestart
            // 
            this.btRestart.Location = new System.Drawing.Point(995, 7);
            this.btRestart.Margin = new System.Windows.Forms.Padding(4);
            this.btRestart.Name = "btRestart";
            this.btRestart.Size = new System.Drawing.Size(92, 28);
            this.btRestart.TabIndex = 12;
            this.btRestart.Text = "Restart";
            this.btRestart.UseVisualStyleBackColor = true;
            this.btRestart.Click += new System.EventHandler(this.BtRestart_Click);
            // 
            // SeedGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 763);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.ddIle);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btRestart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbMnemonic);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbSeed);
            this.Controls.Add(this.tbSalt);
            this.Controls.Add(this.tbEnt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SeedGenerator";
            this.Text = "rav3n_pl SeedGenerator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbEnt;
        private System.Windows.Forms.TextBox tbSalt;
        private System.Windows.Forms.TextBox tbSeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMnemonic;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ddIle;
        private System.Windows.Forms.Button btRestart;
    }
}

