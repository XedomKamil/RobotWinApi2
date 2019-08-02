namespace WindowsFormsApp3
{
    partial class WinAppForm
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
            this.bMain = new System.Windows.Forms.Button();
            this.bChart = new System.Windows.Forms.Button();
            this.bTCP = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.bRavi2Temp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(12, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1360, 750);
            this.panel1.TabIndex = 0;
            // 
            // bMain
            // 
            this.bMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bMain.Location = new System.Drawing.Point(12, 4);
            this.bMain.Name = "bMain";
            this.bMain.Size = new System.Drawing.Size(157, 42);
            this.bMain.TabIndex = 1;
            this.bMain.Text = "Main";
            this.bMain.UseVisualStyleBackColor = true;
            this.bMain.Click += new System.EventHandler(this.bMain_Click);
            // 
            // bChart
            // 
            this.bChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bChart.Location = new System.Drawing.Point(173, 4);
            this.bChart.Name = "bChart";
            this.bChart.Size = new System.Drawing.Size(157, 42);
            this.bChart.TabIndex = 2;
            this.bChart.Text = "Chart";
            this.bChart.UseVisualStyleBackColor = true;
            this.bChart.Click += new System.EventHandler(this.bChart_Click);
            // 
            // bTCP
            // 
            this.bTCP.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bTCP.Location = new System.Drawing.Point(394, 4);
            this.bTCP.Name = "bTCP";
            this.bTCP.Size = new System.Drawing.Size(157, 42);
            this.bTCP.TabIndex = 3;
            this.bTCP.Text = "TCP Camera";
            this.bTCP.UseVisualStyleBackColor = true;
            this.bTCP.Click += new System.EventHandler(this.bTCP_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(707, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 42);
            this.button1.TabIndex = 4;
            this.button1.Text = "File Editor";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // bRavi2Temp
            // 
            this.bRavi2Temp.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bRavi2Temp.Location = new System.Drawing.Point(870, 4);
            this.bRavi2Temp.Name = "bRavi2Temp";
            this.bRavi2Temp.Size = new System.Drawing.Size(157, 42);
            this.bRavi2Temp.TabIndex = 5;
            this.bRavi2Temp.Text = "Ravi to Temp";
            this.bRavi2Temp.UseVisualStyleBackColor = true;
            this.bRavi2Temp.Click += new System.EventHandler(this.bRavi2Temp_Click);
            // 
            // WinAppForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1382, 803);
            this.Controls.Add(this.bRavi2Temp);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bTCP);
            this.Controls.Add(this.bChart);
            this.Controls.Add(this.bMain);
            this.Controls.Add(this.panel1);
            this.Name = "WinAppForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WinAppForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bMain;
        private System.Windows.Forms.Button bChart;
        private System.Windows.Forms.Button bTCP;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button bRavi2Temp;
    }
}