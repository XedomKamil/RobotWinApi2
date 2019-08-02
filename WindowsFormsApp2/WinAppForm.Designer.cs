namespace WindowsFormsApp
{
    partial class WinAppForm
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
            this.flowLayoutPanelImages = new System.Windows.Forms.FlowLayoutPanel();
            this.trackbarWithLabel1 = new OpenCvSharp.UserInterface.TrackbarWithLabel();
            this.buttonUpperFolder = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTemp = new System.Windows.Forms.Label();
            this.labelFile = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBoxIpl1 = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanelImages
            // 
            this.flowLayoutPanelImages.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.flowLayoutPanelImages.Location = new System.Drawing.Point(22, 461);
            this.flowLayoutPanelImages.Name = "flowLayoutPanelImages";
            this.flowLayoutPanelImages.Size = new System.Drawing.Size(948, 180);
            this.flowLayoutPanelImages.TabIndex = 4;
            // 
            // trackbarWithLabel1
            // 
            this.trackbarWithLabel1.Location = new System.Drawing.Point(22, 380);
            this.trackbarWithLabel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trackbarWithLabel1.Name = "trackbarWithLabel1";
            this.trackbarWithLabel1.Size = new System.Drawing.Size(950, 65);
            this.trackbarWithLabel1.TabIndex = 5;
            // 
            // buttonUpperFolder
            // 
            this.buttonUpperFolder.Location = new System.Drawing.Point(23, 425);
            this.buttonUpperFolder.Name = "buttonUpperFolder";
            this.buttonUpperFolder.Size = new System.Drawing.Size(136, 31);
            this.buttonUpperFolder.TabIndex = 6;
            this.buttonUpperFolder.Text = "Upper Folder";
            this.buttonUpperFolder.UseVisualStyleBackColor = true;
            this.buttonUpperFolder.Click += new System.EventHandler(this.buttonUpperFolder_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(165, 431);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(506, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 29);
            this.label1.TabIndex = 9;
            this.label1.Text = "Temp:";
            // 
            // labelTemp
            // 
            this.labelTemp.AutoSize = true;
            this.labelTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTemp.Location = new System.Drawing.Point(597, 16);
            this.labelTemp.Name = "labelTemp";
            this.labelTemp.Size = new System.Drawing.Size(37, 29);
            this.labelTemp.TabIndex = 10;
            this.labelTemp.Text = "---";
            // 
            // labelFile
            // 
            this.labelFile.AutoSize = true;
            this.labelFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelFile.Location = new System.Drawing.Point(654, 59);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(37, 29);
            this.labelFile.TabIndex = 12;
            this.labelFile.Text = "---";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(506, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 29);
            this.label3.TabIndex = 11;
            this.label3.Text = "Otwarty plik:";
            // 
            // pictureBoxIpl1
            // 
            this.pictureBoxIpl1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBoxIpl1.Location = new System.Drawing.Point(13, 13);
            this.pictureBoxIpl1.Name = "pictureBoxIpl1";
            this.pictureBoxIpl1.Size = new System.Drawing.Size(480, 360);
            this.pictureBoxIpl1.TabIndex = 2;
            this.pictureBoxIpl1.TabStop = false;
            this.pictureBoxIpl1.DoubleClick += new System.EventHandler(this.pictureBoxIpl1_DoubleClick);
            this.pictureBoxIpl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxIpl1_MouseMove);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(654, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 29);
            this.label2.TabIndex = 14;
            this.label2.Text = "---";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(506, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 29);
            this.label4.TabIndex = 13;
            this.label4.Text = "Czas:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(890, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 29);
            this.label5.TabIndex = 16;
            this.label5.Text = "---";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(742, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 29);
            this.label6.TabIndex = 15;
            this.label6.Text = "Czas:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(747, 421);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // WinAppForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(984, 649);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelTemp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonUpperFolder);
            this.Controls.Add(this.trackbarWithLabel1);
            this.Controls.Add(this.flowLayoutPanelImages);
            this.Controls.Add(this.pictureBoxIpl1);
            this.Name = "WinAppForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private OpenCvSharp.UserInterface.PictureBoxIpl pictureBoxIpl1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelImages;
        private OpenCvSharp.UserInterface.TrackbarWithLabel trackbarWithLabel1;
        private System.Windows.Forms.Button buttonUpperFolder;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTemp;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
    }
}

