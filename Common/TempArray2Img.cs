using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class TempArray2Img
    {

        public int CreateImageScalable2(double[,] TempArray, double min, double max)
        {

            // Console.WriteLine(TempArray[50,50]);
            try
            {
                this.imageGray = new Mat(new OpenCvSharp.Size(121, 161), MatType.CV_8U, new Scalar(1));

                double tempT;
                // Utworzenie obrazu w odcieniach szarości


                
                for (int i = 0; i <= 119; i++)
                {
                    for (int j = 0; j <= 159; j++)
                    {

                        tempT = TempArray[i, j];
                        tempT = ((tempT - min) / max) * 255;
                        //tempT += 30 ;
                        if (tempT < 0) tempT = 0;
                        if (tempT > 255) tempT = 255;
                        this.imageGray.Set<byte>(j, i, Convert.ToByte(Math.Round(tempT)));

                    }
                }
                Rect myROI;
                myROI = new Rect(0, 0, 119, 159);
                this.imageGray = new Mat(imageGray, myROI);
                CreatePseudoColorImage();
            }
            catch { }

            return 1;
        }

        public int CreateImageScalable(double[,] TempArray, double min, double max)
        {
            try
            {
                this.imageGray = new Mat(new OpenCvSharp.Size(161, 121), MatType.CV_8U, new Scalar(1));

                double tempT;
                // Utworzenie obrazu w odcieniach szarości
                /*
                for (int i = 0; i <= 160; i++)
                {
                    Parallel.For(0, 120,
                             j =>
                             {
                                 tempT = TempArray[i, j];
                                 tempT = ((tempT - min) / max) * 255;
                                 //tempT += 30 ;
                                 if (tempT < 0) tempT = 0;
                                 if (tempT > 255) tempT = 255;
                                 this.imageGray.Set<byte>(j, i, Convert.ToByte(Math.Round(tempT)));
                             });
                }*/
                
                for (int i = 0; i <= 160; i++)
                {
                    for (int j = 0; j <= 120; j++)
                    {

                        tempT = TempArray[i, j];
                        tempT = ((tempT - min) / max) * 255;
                        //tempT += 30 ;
                        if (tempT < 0) tempT = 0;
                        if (tempT > 255) tempT = 255;
                        this.imageGray.Set<byte>(j, i, Convert.ToByte(Math.Round(tempT)));

                    }
                }
                Rect myROI;
                myROI = new Rect(0, 0, 159, 119);
                this.imageGray = new Mat(imageGray, myROI);
                CreatePseudoColorImage();
            }
            catch { }

            return 1;
        }

        public void CreatePseudoColorImage()
        {
            try
            {
                imageColor = new Mat(new OpenCvSharp.Size(161, 121), MatType.CV_8UC3, new Scalar(1));

                Cv2.ApplyColorMap(imageGray, imageColor, ColormapTypes.Hot);
            }
            catch { }
        }


        private Mat ImageGray;
        /// <summary>
        /// Mat Gray Image
        /// </summary>
        public Mat imageGray
        {

            get { return ImageGray; }
            set { ImageGray = value; }
        }

        private Mat ImageColor;
        /// <summary>
        /// Mat Color Image
        /// </summary>
        public Mat imageColor
        {

            get { return ImageColor; }
            set { ImageColor = value; }
        }
    }
}
