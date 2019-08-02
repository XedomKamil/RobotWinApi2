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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            this.TopLevel = false;
            this.AutoScroll = true;
            this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
        }
    }
}
