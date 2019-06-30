using Common;
using Common.irDirectBinding;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using OpenCvSharp.UserInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp
{
  
    public partial class WinAppForm : System.Windows.Forms.Form
    {
        // Kolekcja macierzy temperatur
        List<double[,]> tempArrayD = new List<double[,]>();
        // Kolekcja macierzy obrazów
        List<Mat> imagesList2 = new List<Mat>();

        // Odczytanie ścieżki w której znajduje się plik exe programu 
        string currentPath = Directory.GetCurrentDirectory();

        // Wczytanie ikonek
        Image imageFolder = WindowsFormsApp.Properties.Resources.folder;
        Image imageLoading = WindowsFormsApp.Properties.Resources.Loading;

        int trackbarLastVal = 0;

        public WinAppForm()
        {
            InitializeComponent();
            //TestDirectSdk();
            // Wyświetlenie przeglądarki
            LoadViewer();


            IrDirectInterface _irDirectInterface;
            _irDirectInterface = IrDirectInterface.Instance;

            _irDirectInterface.usb_init("generic.xml", "0", "0");
            _irDirectInterface.daemon_launch();
            _irDirectInterface.SetRadiationParameters(0.88f, 1, 23);
               // Wyświetlenie w obiekcie comboBox dostępnych dysków
            FileOperations fileOperations = new FileOperations();
            List<DriveInfo> drives = fileOperations.LoadDrives();
            foreach (var drive in drives)
            {
                comboBox1.Items.Add(drive);
            }
        }

        private void LoadViewer()
        {
            // Wczytanie klas
            FileOperations fileOperations = new FileOperations();
            ImageOperations imageOperations = new ImageOperations();

            // Odczyt listy plików
            List<string> filesList = new List<string>();
            filesList = fileOperations.SearchFiles(currentPath);

            // Panel pośredni
            FlowLayoutPanel panel;

            // Konfiguracja flowPanelu
            flowLayoutPanelImages.Controls.Clear();
            flowLayoutPanelImages.AutoScroll = true;
            flowLayoutPanelImages.WrapContents = false;

            // Wyświelenie folderów
            string[] subDirsList = fileOperations.GetFoldersInDir(currentPath);

            // Console.Write("Ilość subfolderów= ");
            // Console.WriteLine(subDirsList.Length);

            // Stworzenie pola do rysowania
            foreach (var subDir in subDirsList)
            {   
                // FOLDERY // FOLDERY // FOLDERY //

                // Ustawienia panelu pośredniego
                // Panel ten zawiera nazwe pliku i jego miniature
                panel = new FlowLayoutPanel();
                panel.AutoSize = true;
                panel.FlowDirection = FlowDirection.TopDown;

                // Utworzenie obiektu graficznego PictureBox
                PictureBoxIpl pictureBoxIplSubDir = new PictureBoxIpl
                {
                    Height = 120,
                    Width = 160
                };
                // Przypisanie obrazka folderu do PictureBoxa
                pictureBoxIplSubDir.Image = imageFolder.GetThumbnailImage(120, 90, null, IntPtr.Zero);

                // Nowy obiekt typu label odpowiedzialny za wyświetlenie nazwy folderu
                Label label = new Label();
                label.Text = new DirectoryInfo(subDir).Name;

                // Dodanie do panelu pośredniego nazwy folderu oraz ikony
                panel.Controls.Add(label);
                panel.Controls.Add(pictureBoxIplSubDir);

                // Dodanie panelu pośredniego folderów do głównego panelu 
                // zawierającego foldery oraz pasujące pliki
                flowLayoutPanelImages.Controls.Add(panel);

                // Zdarzenie kliknięcia na pictureBox reprezentującego folder
                pictureBoxIplSubDir.Click += new EventHandler((senderSubDir, eSubDir) =>
               pictureBoxIplSubDir_Click(senderSubDir, eSubDir, subDir));

            }
            // Wyświelenie folderów koniec






            // Wyświetlenie plików temperaturowych
            foreach (var filePath in filesList)
            {
                panel = new FlowLayoutPanel();

                //Console.WriteLine(filePath);
                try
                {
                    // Utworzenie kolekcji zawierającej macierze temperatur w postaci stringu
                    List<string> imagesString = fileOperations.ReadSingleLine(filePath);

                    // Utworzenie macierzy temperatur typu double[,] 
                    // dostępnej w polu fileOperations.liczba2
                    fileOperations.OperationsOnReadedFile(imagesString[0]);
                    // Znalezienie max i min temperatur dostępnych w polach imageOperations.minT/maxT
                    imageOperations.FindMinMaxTemp(fileOperations.liczba2);
                    // Utworzenie obrazu w odcieniach szarości z uwzględnieniem min i max T
                    imageOperations.CreateImageScalable(fileOperations.liczba2, imageOperations.minT, imageOperations.maxT);
                    // Utworzenie obrazu kolorowego
                    imageOperations.CreatePseudoColorImage();

                    // Stworzenie pola do rysowania miniatury obrazu
                    PictureBoxIpl pictureBoxIpll = new PictureBoxIpl
                    {
                        Height = 120,
                        Width = 160
                    };

                    // Obsługa zdarzenia przesunięcia trackbara
                    trackbarWithLabel1.Trackbar.ValueChanged += new EventHandler((sender, e) =>
                    TrackBar1_ValueChanged(sender, e, filePath));

                    // Obsługa zdarzenia kliknięcia na pole rysowania obrazu
                    pictureBoxIpll.Click += new EventHandler((sender2, e2) =>
                    pictureBoxIpll_Click(sender2, e2, filePath, imageOperations));

                    // Dodanie obrazu do pola miniatury
                    pictureBoxIpll.ImageIpl = imageOperations.imageColor;

                    // Stworzenie labbelu z nazwą pliku obrazu
                    Label label = new Label();
                    label.Text = Path.GetFileName(filePath);

                    // Dodanie elementów do panelu podrzędnego
                    panel.Controls.Add(label);
                    panel.Controls.Add(pictureBoxIpll);

                    // Konfiguracja panelu podrzędnego
                    panel.AutoSize = true;
                    panel.FlowDirection = FlowDirection.TopDown;
                    // Dodanie panelu podrzędnego do głównego panelu przeglądarki
                    flowLayoutPanelImages.Controls.Add(panel);
                }
                catch
                {

                }
             
            }// END FOREACH

            //Thread thread = new Thread(UpdateThread);
            //thread.Start();
        }


        private void pictureBoxIplSubDir_Click(object senderSubDir, EventArgs eSubDir, string subDir)
        {
            currentPath = subDir;
            LoadViewer();

        }

        private void TrackBar1_ValueChanged(object sender, EventArgs e, string filePath)
        {
            // Warunek dzięki któremu ładowany jest obraz tylko przy zmianie wartości
            // Bez tego kilka razy został ładowany obraz na PictureBox
            if (trackbarLastVal != trackbarWithLabel1.Trackbar.Value)
            {
                trackbarLastVal = trackbarWithLabel1.Trackbar.Value;
               //  Console.WriteLine("Trackbar val changed: ");
                // Console.WriteLine(trackbarWithLabel1.Trackbar.Value);
                if (imagesList2.Count >= trackbarWithLabel1.Trackbar.Value)
                    pictureBoxIpl1.ImageIpl = imagesList2[trackbarWithLabel1.Trackbar.Value];
               // pictureBoxIpl1.Refresh();
            }
        }


        

        

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxIpll_Click(object sender, EventArgs e, string filePath,  ImageOperations imageOperations)
        {

            pictureBoxIpl1.Image = imageLoading.GetThumbnailImage(480, 360, null, IntPtr.Zero);
            pictureBoxIpl1.Refresh();

            labelFile.Text = new DirectoryInfo(filePath).Name;


            imagesList2.Clear();
            tempArrayD.Clear();

          //  Console.Write("Index: ");
           // Console.WriteLine(fileIndex);

           // Console.WriteLine("File: ");
           // Console.WriteLine(filePath);

            FileOperations fileOperations = new FileOperations();

           // Console.WriteLine("Liczba obrazów: ");

            // odczytanie plików i utworzenie kolekcji obrazów w formacie string
            List<string> imagesStringList = new List<string>();
            imagesStringList = fileOperations.ReadAllLines(filePath);
            // Utworzenie kolekcji min i max Temp
            List<double> minT = new List<double>();
            List<double> maxT = new List<double>();
            // double[,] tempArray;
            // List<double[,]> tempArrayD = new List<double[,]>();

            // Utworzenie macierzy temperatur typu double[,] 
            // dostępnej w polu fileOperations.liczba2
            // dla wszystkich macierzy w formacie string
            //
            // Oraz utworzenie wypełnienie kolekcji min i max T dla całej sekwecji
            foreach (var image in imagesStringList)
            {
                fileOperations.OperationsOnReadedFile(image);

                tempArrayD.Add(fileOperations.liczba2);
                imageOperations.FindMinMaxTemp(fileOperations.liczba2);
                minT.Add(imageOperations.minT);
                maxT.Add(imageOperations.maxT);
            }

            // Znalezienie największej różnicy temperatur dla całej sekwencji
            double min = new double();
            double max = new double();
            double zakresTemp = 0;
            for (int i = 0; i < imagesStringList.Count; i++)
            {
                if (maxT[i]-minT[i]>0)
                {
                    zakresTemp = maxT[i] - minT[i];
                    min = minT[i];
                    max = maxT[i];
                }
            }

            // Utworzenie koelkcji obrazów kolorowych
            for (int i = 0; i < imagesStringList.Count; i++)
            {
                imageOperations.CreateImageScalable(tempArrayD[i], min, max);
                imageOperations.CreatePseudoColorImage();
                imageOperations.ResizeForShow(3, 3);
                imagesList2.Add(imageOperations.imageColor);

            }

            // Wyświetlenie pierwszego obrazu z kolekcji
            pictureBoxIpl1.ImageIpl = imagesList2[0];
            pictureBoxIpl1.Refresh();
           // Console.WriteLine("Ilosc wczytanych obrazów: ");
           // Console.WriteLine(imagesStringList.Count);
           // Ustawienie trackbara
            trackbarWithLabel1.Trackbar.Maximum = fileOperations.GetNumerOfImages(filePath) - 1;
        }

        private void buttonUpperFolder_Click(object sender, EventArgs e)
        {
            FileOperations fileOperations = new FileOperations();
            currentPath = fileOperations.GetUpperDirectory(currentPath);
           // Console.WriteLine("Path z przycisku: ");
           // Console.WriteLine(currentPath);
            LoadViewer();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] dirs;
            dirs = System.IO.Directory.GetLogicalDrives();
            currentPath = dirs[comboBox1.SelectedIndex];
            LoadViewer();
            // Console.WriteLine("Index :");
            // Console.WriteLine(comboBox1.SelectedIndex);
            // Console.WriteLine("Dir :");
            // Console.WriteLine(currentPath);
            // Console.WriteLine(comboBox1.SelectedItem);
        }



        /// <summary>
        /// Wyświelene temperatury przez wskazanie kursorem myszki
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Mouse Params</param>
        private void pictureBoxIpl1_MouseMove(object sender, MouseEventArgs e)
        {
            //Console.Write("X = ");
            //  Console.WriteLine(e.X);
            //  Console.Write("Y = ");
            //   Console.WriteLine(e.Y);
            if (tempArrayD.Count>0)
            {
                double[,] temps = tempArrayD[trackbarWithLabel1.Trackbar.Value];
                try
                {
                    if (( (e.X ) <=480 ) && ((e.Y ) <= 360))
                    {
                        int posX = Convert.ToInt16( Math.Floor(e.X / 3.0) );
                        int posY = Convert.ToInt16(Math.Floor(e.Y / 3.0));
                        labelTemp.Text = Convert.ToString( temps[ posX,posY] );
                        //  Console.WriteLine(posX);
                        //  Console.Write("Temp = ");
                        //  Console.WriteLine(temps[e.X / 3, e.Y / 3]);
                    }
                }
                catch
                { }
            }
        }

        public void TestDirectSdk()
        {
            
            IrDirectInterface _irDirectInterface;
            _irDirectInterface = IrDirectInterface.Instance;
            _irDirectInterface.Connect("generic.xml");
            
            ThermalPaletteImage images = _irDirectInterface.GetThermalPaletteImage();
            ushort[,] thermals =  images.ThermalImage;
           // _irDirectInterface.

            int rows = images.ThermalImage.GetLength(0);
            int columns = images.ThermalImage.GetLength(1);
        }



    }
}
