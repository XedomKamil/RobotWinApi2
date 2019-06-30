using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class ImageOperations
    {
        public double minT;
        public double maxT;

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

        public void FindMinMaxTemp(double[,] TempArray)
        {
            try
            {
                this.imageGray = new Mat(new OpenCvSharp.Size(121, 161), MatType.CV_8U, new Scalar(1));

                double min = 9999;
                double max = -9999;
                double tempT;
                // Znalezenie minimalnej i maksymalnej temperatury na obrazie
                for (int i = 0; i <= 160; i++)
                {
                    for (int j = 0; j <= 120; j++)
                    {
                        tempT = TempArray[i, j];
                        if ((tempT < min) & (tempT > 0)) { min = tempT; }
                        if (tempT > max) { max = tempT; }
                    }
                }
                this.minT = min;
                this.maxT = max;
            }
            catch { }

        }

        public int CreateImageScalable(double[,] TempArray, double min, double max)
        {
            try
            {
                this.imageGray = new Mat(new OpenCvSharp.Size(161, 121), MatType.CV_8U, new Scalar(1));

                double tempT;
                // Utworzenie obrazu w odcieniach szarości
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
            }
            catch { }

            return 1;
        }
        

        /// <summary>
        /// Zmiana rozmiaru obrazu
        /// </summary>
        /// <param name="xScale">Skala X</param>
        /// <param name="yScale">Skala Y</param>
        public void ResizeForShow(int xScale, int yScale)
        {
            try
            {
                Cv2.Resize(imageColor, imageColor, new OpenCvSharp.Size(160 * xScale, 120 * yScale), 0, 0, InterpolationFlags.Linear);
            }
            catch { }
        }
        /// <summary>
        /// Tworzy obraz kolorowy z użyciem palety barw pseudokolorów Hot
        /// </summary>
        public void CreatePseudoColorImage()
        {
            try
            {
                imageColor = new Mat(new OpenCvSharp.Size(161, 121), MatType.CV_8UC3, new Scalar(1));

                Cv2.ApplyColorMap(imageGray, imageColor, ColormapTypes.Hot);
            }
            catch { }
        }

        public double[,] Transpose(double[,] TempArray)
        {
            double[,] TempArrayT = new double[161, 121];
            imageColor = new Mat(new OpenCvSharp.Size(161, 121), MatType.CV_8UC3, new Scalar(1));
            for (int j = 0; j <= 160; j++)
            {
                for (int i = 0; i <= 120; i++)
                {
                    TempArrayT[j, i] = TempArray[i, j];

                }
            }
            return TempArrayT;
        }

        public void RotateImage(Mat Image)
        {
                
        }




    }
}
