using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Common
{
    public class FileOperations
    {



        public List<string> ReadSingleLine(string filePath)
        {
            imagesList = new List<string>();
            using (var reader = File.OpenText(filePath))
            {
                string line = reader.ReadLine();
                imagesList.Add(line);
            }
            return imagesList;
        }

            public List<string> ReadAllLines(string filePath)
        {
            imagesList = new List<string>();
            var lineCount = 0;
            string line;
            lineCount = GetNumerOfImages(filePath);
            using (var reader = File.OpenText(filePath))
            {
                for (int i = 0; i < lineCount; i++)
                {
                    line = reader.ReadLine();
                    imagesList.Add(line);
                }

            }
            return imagesList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="imgsreader"></param>
        public void OperationsOnReadedFile(string imgsreader)
        {

            int pixel = 0;
            int len = imgsreader.Length;

            string[] imageString;
            imageString = new string[len];

            for (int i = 0; i <= len - 1; i++)
            {

                if (imgsreader[i] == ' ')                            // otrzymano spacje
                {
                    pixel++;
                }
                else
                {
                    if (imgsreader[i] == '.')
                    {
                        imageString[pixel] += ',';  // Zastapienie kropki przecinkiem
                    }
                    else
                    {
                        if (imgsreader[i] != ';')
                            if (imgsreader[i] != ':')
                                imageString[pixel] += imgsreader[i];
                    }


                }

            } // END FOR
            // Z stringa do double
            tempArrayDouble = new double[161, 121];
            pixel = 0;
            for (int i = 0; i <= 160; i++)
            {
                for (int j = 0; j <= 120; j++)
                {
                    this.tempArrayDouble[i, j] = Convert.ToDouble(imageString[pixel]);
                    pixel++;
                }
            }
        }


        public int GetNumerOfImages(string filePath)
        {
            var lineCount = 0;
            using (var reader = File.OpenText(filePath))
            {
                while (reader.ReadLine() != null)
                {
                    lineCount++;
                }
            }
            return lineCount;
        }

        public double[,] Transpose(double[,] TempArray)
        {
            double[,] TempArrayT = new double[161, 121];
           for (int j = 0; j <= 160; j++)
            {
                for (int i = 0; i <= 120; i++)
                {
                    TempArrayT[j, i] = TempArray[i, j];

                }
            }

            return TempArrayT;
        }




        private double[,] TempArrayDouble;
        public double[,] tempArrayDouble
        {
            get { return TempArrayDouble; }
            set { TempArrayDouble = value; }
        }


        private List<string> ImagesList;
        public List<string> imagesList
        {
            get { return ImagesList; }
            set { ImagesList = value; }
        }

        private FileStream Fs;
        public FileStream fs
        {
            get { return Fs; }
            set { Fs = value; }
        }





    }
}
