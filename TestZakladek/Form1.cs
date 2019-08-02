using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestZakladek
{
    public partial class Form1 : Form
    {
        FormMain formMain = new FormMain();
        FormSecond formSecond = new FormSecond();

        public Form1()
        {
            InitializeComponent();

            panel1.Controls.Add(formMain);
            panel1.Controls.Add(formSecond);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            panel1.Controls.Add(formMain);
            formSecond.Hide();
            formMain.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            formMain.Hide();
            formSecond.Show();
        }
    }
}
