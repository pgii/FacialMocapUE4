namespace FacialMocapSender
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows

        private void InitializeComponent()
        {
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chbShowLineOnly = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEyeBlinkRight = new System.Windows.Forms.Button();
            this.btnEyeBlinkLeft = new System.Windows.Forms.Button();
            this.btnBrowUpCalib = new System.Windows.Forms.Button();
            this.btnMouthSmileCalib = new System.Windows.Forms.Button();
            this.btnMouthOpenCalib = new System.Windows.Forms.Button();
            this.btnMouthNormalCalib = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxImage.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxImage.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(572, 457);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxImage.TabIndex = 3;
            this.pictureBoxImage.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chbShowLineOnly);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(572, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(282, 457);
            this.panel1.TabIndex = 5;
            // 
            // chbShowLineOnly
            // 
            this.chbShowLineOnly.AutoSize = true;
            this.chbShowLineOnly.Checked = true;
            this.chbShowLineOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbShowLineOnly.Location = new System.Drawing.Point(13, 188);
            this.chbShowLineOnly.Name = "chbShowLineOnly";
            this.chbShowLineOnly.Size = new System.Drawing.Size(120, 21);
            this.chbShowLineOnly.TabIndex = 2;
            this.chbShowLineOnly.Text = "Show line only";
            this.chbShowLineOnly.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEyeBlinkRight);
            this.groupBox1.Controls.Add(this.btnEyeBlinkLeft);
            this.groupBox1.Controls.Add(this.btnBrowUpCalib);
            this.groupBox1.Controls.Add(this.btnMouthSmileCalib);
            this.groupBox1.Controls.Add(this.btnMouthOpenCalib);
            this.groupBox1.Controls.Add(this.btnMouthNormalCalib);
            this.groupBox1.Location = new System.Drawing.Point(7, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 169);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Calibration";
            // 
            // btnEyeBlinkRight
            // 
            this.btnEyeBlinkRight.Location = new System.Drawing.Point(136, 129);
            this.btnEyeBlinkRight.Name = "btnEyeBlinkRight";
            this.btnEyeBlinkRight.Size = new System.Drawing.Size(124, 30);
            this.btnEyeBlinkRight.TabIndex = 5;
            this.btnEyeBlinkRight.Text = "Eye blink right";
            this.btnEyeBlinkRight.UseVisualStyleBackColor = true;
            this.btnEyeBlinkRight.Click += new System.EventHandler(this.btnEyeBlinkRight_Click);
            // 
            // btnEyeBlinkLeft
            // 
            this.btnEyeBlinkLeft.Location = new System.Drawing.Point(6, 129);
            this.btnEyeBlinkLeft.Name = "btnEyeBlinkLeft";
            this.btnEyeBlinkLeft.Size = new System.Drawing.Size(124, 30);
            this.btnEyeBlinkLeft.TabIndex = 4;
            this.btnEyeBlinkLeft.Text = "Eye blink left";
            this.btnEyeBlinkLeft.UseVisualStyleBackColor = true;
            this.btnEyeBlinkLeft.Click += new System.EventHandler(this.btnEyeBlinkLeft_Click);
            // 
            // btnBrowUpCalib
            // 
            this.btnBrowUpCalib.Location = new System.Drawing.Point(70, 93);
            this.btnBrowUpCalib.Name = "btnBrowUpCalib";
            this.btnBrowUpCalib.Size = new System.Drawing.Size(124, 30);
            this.btnBrowUpCalib.TabIndex = 3;
            this.btnBrowUpCalib.Text = "Brow up";
            this.btnBrowUpCalib.UseVisualStyleBackColor = true;
            this.btnBrowUpCalib.Click += new System.EventHandler(this.btnBrowUpCalib_Click);
            // 
            // btnMouthSmileCalib
            // 
            this.btnMouthSmileCalib.Location = new System.Drawing.Point(136, 57);
            this.btnMouthSmileCalib.Name = "btnMouthSmileCalib";
            this.btnMouthSmileCalib.Size = new System.Drawing.Size(124, 30);
            this.btnMouthSmileCalib.TabIndex = 2;
            this.btnMouthSmileCalib.Text = "Smile";
            this.btnMouthSmileCalib.UseVisualStyleBackColor = true;
            this.btnMouthSmileCalib.Click += new System.EventHandler(this.btnMouthSmileCalib_Click);
            // 
            // btnMouthOpenCalib
            // 
            this.btnMouthOpenCalib.Location = new System.Drawing.Point(6, 57);
            this.btnMouthOpenCalib.Name = "btnMouthOpenCalib";
            this.btnMouthOpenCalib.Size = new System.Drawing.Size(124, 30);
            this.btnMouthOpenCalib.TabIndex = 1;
            this.btnMouthOpenCalib.Text = "Open";
            this.btnMouthOpenCalib.UseVisualStyleBackColor = true;
            this.btnMouthOpenCalib.Click += new System.EventHandler(this.btnMouthOpenCalib_Click);
            // 
            // btnMouthNormalCalib
            // 
            this.btnMouthNormalCalib.Location = new System.Drawing.Point(70, 21);
            this.btnMouthNormalCalib.Name = "btnMouthNormalCalib";
            this.btnMouthNormalCalib.Size = new System.Drawing.Size(124, 30);
            this.btnMouthNormalCalib.TabIndex = 0;
            this.btnMouthNormalCalib.Text = "Normal";
            this.btnMouthNormalCalib.UseVisualStyleBackColor = true;
            this.btnMouthNormalCalib.Click += new System.EventHandler(this.btnMouthNormalCalib_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 457);
            this.Controls.Add(this.pictureBoxImage);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "FacialMocapSender";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnMouthNormalCalib;
        private System.Windows.Forms.Button btnMouthSmileCalib;
        private System.Windows.Forms.Button btnMouthOpenCalib;
        private System.Windows.Forms.Button btnBrowUpCalib;
        private System.Windows.Forms.Button btnEyeBlinkRight;
        private System.Windows.Forms.Button btnEyeBlinkLeft;
        private System.Windows.Forms.CheckBox chbShowLineOnly;
    }
}

