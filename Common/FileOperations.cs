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
        private double[,] Liczba2;
        public double[,] liczba2
        {
            get { return Liczba2; }
            set { Liczba2 = value; }
        }


        private List<string> FilesList;

        public List<string> filesList
        {
            get { return FilesList; }
            set { FilesList = value; }
        }


        private List<string> ImagesList;

        public List<string> imagesList
        {
            get { return ImagesList; }
            set { ImagesList = value; }
        }




        public FileStream fs;


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
        



        public string[] GetFoldersInDir(string dirPath)
        {
            //Console.WriteLine("File path: ");
           // Console.WriteLine(dirPath);
            string[] subdirectoryEntries = Directory.GetDirectories(dirPath);

            int dirsCount = subdirectoryEntries.Length;
            for (int i = 0; i < dirsCount; i++)
            {
                subdirectoryEntries[i] += '\\';
            }

           // foreach (var subDir in subdirectoryEntries)
           // {
          //      Console.Write("Sub dir: ");
          //      Console.WriteLine(subDir);
          //  }
            return subdirectoryEntries;
        }




        public string GetNameOfDir(string dirpath)
        {
            string folder = new DirectoryInfo(dirpath).Name;
            return folder;
        }




        public string GetUpperDirectory(string dirPath)
        {
           // Console.WriteLine("Otrzymano dir: ");
           // Console.WriteLine(dirPath);
            // Sprawdzanie ilości znaku "\"
            int countSlash = dirPath.Count(f => f == '\\');
            countSlash--;
            string upperDir = "";
            int length = dirPath.Length;

            int getShalshCount = 0;

            for (int i = 0; i < length; i++)
            {
                if (dirPath[i].Equals('\\'))
                {
                    //Console.WriteLine("Dostano \\");
                    getShalshCount++;
                }
                if (getShalshCount!=countSlash)
                upperDir += dirPath[i];

            }

            upperDir.Trim();

            return upperDir;
        }

        


        /// <summary>
        /// Wyszukuje pliki w folderze i zwraca ich ścieżki przez kolekcje
        /// </summary>
        /// <returns>Kolekcja typu string</returns>
        public List<string> SearchFiles(string dirPath)
        {
            filesList = new List<string>();

            Regex regEmail;

            string[] fileEntries = Directory.GetFiles(dirPath);
            regEmail = new Regex(@"^.*txt$");
            foreach (var filename in fileEntries)
            {
                bool correctFile = regEmail.IsMatch(filename);
                if (correctFile)
                {
                    filesList.Add(filename);
                }
            }

            return filesList;
        } // End Method




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
            liczba2 = new double[161, 121];
            pixel = 0;
            for (int i = 0; i <= 160; i++)
            {
                for (int j = 0; j <= 120; j++)
                {
                    this.liczba2[i, j] = Convert.ToDouble(imageString[pixel]);
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



        public List<DriveInfo> LoadDrives()
        {
            var drives = new List<DriveInfo>();
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {

                    drives.Add(drive);
                }
            }
            return drives;
        }

    }
}
