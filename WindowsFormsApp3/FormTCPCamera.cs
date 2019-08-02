using Common;
using System;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class FormTCPCamera : Form
    {
        double min;
        double max;
        bool recording;
        public Thread camThd;
        public FormTCPCamera()
        {
            TopLevel = false;
            AutoScroll = true;
            FormBorderStyle = FormBorderStyle.None;

            recording = false;
            min = 20;
            max = 30;

            InitializeComponent();

            trackbarWithLabel1.Trackbar.Minimum = 10;
            trackbarWithLabel1.Trackbar.Maximum = 40;
            trackbarWithLabel2.Trackbar.Minimum = 10;
            trackbarWithLabel2.Trackbar.Maximum = 40;

            trackbarWithLabel1.Trackbar.Value = (int)min;
            trackbarWithLabel2.Trackbar.Value = (int)max;

            trackbarWithLabel1.Trackbar.ValueChanged += new EventHandler((sender, eS) =>
               trackar1ValChanger(sender, eS));


            trackbarWithLabel2.Trackbar.ValueChanged += new EventHandler((sender2, eS2) =>
               trackar2ValChanger(sender2, eS2));


            camThd = new Thread(CamreaThread);
            camThd.Start();
        }

        public void trackar1ValChanger(object sender, EventArgs e)
        {
            min = trackbarWithLabel1.Trackbar.Value;

        }

        public void trackar2ValChanger(object sender2, EventArgs e2)
        {
            max = trackbarWithLabel2.Trackbar.Value;

        }


        private void CamreaThread()
        {

            FileOperations fileOperations = new FileOperations();
            ImageOperations imageOperations = new ImageOperations();
            TempArray2Img tempArray2Img = new TempArray2Img();
            TemperatureArrayOperations temperatureArrayOperations =
                new TemperatureArrayOperations();



            //IrDirectInterface irDirectInterface;
            //irDirectInterface = IrDirectInterface.Instance;
            //irDirectInterface.Connect("192.168.0.100", 1337);
            //irDirectInterface.SetRadiationParameters(0.78f, 1.0f);
            while (true)
            {

                //////  SZTUCZNA TABLICA
                Random rd = new Random();

                ushort[,] temps;
                temps = new ushort[120, 160];
                for (int j = 0; j < 160; j++)
                {
                    for (int i = 0; i < 120; i++)
                    {
                        //temps[i, j] = (ushort)1275;
                        temps[i, j] = (ushort)rd.Next(1250, 1300);
                    }
                }

                double[,] tempArray;
                //ushort[,] temps = irDirectInterface.GetThermalImage();

                tempArray = temperatureArrayOperations.UshortToDouble(temps);
                if (recording)
                {
                    fileOperations.SaveArrayToFile(tempArray);
                }
                tempArray2Img.CreateImageScalable2(tempArray, min, max);

                //   Cv2.ImShow("ss", imageOperations.imageColor);
                //  Cv2.ImShow("ss2", imageOperations.imageGray);
                tempArray2Img.imageColor = imageOperations.ResizeForShow(tempArray2Img.imageColor, 5.5, 5);
                pictureBoxIpl1.ImageIpl = tempArray2Img.imageColor;

                Thread.Sleep(100);
            }
        }

        private void bRecord_Click(object sender, EventArgs e)
        {
            recording = !recording;
            Console.WriteLine(recording);
        }
    }

}
