using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;
using OpenCvSharp;

namespace WindowsFormsApp1
{
    
    public partial class Form1 : Form
    {

      

        double[,] pixelTab = new double[161, 121];
        double[,] R = new double[161, 121];
        double[,] G = new double[161, 121];
        double[,] B = new double[161, 121];
        public Form1()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             var fs = new FileStream(@"temps4.txt", FileMode.Open);
             var len = (int)fs.Length;
             var bits = new byte[len];
             fs.Read(bits, 0, len);
             //fs.Close();

            string[] liczba;
            liczba = new string[19481];
            int pixel = 0;
            for (int i = 0; i <= len - 1; i++)
            //for (int i = 0; i <= 501; i++)
            {
                
                    if ((bits[i] >= 48) && (bits[i] <= 57))     // otrzymano liczbę
                    {
                        liczba[pixel] += Convert.ToString(bits[i] - 48);
                    }

                    if (bits[i] == 46)                          // otrzymano kropkę
                    {
                       liczba[pixel] += ",";
                    }
                    if (bits[i] == 45)                          // otrzymano minus
                    {
                        liczba[pixel] += "-";
                    }
                     if(bits[i]==32)                            // otrzymano spacje
                    {
                        pixel++;
                    }
            }


            

 
            Mat GRAYimage = new Mat(new OpenCvSharp.Size(121, 161), MatType.CV_8U, new Scalar(1));


            Mat Image = new Mat(new OpenCvSharp.Size(121, 161), MatType.CV_8UC3, new Scalar(1));
            double min=9999;
            double max=-9999;
            pixel = 0;
            for (int i = 0; i <= 160; i++)
            {
                for (int j = 0; j <= 120; j++)
                {
                    double tempT = Convert.ToDouble(liczba[pixel]);
                    if ((tempT < min) & (tempT>0)) { min = tempT;  }
                    if (tempT > max) { max = tempT;  }
                    pixel++;
                }
            }
            pixel = 0;
            for (int i = 0; i <= 160; i++)
            {
                for (int j = 0; j <= 120; j++)
                {
                    double tempT = Convert.ToDouble(liczba[pixel]);
                    
                        tempT = ((tempT - min) / max)*255 ;
                    //tempT += 30 ;
                    if (tempT < 0) tempT = 0;
                    if (tempT > 255) tempT = 255;

                    GRAYimage.Set<byte>(i, j, Convert.ToByte(Math.Round( tempT)));

                    pixel++;
                }
            }
            Rect myROI;
            myROI = new Rect(0, 0, 119, 159);
            //Mat croppedIMG = new Mat(Image, myROI);
            GRAYimage = new Mat(GRAYimage, myROI);
            Cv2.Resize(GRAYimage, GRAYimage, new OpenCvSharp.Size(160 * 6, 120 * 6), 0, 0, InterpolationFlags.Linear);
            Cv2.ApplyColorMap(GRAYimage, Image, ColormapTypes.Hot);
            
            Cv2.ImShow("G", GRAYimage);
            Cv2.ImShow("C", Image);



        }



    }
}
