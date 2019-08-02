using System;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class FormRavi2Temp : Form
    {
        public FormRavi2Temp()
        {
            TopLevel = false;
            AutoScroll = true;
            FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();

            //Console.WriteLine("IPC2 INIt");
            //IPC2.IPC2.Init(1);
            //IPC2.IPC2.SetIPCMode(1, 1);
            //IPC2.IPC2.FileOpen(1, "5cm2.ravi");

            //IPC2.IPC2.Run(1);
            //byte[,] bb = new byte[160, 120];


            //Int32 Size = FrameWidth * FrameHeight * FrameDepth;
            //IntPtr Buffer = Marshal.AllocHGlobal(Size);
            //IPC2.IPC2.FrameMetadata Metadata;
            //for (Int32 x = 0; x < FrameSize; x++)
            //    Marshal.WriteInt16(Buffer, x * 2, (Int16)x);
            //IPC2.IPC2.GetFrame(1, 200, ptr, 90000000, out frameMetadata);

        }
    }
}
