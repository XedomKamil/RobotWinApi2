using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class ImageOperations
    {
       
       
        

        /// <summary>
        /// Zmiana rozmiaru obrazu
        /// </summary>
        /// <param name="xScale">Skala X</param>
        /// <param name="yScale">Skala Y</param>
        public Mat ResizeForShow(Mat image,int xScale, int yScale)
        {
            try
            {
                Cv2.Resize(image, image, new OpenCvSharp.Size(160 * xScale, 120 * yScale), 0, 0, InterpolationFlags.Linear);
            }
            catch { }
            return image;
        }
        /// <summary>
        /// Tworzy obraz kolorowy z użyciem palety barw pseudokolorów Hot
        /// </summary>



        public void RotateImage(Mat Image)
        {
            throw new NotImplementedException();  
        }












    }
}
