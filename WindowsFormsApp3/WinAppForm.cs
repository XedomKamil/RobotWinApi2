using System;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class WinAppForm : Form
    {
        FormChart formChart = new FormChart();
        FormMain formMain = new FormMain();
        FormTCPCamera formTCP = new FormTCPCamera();
        FormRavi2Temp FormRavi2Temp = new FormRavi2Temp();
        public WinAppForm()
        {
            InitializeComponent();
            panel1.Controls.Add(formChart);
            panel1.Controls.Add(formMain);
            panel1.Controls.Add(formTCP);
            panel1.Controls.Add(FormRavi2Temp);
            formMain.Show();
        }

        private void bMain_Click(object sender, EventArgs e)
        {
            formMain.Show();
            formChart.Hide();
            formTCP.Hide();
            FormRavi2Temp.Hide();
        }

        private void bChart_Click(object sender, EventArgs e)
        {
            formChart.charTemps = formMain.charTemps;
            formChart.Colors = formMain.Colors;
            formChart.CreateChart();

            formMain.Hide();
            formChart.Show();
            formTCP.Hide();
            FormRavi2Temp.Hide();
        }

        private void bTCP_Click(object sender, EventArgs e)
        {
            formMain.Hide();
            formChart.Hide();
            formTCP.Show();
            FormRavi2Temp.Hide();
        }

        private void WinAppForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            formTCP.camThd.Abort();
        }

        private void bRavi2Temp_Click(object sender, EventArgs e)
        {
            formMain.Hide();
            formChart.Hide();
            formTCP.Hide();
            FormRavi2Temp.Show();
        }
    }
}
