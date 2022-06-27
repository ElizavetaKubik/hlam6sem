
namespace CMSI_lr14
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
            this.originalImage = new System.Windows.Forms.PictureBox();
            this.redImage = new System.Windows.Forms.PictureBox();
            this.greenImage = new System.Windows.Forms.PictureBox();
            this.blueImage = new System.Windows.Forms.PictureBox();
            this.stegOpenFile = new System.Windows.Forms.Button();
            this.colorImage = new System.Windows.Forms.PictureBox();
            this.stegText = new System.Windows.Forms.TextBox();
            this.stegButton = new System.Windows.Forms.Button();
            this.stegImage = new System.Windows.Forms.PictureBox();
            this.deStegImage = new System.Windows.Forms.PictureBox();
            this.deStegOpenFile = new System.Windows.Forms.Button();
            this.deStegText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.originalImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stegImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStegImage)).BeginInit();
            this.SuspendLayout();
            // 
            // originalImage
            // 
            this.originalImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.originalImage.Location = new System.Drawing.Point(13, 32);
            this.originalImage.Margin = new System.Windows.Forms.Padding(2);
            this.originalImage.Name = "originalImage";
            this.originalImage.Size = new System.Drawing.Size(192, 208);
            this.originalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.originalImage.TabIndex = 0;
            this.originalImage.TabStop = false;
            // 
            // redImage
            // 
            this.redImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.redImage.Location = new System.Drawing.Point(217, 32);
            this.redImage.Margin = new System.Windows.Forms.Padding(2);
            this.redImage.Name = "redImage";
            this.redImage.Size = new System.Drawing.Size(192, 208);
            this.redImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.redImage.TabIndex = 1;
            this.redImage.TabStop = false;
            // 
            // greenImage
            // 
            this.greenImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.greenImage.Location = new System.Drawing.Point(421, 32);
            this.greenImage.Margin = new System.Windows.Forms.Padding(2);
            this.greenImage.Name = "greenImage";
            this.greenImage.Size = new System.Drawing.Size(192, 208);
            this.greenImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.greenImage.TabIndex = 2;
            this.greenImage.TabStop = false;
            // 
            // blueImage
            // 
            this.blueImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.blueImage.Location = new System.Drawing.Point(625, 32);
            this.blueImage.Margin = new System.Windows.Forms.Padding(2);
            this.blueImage.Name = "blueImage";
            this.blueImage.Size = new System.Drawing.Size(192, 208);
            this.blueImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.blueImage.TabIndex = 3;
            this.blueImage.TabStop = false;
            // 
            // stegOpenFile
            // 
            this.stegOpenFile.Location = new System.Drawing.Point(11, 253);
            this.stegOpenFile.Margin = new System.Windows.Forms.Padding(2);
            this.stegOpenFile.Name = "stegOpenFile";
            this.stegOpenFile.Size = new System.Drawing.Size(192, 26);
            this.stegOpenFile.TabIndex = 4;
            this.stegOpenFile.Text = "Open File";
            this.stegOpenFile.UseVisualStyleBackColor = true;
            this.stegOpenFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // colorImage
            // 
            this.colorImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorImage.Location = new System.Drawing.Point(829, 32);
            this.colorImage.Margin = new System.Windows.Forms.Padding(2);
            this.colorImage.Name = "colorImage";
            this.colorImage.Size = new System.Drawing.Size(192, 208);
            this.colorImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.colorImage.TabIndex = 5;
            this.colorImage.TabStop = false;
            // 
            // stegText
            // 
            this.stegText.Location = new System.Drawing.Point(216, 273);
            this.stegText.Margin = new System.Windows.Forms.Padding(2);
            this.stegText.Name = "stegText";
            this.stegText.Size = new System.Drawing.Size(805, 20);
            this.stegText.TabIndex = 6;
            // 
            // stegButton
            // 
            this.stegButton.Location = new System.Drawing.Point(216, 297);
            this.stegButton.Margin = new System.Windows.Forms.Padding(2);
            this.stegButton.Name = "stegButton";
            this.stegButton.Size = new System.Drawing.Size(192, 27);
            this.stegButton.TabIndex = 7;
            this.stegButton.Text = "Steganography Text";
            this.stegButton.UseVisualStyleBackColor = true;
            this.stegButton.Click += new System.EventHandler(this.stegButton_Click);
            // 
            // stegImage
            // 
            this.stegImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stegImage.Location = new System.Drawing.Point(1033, 32);
            this.stegImage.Margin = new System.Windows.Forms.Padding(2);
            this.stegImage.Name = "stegImage";
            this.stegImage.Size = new System.Drawing.Size(192, 208);
            this.stegImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.stegImage.TabIndex = 8;
            this.stegImage.TabStop = false;
            this.stegImage.Click += new System.EventHandler(this.stegImage_Click);
            // 
            // deStegImage
            // 
            this.deStegImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.deStegImage.Location = new System.Drawing.Point(11, 381);
            this.deStegImage.Margin = new System.Windows.Forms.Padding(2);
            this.deStegImage.Name = "deStegImage";
            this.deStegImage.Size = new System.Drawing.Size(192, 208);
            this.deStegImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.deStegImage.TabIndex = 9;
            this.deStegImage.TabStop = false;
            // 
            // deStegOpenFile
            // 
            this.deStegOpenFile.Location = new System.Drawing.Point(12, 356);
            this.deStegOpenFile.Margin = new System.Windows.Forms.Padding(2);
            this.deStegOpenFile.Name = "deStegOpenFile";
            this.deStegOpenFile.Size = new System.Drawing.Size(192, 21);
            this.deStegOpenFile.TabIndex = 10;
            this.deStegOpenFile.Text = "Open File";
            this.deStegOpenFile.UseVisualStyleBackColor = true;
            this.deStegOpenFile.Click += new System.EventHandler(this.deStegOpenFile_Click);
            // 
            // deStegText
            // 
            this.deStegText.Location = new System.Drawing.Point(216, 381);
            this.deStegText.Margin = new System.Windows.Forms.Padding(2);
            this.deStegText.Name = "deStegText";
            this.deStegText.Size = new System.Drawing.Size(805, 20);
            this.deStegText.TabIndex = 11;
            this.deStegText.TextChanged += new System.EventHandler(this.deStegText_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Source Imgae";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Low Bits of RED chanel";
            this.label2.UseCompatibleTextRendering = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(458, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Low Bits of GREEN chanel";
            this.label3.UseCompatibleTextRendering = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(652, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Low Bits of BLUE chanel";
            this.label4.UseCompatibleTextRendering = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(861, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Low Bits Mask of all chanels";
            this.label5.UseCompatibleTextRendering = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1086, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Result Imgae";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(1236, 643);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deStegText);
            this.Controls.Add(this.deStegOpenFile);
            this.Controls.Add(this.deStegImage);
            this.Controls.Add(this.stegImage);
            this.Controls.Add(this.stegButton);
            this.Controls.Add(this.stegText);
            this.Controls.Add(this.colorImage);
            this.Controls.Add(this.stegOpenFile);
            this.Controls.Add(this.blueImage);
            this.Controls.Add(this.greenImage);
            this.Controls.Add(this.redImage);
            this.Controls.Add(this.originalImage);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Лабораторная №14 - Исследование стеганографического метода на основе преобразован" +
    "ия наименее значащих бит";
            ((System.ComponentModel.ISupportInitialize)(this.originalImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stegImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStegImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox originalImage;
        private System.Windows.Forms.PictureBox redImage;
        private System.Windows.Forms.PictureBox greenImage;
        private System.Windows.Forms.PictureBox blueImage;
        private System.Windows.Forms.Button stegOpenFile;
        private System.Windows.Forms.PictureBox colorImage;
        private System.Windows.Forms.TextBox stegText;
        private System.Windows.Forms.Button stegButton;
        private System.Windows.Forms.PictureBox stegImage;
        private System.Windows.Forms.PictureBox deStegImage;
        private System.Windows.Forms.Button deStegOpenFile;
        private System.Windows.Forms.TextBox deStegText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

