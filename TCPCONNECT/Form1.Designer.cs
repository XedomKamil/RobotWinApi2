namespace TCPCONNECT
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxIpl1 = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.trackbarWithLabel1 = new OpenCvSharp.UserInterface.TrackbarWithLabel();
            this.trackbarWithLabel2 = new OpenCvSharp.UserInterface.TrackbarWithLabel();
            this.bRecord = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxIpl1
            // 
            this.pictureBoxIpl1.Location = new System.Drawing.Point(56, 45);
            this.pictureBoxIpl1.Name = "pictureBoxIpl1";
            this.pictureBoxIpl1.Size = new System.Drawing.Size(497, 460);
            this.pictureBoxIpl1.TabIndex = 0;
            this.pictureBoxIpl1.TabStop = false;
            // 
            // trackbarWithLabel1
            // 
            this.trackbarWithLabel1.Location = new System.Drawing.Point(56, 513);
            this.trackbarWithLabel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trackbarWithLabel1.Name = "trackbarWithLabel1";
            this.trackbarWithLabel1.Size = new System.Drawing.Size(728, 65);
            this.trackbarWithLabel1.TabIndex = 1;
            // 
            // trackbarWithLabel2
            // 
            this.trackbarWithLabel2.Location = new System.Drawing.Point(56, 586);
            this.trackbarWithLabel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trackbarWithLabel2.Name = "trackbarWithLabel2";
            this.trackbarWithLabel2.Size = new System.Drawing.Size(728, 65);
            this.trackbarWithLabel2.TabIndex = 2;
            // 
            // bRecord
            // 
            this.bRecord.Location = new System.Drawing.Point(581, 45);
            this.bRecord.Name = "bRecord";
            this.bRecord.Size = new System.Drawing.Size(150, 55);
            this.bRecord.TabIndex = 3;
            this.bRecord.Text = "Start";
            this.bRecord.UseVisualStyleBackColor = true;
            this.bRecord.Click += new System.EventHandler(this.bRecord_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 700);
            this.Controls.Add(this.bRecord);
            this.Controls.Add(this.trackbarWithLabel2);
            this.Controls.Add(this.trackbarWithLabel1);
            this.Controls.Add(this.pictureBoxIpl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OpenCvSharp.UserInterface.PictureBoxIpl pictureBoxIpl1;
        private OpenCvSharp.UserInterface.TrackbarWithLabel trackbarWithLabel1;
        private OpenCvSharp.UserInterface.TrackbarWithLabel trackbarWithLabel2;
        private System.Windows.Forms.Button bRecord;
    }
}

