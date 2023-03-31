namespace Face_Recongnition_ID
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
            this.picCapture = new System.Windows.Forms.PictureBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnDetectface = new System.Windows.Forms.Button();
            this.btnAddperson = new System.Windows.Forms.Button();
            this.btnTrainImages = new System.Windows.Forms.Button();
            this.btnRecongnizeperson = new System.Windows.Forms.Button();
            this.txtPersonName = new System.Windows.Forms.TextBox();
            this.picDetection = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSearchImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDetection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // picCapture
            // 
            this.picCapture.Location = new System.Drawing.Point(4, 4);
            this.picCapture.Name = "picCapture";
            this.picCapture.Size = new System.Drawing.Size(588, 460);
            this.picCapture.TabIndex = 0;
            this.picCapture.TabStop = false;
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(619, 4);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(169, 23);
            this.btnCapture.TabIndex = 1;
            this.btnCapture.Text = "1.Capture";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // btnDetectface
            // 
            this.btnDetectface.Location = new System.Drawing.Point(619, 33);
            this.btnDetectface.Name = "btnDetectface";
            this.btnDetectface.Size = new System.Drawing.Size(169, 23);
            this.btnDetectface.TabIndex = 2;
            this.btnDetectface.Text = "2.Detect Faces";
            this.btnDetectface.UseVisualStyleBackColor = true;
            this.btnDetectface.Click += new System.EventHandler(this.btnDetectface_Click);
            // 
            // btnAddperson
            // 
            this.btnAddperson.Location = new System.Drawing.Point(619, 62);
            this.btnAddperson.Name = "btnAddperson";
            this.btnAddperson.Size = new System.Drawing.Size(169, 23);
            this.btnAddperson.TabIndex = 3;
            this.btnAddperson.Text = "3.Add Person";
            this.btnAddperson.UseVisualStyleBackColor = true;
            this.btnAddperson.Click += new System.EventHandler(this.btnAddperson_Click);
            // 
            // btnTrainImages
            // 
            this.btnTrainImages.Location = new System.Drawing.Point(621, 282);
            this.btnTrainImages.Name = "btnTrainImages";
            this.btnTrainImages.Size = new System.Drawing.Size(167, 23);
            this.btnTrainImages.TabIndex = 4;
            this.btnTrainImages.Text = "4. Train Images";
            this.btnTrainImages.UseVisualStyleBackColor = true;
            this.btnTrainImages.Click += new System.EventHandler(this.btnTrainImages_Click);
            // 
            // btnRecongnizeperson
            // 
            this.btnRecongnizeperson.Location = new System.Drawing.Point(619, 311);
            this.btnRecongnizeperson.Name = "btnRecongnizeperson";
            this.btnRecongnizeperson.Size = new System.Drawing.Size(169, 23);
            this.btnRecongnizeperson.TabIndex = 5;
            this.btnRecongnizeperson.Text = "5. Recongnize Persons";
            this.btnRecongnizeperson.UseVisualStyleBackColor = true;
            // 
            // txtPersonName
            // 
            this.txtPersonName.Location = new System.Drawing.Point(621, 256);
            this.txtPersonName.Name = "txtPersonName";
            this.txtPersonName.Size = new System.Drawing.Size(169, 20);
            this.txtPersonName.TabIndex = 6;
            // 
            // picDetection
            // 
            this.picDetection.Location = new System.Drawing.Point(621, 91);
            this.picDetection.Name = "picDetection";
            this.picDetection.Size = new System.Drawing.Size(167, 159);
            this.picDetection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDetection.TabIndex = 7;
            this.picDetection.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(598, 340);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(102, 124);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(715, 340);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(104, 124);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(768, 469);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 28);
            this.button1.TabIndex = 11;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(4, 474);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(75, 23);
            this.btnRestart.TabIndex = 12;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(99, 474);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save Image";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSearchImage
            // 
            this.btnSearchImage.Location = new System.Drawing.Point(202, 474);
            this.btnSearchImage.Name = "btnSearchImage";
            this.btnSearchImage.Size = new System.Drawing.Size(75, 23);
            this.btnSearchImage.TabIndex = 14;
            this.btnSearchImage.Text = "Search Image";
            this.btnSearchImage.UseVisualStyleBackColor = true;
            this.btnSearchImage.Click += new System.EventHandler(this.btnSearchImage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 505);
            this.Controls.Add(this.btnSearchImage);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.picDetection);
            this.Controls.Add(this.txtPersonName);
            this.Controls.Add(this.btnRecongnizeperson);
            this.Controls.Add(this.btnTrainImages);
            this.Controls.Add(this.btnAddperson);
            this.Controls.Add(this.btnDetectface);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.picCapture);
            this.Name = "Form1";
            this.Text = "Face Recongnition";
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDetection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCapture;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Button btnDetectface;
        private System.Windows.Forms.Button btnAddperson;
        private System.Windows.Forms.Button btnTrainImages;
        private System.Windows.Forms.Button btnRecongnizeperson;
        private System.Windows.Forms.TextBox txtPersonName;
        private System.Windows.Forms.PictureBox picDetection;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSearchImage;
    }
}

