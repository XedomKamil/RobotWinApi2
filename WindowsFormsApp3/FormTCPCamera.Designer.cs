namespace WindowsFormsApp3
{
    partial class FormTCPCamera
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
            this.pictureBoxIpl1 = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.bRecord = new System.Windows.Forms.Button();
            this.trackbarWithLabel2 = new OpenCvSharp.UserInterface.TrackbarWithLabel();
            this.trackbarWithLabel1 = new OpenCvSharp.UserInterface.TrackbarWithLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxIpl1
            // 
            this.pictureBoxIpl1.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxIpl1.Name = "pictureBoxIpl1";
            this.pictureBoxIpl1.Size = new System.Drawing.Size(880, 600);
            this.pictureBoxIpl1.TabIndex = 0;
            this.pictureBoxIpl1.TabStop = false;
            // 
            // bRecord
            // 
            this.bRecord.Location = new System.Drawing.Point(956, 47);
            this.bRecord.Name = "bRecord";
            this.bRecord.Size = new System.Drawing.Size(150, 55);
            this.bRecord.TabIndex = 4;
            this.bRecord.Text = "Start";
            this.bRecord.UseVisualStyleBackColor = true;
            this.bRecord.Click += new System.EventHandler(this.bRecord_Click);
            // 
            // trackbarWithLabel2
            // 
            this.trackbarWithLabel2.Location = new System.Drawing.Point(0, 651);
            this.trackbarWithLabel2.Margin = new System.Windows.Forms.Padding(4);
            this.trackbarWithLabel2.Name = "trackbarWithLabel2";
            this.trackbarWithLabel2.Size = new System.Drawing.Size(867, 39);
            this.trackbarWithLabel2.TabIndex = 6;
            // 
            // trackbarWithLabel1
            // 
            this.trackbarWithLabel1.Location = new System.Drawing.Point(0, 608);
            this.trackbarWithLabel1.Margin = new System.Windows.Forms.Padding(4);
            this.trackbarWithLabel1.Name = "trackbarWithLabel1";
            this.trackbarWithLabel1.Size = new System.Drawing.Size(867, 39);
            this.trackbarWithLabel1.TabIndex = 5;
            // 
            // FormTCP
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1342, 703);
            this.Controls.Add(this.trackbarWithLabel2);
            this.Controls.Add(this.trackbarWithLabel1);
            this.Controls.Add(this.bRecord);
            this.Controls.Add(this.pictureBoxIpl1);
            this.Name = "FormTCP";
            this.Text = "FormTCP";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OpenCvSharp.UserInterface.PictureBoxIpl pictureBoxIpl1;
        private System.Windows.Forms.Button bRecord;
        private OpenCvSharp.UserInterface.TrackbarWithLabel trackbarWithLabel2;
        private OpenCvSharp.UserInterface.TrackbarWithLabel trackbarWithLabel1;
    }
}