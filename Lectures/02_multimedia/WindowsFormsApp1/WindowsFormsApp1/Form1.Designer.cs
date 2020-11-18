namespace WindowsFormsApp1
{
    partial class Form1
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
            this.btnConnection = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbId = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.tbIdAfisare = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnGenerateSignature = new System.Windows.Forms.Button();
            this.tbIdFind = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSemanticSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnection
            // 
            this.btnConnection.Location = new System.Drawing.Point(564, 12);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(145, 49);
            this.btnConnection.TabIndex = 0;
            this.btnConnection.Text = "Connection";
            this.btnConnection.UseVisualStyleBackColor = true;
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID:";
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(83, 75);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(144, 20);
            this.tbId.TabIndex = 2;
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(83, 112);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(144, 20);
            this.tbDescription.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Description:";
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(83, 153);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(144, 20);
            this.tbFileName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "File name:";
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(286, 112);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(123, 57);
            this.btnInsert.TabIndex = 7;
            this.btnInsert.Text = "Insert image";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // tbIdAfisare
            // 
            this.tbIdAfisare.Location = new System.Drawing.Point(122, 266);
            this.tbIdAfisare.Name = "tbIdAfisare";
            this.tbIdAfisare.Size = new System.Drawing.Size(144, 20);
            this.tbIdAfisare.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Display picture by id:";
            // 
            // btnDisplay
            // 
            this.btnDisplay.Location = new System.Drawing.Point(286, 254);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(123, 43);
            this.btnDisplay.TabIndex = 10;
            this.btnDisplay.Text = "Display Image";
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(438, 187);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(245, 190);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // btnGenerateSignature
            // 
            this.btnGenerateSignature.Location = new System.Drawing.Point(286, 372);
            this.btnGenerateSignature.Name = "btnGenerateSignature";
            this.btnGenerateSignature.Size = new System.Drawing.Size(123, 50);
            this.btnGenerateSignature.TabIndex = 12;
            this.btnGenerateSignature.Text = "Generate Signature";
            this.btnGenerateSignature.UseVisualStyleBackColor = true;
            this.btnGenerateSignature.Click += new System.EventHandler(this.btnGenerateSignature_Click);
            // 
            // tbIdFind
            // 
            this.tbIdFind.Location = new System.Drawing.Point(83, 422);
            this.tbIdFind.Name = "tbIdFind";
            this.tbIdFind.Size = new System.Drawing.Size(144, 20);
            this.tbIdFind.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 429);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Color coef:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(83, 388);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(144, 20);
            this.textBox1.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 391);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "File name:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(83, 460);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(144, 20);
            this.textBox2.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 463);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Texture coef:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(83, 492);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(144, 20);
            this.textBox3.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 495);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Shape coef:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(83, 553);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(144, 20);
            this.textBox4.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 556);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Result ID:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(83, 518);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(144, 20);
            this.textBox5.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 521);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Location coef:";
            // 
            // btnSemanticSearch
            // 
            this.btnSemanticSearch.Location = new System.Drawing.Point(298, 521);
            this.btnSemanticSearch.Name = "btnSemanticSearch";
            this.btnSemanticSearch.Size = new System.Drawing.Size(111, 48);
            this.btnSemanticSearch.TabIndex = 25;
            this.btnSemanticSearch.Text = "Semantic Search";
            this.btnSemanticSearch.UseVisualStyleBackColor = true;
            this.btnSemanticSearch.Click += new System.EventHandler(this.btnSemanticSearch_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 676);
            this.Controls.Add(this.btnSemanticSearch);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbIdFind);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnGenerateSignature);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnDisplay);
            this.Controls.Add(this.tbIdAfisare);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConnection);
            this.Name = "Form1";
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.TextBox tbIdAfisare;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnGenerateSignature;
        private System.Windows.Forms.TextBox tbIdFind;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSemanticSearch;
    }
}

