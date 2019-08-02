using OpenCvSharp;
using System;

namespace Common
{
    public class ImageOperations
    {




        /// <summary>
        /// Zmiana rozmiaru obrazu
        /// </summary>
        /// <param name="xScale">Skala X</param>
        /// <param name="yScale">Skala Y</param>
        public Mat ResizeForShow(Mat image, double xScale, double yScale)
        {
            try
            {
                Cv2.Resize(image, image, new OpenCvSharp.Size(160 * xScale, 120 * yScale), 0, 0, InterpolationFlags.Linear);
            }
            catch { }
            return image;
        }


        public Mat CreateGradientBar(int width, int heigth, int minT, int maxT)
        {
            Mat imageGray = new Mat(new OpenCvSharp.Size(width, heigth), MatType.CV_8U, new Scalar(1));

            // stworzenie tablicy 0 - 255
            double[] scaleD = new double[heigth];
            scaleD[heigth - 1] = 0;
            for (int i = 1; i < heigth; i++)
            {
                scaleD[i] = ((heigth - i) / (double)heigth) * 255;
                for (int j = 0; j < width; j++)
                {
                    imageGray.Set<byte>(i, j, Convert.ToByte(Math.Round(scaleD[i])));
                }

            }

            Mat imageColor = new Mat(new OpenCvSharp.Size(1, heigth), MatType.CV_8UC3, new Scalar(1));


            Cv2.ApplyColorMap(imageGray, imageColor, ColormapTypes.Hot);
            return imageColor;
        }


        public void RotateImage(Mat Image)
        {
            throw new NotImplementedException();
        }




        public void CreateHistogram(Mat imageGray)
        {

        }

        public Mat Threshold(Mat imageGray, int thd)
        {
            Mat imageThd = new Mat(new OpenCvSharp.Size(161, 121), MatType.CV_8UC3, new Scalar(1));
            //Cv2.Threshold(imageGray, imageThd, 0, 255, ThresholdTypes.BinaryInv | ThresholdTypes.Otsu);
           // Cv2.Threshold(imageGray, imageThd, thd, 255, ThresholdTypes.BinaryInv | ThresholdTypes.Otsu);

            // Cv2.AdaptiveThreshold(imageGray, imageThd, 255, AdaptiveThresholdTypes.GaussianC, ThresholdTypes.Binary, 11, 7);
            return imageThd;

        }








    }
}
