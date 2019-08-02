using Common;
using OpenCvSharp;
using OpenCvSharp.UserInterface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public class GUIElements
    {

        public List<double[,]> tempArrayD = new List<double[,]>();
        public List<Mat> grayImages = new List<Mat>();
        public List<Mat> imagesList2 = new List<Mat>();


        public List<FlowLayoutPanel> dirPanels = new List<FlowLayoutPanel>();
        public List<string> dirPaths = new List<string>();
        public List<PictureBoxIpl> pictureBoxesIplSubDir = new List<PictureBoxIpl>();
        public List<Label> labels = new List<Label>();

        public List<FlowLayoutPanel> imagesPanels = new List<FlowLayoutPanel>();
        public List<string> imagesPaths = new List<string>();
        public List<PictureBoxIpl> imagePictureBoxesIpl = new List<PictureBoxIpl>();
        public List<Label> imageLabels = new List<Label>();
        public List<DateTime> times;
        FlowLayoutPanel panel;
        PictureBoxIpl pictureBoxIplSubDir;

        public string chosenDir;
        public string openedFile;

        public double minT;
        public double maxT;
        public void createFolderElements(string currentPath, Image folder)
        {
            dirPanels.Clear();
            dirPanels.Clear();
            pictureBoxesIplSubDir.Clear();
            labels.Clear();

            DirOperations dirOperations = new DirOperations();
            string[] subDirsList = dirOperations.GetFoldersInDir(currentPath);

            foreach (var subDir in subDirsList)
            {
                // Ustawienia panelu pośredniego
                // Panel ten zawiera nazwe pliku i jego miniature
                panel = new FlowLayoutPanel();
                panel.AutoSize = true;
                panel.FlowDirection = FlowDirection.TopDown;

                // Utworzenie obiektu graficznego PictureBox
                pictureBoxIplSubDir = new PictureBoxIpl
                {
                    Height = 120,
                    Width = 160
                };

                // Przypisanie obrazka folderu do PictureBoxa
                pictureBoxIplSubDir.Image = folder;

                // Przypisanie obrazka folderu do PictureBoxa
                // Nowy obiekt typu label odpowiedzialny za wyświetlenie nazwy folderu
                Label label = new Label();
                label.Text = new DirectoryInfo(subDir).Name;

                // Dodanie do panelu pośredniego nazwy folderu oraz ikony
                panel.Controls.Add(label);
                panel.Controls.Add(pictureBoxIplSubDir);

                pictureBoxesIplSubDir.Add(pictureBoxIplSubDir);
                labels.Add(label);
                dirPaths.Add(subDir);

                dirPanels.Add(panel);
                dirPaths.Add(subDir);

                pictureBoxIplSubDir.Click += new EventHandler((senderSubDir, eSubDir) =>
                pictureBoxIplSubDir_Click(senderSubDir, eSubDir, subDir));
            }
        }

        private void pictureBoxIplSubDir_Click(object senderSubDir, EventArgs eSubDir, string subDir)
        {
            Console.WriteLine(subDir);
            chosenDir = subDir;
        }
        public void createFilesElements(List<string> filesList, Image folder, PictureBoxIpl pictureBoxIpl)
        {
            tempArrayD = new List<double[,]>();
            imagesList2 = new List<Mat>();
            imagesPanels.Clear();
            imagesPaths.Clear();
            imagePictureBoxesIpl.Clear();
            imageLabels.Clear();
            imagesList2.Clear();
            grayImages.Clear();
            FileOperations fileOperations = new FileOperations();
            TemperatureArrayOperations temperatureArrayOperations = new TemperatureArrayOperations();
            TempArray2Img tempArray2Img = new TempArray2Img();


            foreach (var filePath in filesList)
            {

                panel = new FlowLayoutPanel();
                try
                {
                    List<string> imagesString = fileOperations.ReadSingleLine(filePath);
                    // Utworzenie macierzy temperatur typu double[,] 
                    // dostępnej w polu fileOperations.liczba2
                    fileOperations.OperationsOnReadedFile(imagesString[0]);
                    // Znalezienie max i min temperatur dostępnych w polach imageOperations.minT/maxT
                    temperatureArrayOperations.FindMinMaxTemp(fileOperations.tempArrayDouble);
                    // Utworzenie obrazu z uwzględnieniem min i max T
                    tempArray2Img.CreateImageScalable(fileOperations.tempArrayDouble, temperatureArrayOperations.minT, temperatureArrayOperations.maxT);



                    // Stworzenie pola do rysowania miniatury obrazu
                    PictureBoxIpl pictureBoxIpll = new PictureBoxIpl
                    {
                        Height = 120,
                        Width = 160
                    };

                    // Dodanie obrazu do pola miniatury
                    pictureBoxIpll.ImageIpl = tempArray2Img.imageColor;
                
                    // Stworzenie labbelu z nazwą pliku obrazu
                    Label label = new Label();
                    label.Text = Path.GetFileName(filePath);

                    // Dodanie elementów do panelu podrzędnego
                    panel.Controls.Add(label);
                    panel.Controls.Add(pictureBoxIpll);
                    // Konfiguracja panelu podrzędnego
                    panel.AutoSize = true;
                    panel.FlowDirection = FlowDirection.TopDown;

                    imagePictureBoxesIpl.Add(pictureBoxIpll);
                    imageLabels.Add(label);
                    imagesPanels.Add(panel);
                    imagesPaths.Add(filePath);

                    pictureBoxIpll.Click += new EventHandler((sender2, e2) =>
                    ImagePictureBoxIpll_Click(sender2, e2, filePath, pictureBoxIpl));

                }
                catch
                {

                }

            }
        }

        private void ImagePictureBoxIpll_Click(object sender2, EventArgs e2, string filePath, PictureBoxIpl pictureBoxIpl)
        {
            openedFile = filePath;

            TimeRead timeRead = new TimeRead();
            try
            {
                string timePath = timeRead.GetTempFilePath(filePath);
                times = timeRead.Read_All_Times(timePath);
            }

            catch { }
            Console.Write("Path img:");
            Console.WriteLine(filePath);
            tempArrayD = new List<double[,]>();
            imagesList2 = new List<Mat>();

            Image imageLoading = WindowsFormsApp3.Properties.Resources.Loading.GetThumbnailImage(720, 480, null, IntPtr.Zero);
            pictureBoxIpl.Image = imageLoading;
            pictureBoxIpl.Refresh();

            FileOperations fileOperations = new FileOperations();
            TemperatureArrayOperations temperatureArrayOperations = new TemperatureArrayOperations();
            TempArray2Img tempArray2Img = new TempArray2Img();
            ImageOperations imageOperations = new ImageOperations();



            //imagesList2 = new List<Mat>();

            // odczytanie plików i utworzenie kolekcji obrazów w formacie string
            List<string> imagesStringList = fileOperations.ReadAllLines(filePath);

            Console.WriteLine("Images cout form event");
            Console.WriteLine(imagesStringList.Count);
            // Utworzenie kolekcji min i max Temp
            List<double> minT = new List<double>();
            List<double> maxT = new List<double>();

            // Utworzenie macierzy temperatur typu double[,] 
            // dostępnej w polu fileOperations.liczba2
            // dla wszystkich macierzy w formacie string
            //
            // Oraz utworzenie wypełnienie kolekcji min i max T dla całej sekwecji
            // tempArrayD.Clear();
            foreach (var image in imagesStringList)
            {
                fileOperations.OperationsOnReadedFile(image);

                tempArrayD.Add(fileOperations.tempArrayDouble);
                temperatureArrayOperations.FindMinMaxTemp(fileOperations.tempArrayDouble);
                minT.Add(temperatureArrayOperations.minT);
                maxT.Add(temperatureArrayOperations.maxT);
            }
            // Znalezienie największej różnicy temperatur dla całej sekwencji
            double min = new double();
            double max = new double();
            double zakresTemp = 0;

            for (int i = 0; i < imagesStringList.Count; i++)
            {
                if (maxT[i] - minT[i] > 0)
                {
                    zakresTemp = maxT[i] - minT[i];
                    min = minT[i];
                    max = maxT[i];
                }
            }

            this.minT = min;
            this.maxT = max;

            // Utworzenie koelkcji obrazów kolorowych       
            for (int i = 0; i < imagesStringList.Count; i++)
            {
                tempArray2Img.CreateImageScalable(tempArrayD[i], min, max);
               // tempArray2Img.imageColor = imageOperations.ResizeForShow(tempArray2Img.imageColor, 4.5, 4);
                imagesList2.Add(tempArray2Img.imageColor);
                grayImages.Add ( tempArray2Img.imageGray);
            }

            Console.WriteLine("images list at event:");
            Console.WriteLine(imagesList2.Count);

        }
    }
}
