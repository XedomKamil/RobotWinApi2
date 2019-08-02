namespace WindowsFormsApp3
{
    partial class FormMain
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
            this.buttonUpperFolder = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTemp = new System.Windows.Forms.Label();
            this.labelFile = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBoxIpl1 = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.trackbarWithLabel1 = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.gradientPictureBoxIpl2 = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.lminT = new System.Windows.Forms.Label();
            this.lmaxT = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox3 = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarWithLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPictureBoxIpl2)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanelImages
            // 
            this.flowLayoutPanelImages.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.flowLayoutPanelImages.Location = new System.Drawing.Point(0, 520);
            this.flowLayoutPanelImages.Name = "flowLayoutPanelImages";
            this.flowLayoutPanelImages.Size = new System.Drawing.Size(1319, 180);
            this.flowLayoutPanelImages.TabIndex = 4;
            // 
            // buttonUpperFolder
            // 
            this.buttonUpperFolder.Location = new System.Drawing.Point(3, 487);
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
            this.comboBox1.Location = new System.Drawing.Point(143, 497);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(935, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 29);
            this.label1.TabIndex = 9;
            this.label1.Text = "Temp:";
            // 
            // labelTemp
            // 
            this.labelTemp.AutoSize = true;
            this.labelTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTemp.Location = new System.Drawing.Point(1026, 9);
            this.labelTemp.Name = "labelTemp";
            this.labelTemp.Size = new System.Drawing.Size(37, 29);
            this.labelTemp.TabIndex = 10;
            this.labelTemp.Text = "---";
            // 
            // labelFile
            // 
            this.labelFile.AutoSize = true;
            this.labelFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelFile.Location = new System.Drawing.Point(1083, 52);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(37, 29);
            this.labelFile.TabIndex = 12;
            this.labelFile.Text = "---";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(935, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 29);
            this.label3.TabIndex = 11;
            this.label3.Text = "Otwarty plik:";
            // 
            // pictureBoxIpl1
            // 
            this.pictureBoxIpl1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBoxIpl1.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxIpl1.Name = "pictureBoxIpl1";
            this.pictureBoxIpl1.Size = new System.Drawing.Size(720, 480);
            this.pictureBoxIpl1.TabIndex = 2;
            this.pictureBoxIpl1.TabStop = false;
            this.pictureBoxIpl1.DoubleClick += new System.EventHandler(this.pictureBoxIpl1_DoubleClick);
            this.pictureBoxIpl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxIpl1_MouseMove);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(1083, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 29);
            this.label2.TabIndex = 14;
            this.label2.Text = "---";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(935, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 29);
            this.label4.TabIndex = 13;
            this.label4.Text = "Czas:";
            // 
            // trackbarWithLabel1
            // 
            this.trackbarWithLabel1.Location = new System.Drawing.Point(778, 189);
            this.trackbarWithLabel1.Name = "trackbarWithLabel1";
            this.trackbarWithLabel1.Size = new System.Drawing.Size(552, 56);
            this.trackbarWithLabel1.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(801, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 32);
            this.label7.TabIndex = 22;
            this.label7.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(1263, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 32);
            this.label8.TabIndex = 23;
            this.label8.Text = "0";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(875, 234);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(330, 280);
            this.flowLayoutPanel1.TabIndex = 24;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1211, 234);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "Wyczyść";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1031, 121);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 42);
            this.button2.TabIndex = 26;
            this.button2.Text = "Usuń wybraną klatke obrazu";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // gradientPictureBoxIpl2
            // 
            this.gradientPictureBoxIpl2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.gradientPictureBoxIpl2.Location = new System.Drawing.Point(720, 0);
            this.gradientPictureBoxIpl2.Name = "gradientPictureBoxIpl2";
            this.gradientPictureBoxIpl2.Size = new System.Drawing.Size(25, 480);
            this.gradientPictureBoxIpl2.TabIndex = 27;
            this.gradientPictureBoxIpl2.TabStop = false;
            // 
            // lminT
            // 
            this.lminT.AutoSize = true;
            this.lminT.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lminT.Location = new System.Drawing.Point(754, 454);
            this.lminT.Name = "lminT";
            this.lminT.Size = new System.Drawing.Size(131, 32);
            this.lminT.TabIndex = 28;
            this.lminT.Text = "min temp";
            // 
            // lmaxT
            // 
            this.lmaxT.AutoSize = true;
            this.lmaxT.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lmaxT.Location = new System.Drawing.Point(752, 5);
            this.lmaxT.Name = "lmaxT";
            this.lmaxT.Size = new System.Drawing.Size(138, 32);
            this.lmaxT.TabIndex = 29;
            this.lmaxT.Text = "max temp";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(751, 109);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(154, 42);
            this.button4.TabIndex = 32;
            this.button4.Text = "Calc summary THD";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(767, 81);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(118, 22);
            this.maskedTextBox1.TabIndex = 33;
            this.maskedTextBox1.Text = "30";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(911, 141);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(79, 42);
            this.button3.TabIndex = 34;
            this.button3.Text = "Showthd";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.Location = new System.Drawing.Point(751, 234);
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(118, 22);
            this.maskedTextBox2.TabIndex = 35;
            this.maskedTextBox2.Text = "0,1";
            // 
            // maskedTextBox3
            // 
            this.maskedTextBox3.Location = new System.Drawing.Point(751, 282);
            this.maskedTextBox3.Name = "maskedTextBox3";
            this.maskedTextBox3.Size = new System.Drawing.Size(118, 22);
            this.maskedTextBox3.TabIndex = 36;
            this.maskedTextBox3.Text = "5";
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1342, 703);
            this.Controls.Add(this.maskedTextBox3);
            this.Controls.Add(this.maskedTextBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.lmaxT);
            this.Controls.Add(this.lminT);
            this.Controls.Add(this.gradientPictureBoxIpl2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.trackbarWithLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelTemp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonUpperFolder);
            this.Controls.Add(this.flowLayoutPanelImages);
            this.Controls.Add(this.pictureBoxIpl1);
            this.Name = "FormMain";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarWithLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPictureBoxIpl2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private OpenCvSharp.UserInterface.PictureBoxIpl pictureBoxIpl1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelImages;
        private System.Windows.Forms.Button buttonUpperFolder;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTemp;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackbarWithLabel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private OpenCvSharp.UserInterface.PictureBoxIpl gradientPictureBoxIpl2;
        private System.Windows.Forms.Label lminT;
        private System.Windows.Forms.Label lmaxT;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox3;
    }
}

