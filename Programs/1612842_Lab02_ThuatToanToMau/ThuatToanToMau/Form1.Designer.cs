namespace ThuatToanToMau
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox_thuatToanToMau = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox_colorFill = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox_colorOutline = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonFill = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonEllipse = new System.Windows.Forms.RadioButton();
            this.radioButtonCircle = new System.Windows.Forms.RadioButton();
            this.radioButtonPolygon = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_colorFill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_colorOutline)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonHelp);
            this.panel1.Controls.Add(this.comboBox_thuatToanToMau);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.pictureBox_colorFill);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pictureBox_colorOutline);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(837, 58);
            this.panel1.TabIndex = 0;
            // 
            // comboBox_thuatToanToMau
            // 
            this.comboBox_thuatToanToMau.FormattingEnabled = true;
            this.comboBox_thuatToanToMau.Location = new System.Drawing.Point(172, 16);
            this.comboBox_thuatToanToMau.Name = "comboBox_thuatToanToMau";
            this.comboBox_thuatToanToMau.Size = new System.Drawing.Size(193, 21);
            this.comboBox_thuatToanToMau.TabIndex = 5;
            this.comboBox_thuatToanToMau.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Chọn thuật toán tô màu";
            // 
            // pictureBox_colorFill
            // 
            this.pictureBox_colorFill.BackColor = System.Drawing.Color.Red;
            this.pictureBox_colorFill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_colorFill.Location = new System.Drawing.Point(595, 12);
            this.pictureBox_colorFill.Name = "pictureBox_colorFill";
            this.pictureBox_colorFill.Size = new System.Drawing.Size(34, 33);
            this.pictureBox_colorFill.TabIndex = 3;
            this.pictureBox_colorFill.TabStop = false;
            this.pictureBox_colorFill.Click += new System.EventHandler(this.pictureBox_colorFill_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(546, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Màu tô";
            // 
            // pictureBox_colorOutline
            // 
            this.pictureBox_colorOutline.BackColor = System.Drawing.Color.Blue;
            this.pictureBox_colorOutline.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_colorOutline.Location = new System.Drawing.Point(484, 12);
            this.pictureBox_colorOutline.Name = "pictureBox_colorOutline";
            this.pictureBox_colorOutline.Size = new System.Drawing.Size(34, 33);
            this.pictureBox_colorOutline.TabIndex = 1;
            this.pictureBox_colorOutline.TabStop = false;
            this.pictureBox_colorOutline.Click += new System.EventHandler(this.pictureBox_colorOutline_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(414, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Màu nét vẽ";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.buttonFill);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(98, 450);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // buttonFill
            // 
            this.buttonFill.Location = new System.Drawing.Point(10, 135);
            this.buttonFill.Name = "buttonFill";
            this.buttonFill.Size = new System.Drawing.Size(75, 41);
            this.buttonFill.TabIndex = 100;
            this.buttonFill.Text = "Tô màu";
            this.buttonFill.UseVisualStyleBackColor = true;
            this.buttonFill.Click += new System.EventHandler(this.buttonFill_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonEllipse);
            this.groupBox1.Controls.Add(this.radioButtonCircle);
            this.groupBox1.Controls.Add(this.radioButtonPolygon);
            this.groupBox1.Location = new System.Drawing.Point(-2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(98, 105);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn hình vẽ";
            // 
            // radioButtonEllipse
            // 
            this.radioButtonEllipse.AutoSize = true;
            this.radioButtonEllipse.Location = new System.Drawing.Point(13, 77);
            this.radioButtonEllipse.Name = "radioButtonEllipse";
            this.radioButtonEllipse.Size = new System.Drawing.Size(55, 17);
            this.radioButtonEllipse.TabIndex = 2;
            this.radioButtonEllipse.Text = "Ellipse";
            this.radioButtonEllipse.UseVisualStyleBackColor = true;
            this.radioButtonEllipse.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButtonCircle
            // 
            this.radioButtonCircle.AutoSize = true;
            this.radioButtonCircle.Location = new System.Drawing.Point(13, 46);
            this.radioButtonCircle.Name = "radioButtonCircle";
            this.radioButtonCircle.Size = new System.Drawing.Size(68, 17);
            this.radioButtonCircle.TabIndex = 1;
            this.radioButtonCircle.Text = "Hình tròn";
            this.radioButtonCircle.UseVisualStyleBackColor = true;
            // 
            // radioButtonPolygon
            // 
            this.radioButtonPolygon.AutoSize = true;
            this.radioButtonPolygon.Location = new System.Drawing.Point(13, 19);
            this.radioButtonPolygon.Name = "radioButtonPolygon";
            this.radioButtonPolygon.Size = new System.Drawing.Size(62, 17);
            this.radioButtonPolygon.TabIndex = 0;
            this.radioButtonPolygon.Text = "Đa giác";
            this.radioButtonPolygon.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(98, 58);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(739, 450);
            this.panel3.TabIndex = 2;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(739, 447);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Location = new System.Drawing.Point(750, 12);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(75, 33);
            this.buttonHelp.TabIndex = 101;
            this.buttonHelp.Text = "Hướng dẫn";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 508);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Tô Màu";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_colorFill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_colorOutline)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.PictureBox pictureBox_colorFill;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox_colorOutline;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_thuatToanToMau;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonCircle;
        private System.Windows.Forms.RadioButton radioButtonPolygon;
        private System.Windows.Forms.RadioButton radioButtonEllipse;
        private System.Windows.Forms.Button buttonFill;
        private System.Windows.Forms.Button buttonHelp;
    }
}

