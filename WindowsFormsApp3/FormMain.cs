using Common;
using Common.irDirectBinding;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp3
{

    public partial class FormMain : System.Windows.Forms.Form
    {


        public Mat SummaryThdImage = new Mat(new OpenCvSharp.Size(161, 121), MatType.CV_8U, new Scalar(1));
        public Mat segmentedImages = new Mat(new OpenCvSharp.Size(161, 121), MatType.CV_8UC3);
        // Kolekcja macierzy temperatur
        public List<double[,]> tempArrayD = new List<double[,]>();
        // Kolekcja macierzy obrazów
        public List<Mat> imagesThermalColor = new List<Mat>();
        public List<Mat> thdImages = new List<Mat>();
        // Odczytanie ścieżki w której znajduje się plik exe programu 
        string currentPath;

        // Wczytanie ikonek
        Image imageFolder = WindowsFormsApp3.Properties.Resources.folder.GetThumbnailImage(120, 90, null, IntPtr.Zero);
        Image imageLoading = WindowsFormsApp3.Properties.Resources.Loading.GetThumbnailImage(120, 90, null, IntPtr.Zero);

        int trackbarLastVal = 0;



        // Wczytanie klas
        DirOperations dirOperations = new DirOperations();
        FileOperations fileOperations = new FileOperations();
        ImageOperations imageOperations = new ImageOperations();
        TemperatureArrayOperations temperatureArrayOperations =
            new TemperatureArrayOperations();
        TempArray2Img tempArray2Img = new TempArray2Img();
        GUIElements gUIElements = new GUIElements();




        // Mouse positions
        int eX = 0;
        int eY = 0;

        // Dane do wykresu
        //  List<double> charTempSeries = new List<double>();
        public List<List<double>> charTemps = new List<List<double>>();
        public List<int> eXs = new List<int>();
        public List<int> eYs = new List<int>();
        public List<Scalar> Colors = new List<Scalar>();

        WindowsFormsApp3.FormChart secondForm = new WindowsFormsApp3.FormChart();
        public bool bZoomVar = false;
        public bool showThd = false;
        public FormMain()
        {
            // GC.KeepAlive(temperatureArrayOperations);
            //  GC.KeepAlive(tempArrayD);
            //  GC.KeepAlive(SummaryThdImage);
            //  GC.KeepAlive(pictureBoxIpl1);


            TopLevel = false;
            AutoScroll = true;
            FormBorderStyle = FormBorderStyle.None;

            currentPath = Directory.GetCurrentDirectory();
            if (currentPath[currentPath.Length - 1] != '\\')
            {
                currentPath += "\\";
            }

            InitializeComponent();
            #region TEST_IRDIRECT
            /*
            IrDirectInterface _irDirectInterface;
            _irDirectInterface = IrDirectInterface.Instance;

            _irDirectInterface.usb_init("generic.xml", "0", "0");
            _irDirectInterface.daemon_launch();
            _irDirectInterface.SetRadiationParameters(0.88f, 1, 23);
            */
            #endregion

            // Wyświetlenie w obiekcie comboBox dostępnych dysków
            DirOperations dirOperations = new DirOperations();
            List<DriveInfo> drives = dirOperations.LoadDrives();
            foreach (var drive in drives)
            {
                comboBox1.Items.Add(drive);
            }
            flowLayoutPanel1.AutoScroll = true;
            // Wyświetlenie przeglądarki
            LoadViewer();

            WriteSome();
            //    GC.KeepAlive(dirOperations);
            //    GC.KeepAlive(fileOperations);
            //    GC.KeepAlive(imageOperations);
            //   GC.KeepAlive(temperatureArrayOperations);
            //    GC.KeepAlive(charTemps);
        }


        private void LoadViewer()
        {
            // Konfiguracja flowPanelu
            flowLayoutPanelImages.Controls.Clear();
            flowLayoutPanelImages.AutoScroll = true;
            flowLayoutPanelImages.WrapContents = false;

            #region OLD
            // Wyświelenie folderów
            // string[] subDirsList = dirOperations.GetFoldersInDir(currentPath);

            // Console.Write("Ilość subfolderów= ");
            // Console.WriteLine(subDirsList.Length);
            /*
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
            */
            #endregion

            // Przypisanie obrazka folderu do PictureBoxa
            gUIElements.createFolderElements(currentPath, imageFolder);

            for (int i = 0; i < gUIElements.dirPanels.Count; i++)
            {
                Console.WriteLine(i);
                flowLayoutPanelImages.Controls.Add(gUIElements.dirPanels[i]);

                gUIElements.pictureBoxesIplSubDir[i].Click += new EventHandler((senderSubDir, eSubDir) =>
               pictureBoxIplSubDir_Click(senderSubDir, eSubDir, gUIElements.dirPaths[i], gUIElements));
            }


            // Odczyt listy plików
            List<string> filesList = new List<string>();
            filesList = dirOperations.SearchFiles(currentPath);
            gUIElements.createFilesElements(filesList, imageFolder, pictureBoxIpl1);

            for (int i = 0; i < gUIElements.imagesPanels.Count; i++)
            {
                Console.WriteLine(i);
                flowLayoutPanelImages.Controls.Add(gUIElements.imagesPanels[i]);
                // Obsługa zdarzenia kliknięcia na pole rysowania obrazu
                gUIElements.imagePictureBoxesIpl[i].Click += new EventHandler((sender2, e2) =>
                   pictureBoxIpll_Click2(sender2, e2, gUIElements.imagesPaths[i - 1], imageOperations, gUIElements));
                // Obsługa zdarzenia przesunięcia trackbara
                trackbarWithLabel1.ValueChanged += new EventHandler((sender, e) =>
                TrackBar1_ValueChanged(sender, e, gUIElements));
            }

            //Thread thread = new Thread(UpdateThread);
            //thread.Start();
        }


        private void pictureBoxIplSubDir_Click(object senderSubDir, EventArgs eSubDir, string subDir, GUIElements gUIElements)
        {
            flowLayoutPanel1.Controls.Clear();
            SummaryThdImage = Mat.Zeros(SummaryThdImage.Size(), MatType.CV_8UC1);
            segmentedImages = Mat.Zeros(segmentedImages.Size(), MatType.CV_8UC3);
            Console.Write("Chosen dir: ");
            Console.WriteLine(gUIElements.chosenDir);
            currentPath = gUIElements.chosenDir;
            LoadViewer();
        }


        private void pictureBoxIpll_Click2(object sender, EventArgs e, string filePath, ImageOperations imageOperations, GUIElements gUIElements)
        {
            flowLayoutPanel1.Controls.Clear();
            SummaryThdImage = Mat.Zeros(SummaryThdImage.Size(), MatType.CV_8UC1);
            segmentedImages = Mat.Zeros(segmentedImages.Size(), MatType.CV_8UC1);

            trackbarWithLabel1.Value = 0;
            tempArrayD = gUIElements.tempArrayD;
            imagesThermalColor = gUIElements.imagesList2;

            Mat imgForShow = gUIElements.imagesList2[0].Clone();
            Cv2.Resize(imgForShow, imgForShow, new OpenCvSharp.Size(Convert.ToInt32(160 * 4.5), 120 * 4), 0, 0, InterpolationFlags.Linear);

            pictureBoxIpl1.ImageIpl = imgForShow;
            trackbarWithLabel1.Maximum = gUIElements.imagesList2.Count - 1;
            labelFile.Text = new DirectoryInfo(gUIElements.openedFile).Name;
            label8.Text = Convert.ToString(imagesThermalColor.Count);

            charTemps.Clear();
            Colors.Clear();
            eXs.Clear();
            eYs.Clear();

            gradientPictureBoxIpl2.ImageIpl = imageOperations.CreateGradientBar(gradientPictureBoxIpl2.Width,
                gradientPictureBoxIpl2.Height, 20, 30);

            lminT.Text = gUIElements.minT.ToString();
            lmaxT.Text = gUIElements.maxT.ToString();

            //trackBar1.Minimum = Convert.ToInt16(gUIElements.minT);
            //   trackBar1.Maximum = Convert.ToInt16(gUIElements.maxT);
            //  trackBar1.Value = Convert.ToInt16((gUIElements.minT + gUIElements.maxT) / 2);
        }



        private void TrackBar1_ValueChanged(object sender, EventArgs e, GUIElements gUIElements)
        {
            Console.WriteLine(gUIElements.imagesList2.Count);
            // Warunek dzięki któremu ładowany jest obraz tylko przy zmianie wartości
            // Bez tego kilka razy został ładowany obraz na PictureBox
            if (trackbarLastVal != trackbarWithLabel1.Value)
            {
                trackbarLastVal = trackbarWithLabel1.Value;
                //if (trackbarWithLabel1.Trackbar.Value <= gUIElements.imagesList2.Count-1)
                if (trackbarWithLabel1.Value <= imagesThermalColor.Count - 1)
                    if (trackbarWithLabel1.Value >= 0)
                    {
                        try
                        {
                            label7.Text = Convert.ToString(trackbarWithLabel1.Value);

                            label2.Text = Convert.ToString(gUIElements.times[trackbarWithLabel1.Value]);
                        }
                        catch { }
                        // pictureBoxIpl1.ImageIpl = gUIElements.imagesList2[trackbarWithLabel1.Trackbar.Value];
                        //  pictureBoxIpl1.ImageIpl = imagesList2[trackbarWithLabel1.Value];
                        Mat img = new Mat();
                        img = imagesThermalColor[trackbarWithLabel1.Value].Clone();
                        /*
                         * int j = 0;
                        foreach (var item in charTemps)
                        {

                            img.Circle(new OpenCvSharp.Point(eXs[j] * 4.5, eYs[j] * 4.0), 5, Scalar.LightSeaGreen);
                            img.PutText("Seria" + j, new OpenCvSharp.Point(eXs[j] * 4.5, (eYs[j] - 2) * 4.0), new HersheyFonts(), 0.5, Colors[j]);

                            j++;
                        }
                        */
                        showObjSegmentedImg();

                    }

            }
        }



        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonUpperFolder_Click(object sender, EventArgs e)
        {
            DirOperations dirOperations = new DirOperations();
            currentPath = dirOperations.GetUpperDirectory(currentPath);
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
        }


        /// <summary>
        /// Wyświelene temperatury przez wskazanie kursorem myszki
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Mouse Params</param>
        private void pictureBoxIpl1_MouseMove(object sender, MouseEventArgs e)
        {
            #region ConsoleWriteMouseOnPictureBox_Location
            //Console.Write("X = ");
            //  Console.WriteLine(e.X);
            //  Console.Write("Y = ");
            //   Console.WriteLine(e.Y);
            #endregion
            if (tempArrayD.Count > 0)
            {
                double[,] temps = tempArrayD[trackbarWithLabel1.Value];
                try
                {
                    if (((e.X) <= 720) && ((e.Y) <= 480))
                    {
                        int posX = Convert.ToInt16(Math.Floor(e.X / 4.5));
                        int posY = Convert.ToInt16(Math.Floor(e.Y / 4.0));
                        labelTemp.Text = Convert.ToString(temps[posX, posY]);

                        eX = posX;
                        eY = posY;
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
            ushort[,] thermals = images.ThermalImage;
            // _irDirectInterface.

            int rows = images.ThermalImage.GetLength(0);
            int columns = images.ThermalImage.GetLength(1);
        }



        private void pictureBoxIpl1_DoubleClick(object sender, EventArgs e)
        {

            List<double> charTempSeries = new List<double>();
            Console.WriteLine("Temp array D:");
            Console.WriteLine(tempArrayD.Count);
            charTempSeries.Clear();
            if (tempArrayD.Count > 0)
            {
                try
                {
                    if (((eX) <= 160) && ((eY) <= 120))
                    {

                        flowLayoutPanel1.Controls.Clear();

                        foreach (var tempArray in tempArrayD)
                        {
                            charTempSeries.Add(tempArray[eX, eY]);
                        }
                        // label5.Text = temps[eX , eY ].ToString();
                        //label5.Text = Convert.ToString(tempArrayD[0][eX, eY]);
                        charTemps.Add(charTempSeries);
                        eXs.Add(eX);
                        eYs.Add(eY);
                        Colors.Add(Scalar.RandomColor());


                        Console.WriteLine("charTemps:");
                        Console.WriteLine(charTemps.Count);

                        secondForm.charTemps = charTemps;
                        secondForm.Colors = Colors;
                        secondForm.CreateChart();


                        Mat img = new Mat();
                        //img = imagesThermalColor[trackbarWithLabel1.Value].Clone();
                        img = pictureBoxIpl1.ImageIpl.Clone();
                        int i = 0;
                        foreach (var item in charTemps)
                        {
                            Label l = new Label();
                            l.Text = "X: " + eXs[i] + " Y: " + eYs[i];

                            Label seriesName = new Label();
                            seriesName.Text = "Seria" + i;
                            seriesName.ForeColor = Color.FromArgb((int)Colors[i].Val2, (int)Colors[i].Val1, (int)Colors[i].Val0);
                            seriesName.Font = new Font(seriesName.Font, FontStyle.Bold);

                            PictureBox pictureBox = new PictureBox();
                            pictureBox.Height = 10;
                            pictureBox.Width = 10;
                            pictureBox.Image = WindowsFormsApp3.Properties.Resources.deleteIcon.GetThumbnailImage(10, 10, null, IntPtr.Zero);


                            PictureBox pictureBoxSeparator = new PictureBox();
                            pictureBoxSeparator.Height = 2;
                            pictureBoxSeparator.Width = 300;
                            pictureBoxSeparator.BackColor = Color.Black;

                            flowLayoutPanel1.Controls.Add(l);
                            flowLayoutPanel1.Controls.Add(seriesName);
                            flowLayoutPanel1.Controls.Add(pictureBox);
                            flowLayoutPanel1.Controls.Add(pictureBoxSeparator);

                            //   pictureBoxIpl1.ImageIpl.Circle(new OpenCvSharp.Point(eXs[i] * 4.5, eYs[i] * 4.0), 5, Scalar.LightSeaGreen);
                            //  pictureBoxIpl1.ImageIpl.PutText("Seria" + i, new OpenCvSharp.Point(eXs[i] * 4.5, (eYs[i] - 2) * 4.0), new HersheyFonts(), 0.5, Colors[i]);

                            img.Circle(new OpenCvSharp.Point(eXs[i] * 4.5, eYs[i] * 4.0), 5, Scalar.LightSeaGreen);
                            img.PutText("Seria" + i, new OpenCvSharp.Point(eXs[i] * 4.5, (eYs[i] - 2) * 4.0), new HersheyFonts(), 0.5, Colors[i]);

                            pictureBox.Click += new EventHandler((senderDel, eDel) =>
                            picBox_Click(senderDel, eDel, pictureBox));
                            i++;
                        }
                        pictureBoxIpl1.ImageIpl = img;

                    }

                }
                catch
                { }

            }
        }



        public void picBox_Click(object sender, EventArgs e, PictureBox pictureBox)
        {
            int index = 0;
            Console.WriteLine("Ilosc elementów: " + flowLayoutPanel1.Controls.Count);
            for (int i = 0; i < flowLayoutPanel1.Controls.Count; i++)
            {
                if (flowLayoutPanel1.Controls[i] == pictureBox)
                {
                    index = ((i + 1) / 4);
                }
            }

            Console.WriteLine("Indeks to: " + index);

            // Usuwanie

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Usuwanie indexu: " + ((index * 4) + i));
                flowLayoutPanel1.Controls.RemoveAt((index * 4));

            }
            for (int z = 0; z < (flowLayoutPanel1.Controls.Count / 4); z++)
            {
                string orgin = flowLayoutPanel1.Controls[(z * 4) + 1].Text;

                flowLayoutPanel1.Controls[(z * 4) + 1].Text = orgin.Substring(0, orgin.Length - 1) + z;
            }

            charTemps.RemoveAt(index);
            eXs.RemoveAt(index);
            eYs.RemoveAt(index);
            Colors.RemoveAt(index);

            //pictureBoxIpl1.ImageIpl = imagesThermalColor[trackbarWithLabel1.Value];
            //pictureBoxIpl1.Refresh();

            Mat img = new Mat();
            showObjSegmentedImg();
            img = pictureBoxIpl1.ImageIpl;
            int j = 0;
            foreach (var item in charTemps)
            {

                img.Circle(new OpenCvSharp.Point(eXs[j] * 4.5, eYs[j] * 4.0), 5, Scalar.LightSeaGreen);
                img.PutText("Seria" + j, new OpenCvSharp.Point(eXs[j] * 4.5, (eYs[j] - 2) * 4.0), new HersheyFonts(), 0.5, Colors[j]);

                j++;
            }
            pictureBoxIpl1.ImageIpl = img;

            //      img.Circle(new OpenCvSharp.Point(eXs[j] * 4.5, eYs[j] * 4.0), 5, OpenCvSharp.Scalar.Green);
            //      img.PutText("Seria" + j, new OpenCvSharp.Point(eXs[j] * 4.5, (eYs[j] - 2) * 4.0), new HersheyFonts(), 0.5, OpenCvSharp.Scalar.Green);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            charTemps.Clear();
            eXs.Clear();
            eYs.Clear();
            Colors.Clear();
            flowLayoutPanel1.Controls.Clear();
            showObjSegmentedImg();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            imagesThermalColor.RemoveAt(trackbarWithLabel1.Value);
            tempArrayD.RemoveAt(trackbarWithLabel1.Value);
            if (charTemps.Count > 0)
            {
                for (int i = 0; i < charTemps.Count; i++)
                {
                    charTemps[i].RemoveAt(trackbarWithLabel1.Value);

                }
            }

            trackbarWithLabel1.Maximum = imagesThermalColor.Count;
            label8.Text = imagesThermalColor.Count.ToString();
            //  pictureBoxIpl1.ImageIpl = imagesList2[trackbarWithLabel1.Value];
            secondForm.CreateChart();

            Mat img = new Mat();
            img = imagesThermalColor[trackbarWithLabel1.Value].Clone();
            int j = 0;
            foreach (var item in charTemps)
            {

                img.Circle(new OpenCvSharp.Point(eXs[j] * 4.5, eYs[j] * 4.0), 5, Scalar.LightSeaGreen);
                img.PutText("Seria" + j, new OpenCvSharp.Point(eXs[j] * 4.5, (eYs[j] - 2) * 4.0), new HersheyFonts(), 0.5, Colors[j]);

                j++;
            }
            pictureBoxIpl1.ImageIpl = img;

        }



        public void ReloadThdImg()
        {

            SummaryThdImage = new Mat(new OpenCvSharp.Size(161, 121), MatType.CV_8U, new Scalar(1));
            Mat thresholded;
            foreach (var temp in tempArrayD)
            {
                thresholded = temperatureArrayOperations.Threshold(temp, Convert.ToDouble(maskedTextBox1.Text));
                Cv2.Add(SummaryThdImage, thresholded, SummaryThdImage);
            }
            Rect myROI;
            myROI = new Rect(0, 0, 159, 119);
            SummaryThdImage = new Mat(SummaryThdImage, myROI);
        }

        private void showObjSegmentedImg()
        {
            Mat img = Mat.Zeros(new OpenCvSharp.Size(159, 119), MatType.CV_8U);
            if (showThd)
            {

                // 159x119 wtf
                Mat ipplImg = imagesThermalColor[trackbarWithLabel1.Value].Clone();


                //Mat ipplImgB = Mat.Zeros(new OpenCvSharp.Size(159, 119), MatType.CV_8U);
                //Mat ipplImgG = Mat.Zeros(new OpenCvSharp.Size(159, 119), MatType.CV_8U);
                //Mat ipplImgR = Mat.Zeros(new OpenCvSharp.Size(159, 119), MatType.CV_8U);
                //Cv2.ExtractChannel(ipplImg, ipplImgB, 0);
                //Cv2.ExtractChannel(ipplImg, ipplImgG, 1);
                //Cv2.ExtractChannel(ipplImg, ipplImgR, 2);

                //double alfa = 0.0;

                //for (int i = 0; i < 119; i++)
                //{
                //    for (int z = 0; z < 159; z++)
                //    {
                //        // if (SummaryThdImage.At<byte>(i, z) == 255)
                //        if (segmentedImages.At<Vec3b>(i, z) != Scalar.Black.ToVec3b())
                //        {
                //            ipplImgB.Set<byte>(i, z, 200);
                //            ipplImgG.Set<byte>(i, z, 100);
                //            byte R = Convert.ToByte((ipplImgR.At<byte>(i, z) * alfa));
                //            ipplImgR.Set<byte>(i, z, R);
                //        }

                //    }

                //}
                //    Cv2.InsertChannel(ipplImgB, ipplImg, 0);
                //   Cv2.InsertChannel(ipplImgG, ipplImg, 1);
                //    Cv2.InsertChannel(ipplImgR, ipplImg, 2);


                double alfa = 0.7;
                Mat overlays = ipplImg.Clone();

                for (int i = 0; i < segmentedImages.Rows; i++)
                {
                    for (int j = 0; j < segmentedImages.Cols; j++)
                    {
                        if (segmentedImages.At<Vec3b>(i, j) != Scalar.Black.ToVec3b())
                        {
                            overlays.Set<Vec3b>(i, j, segmentedImages.At<Vec3b>(i, j));
                        }
                    }
                }


                Cv2.AddWeighted(overlays, alfa, ipplImg, 1.0 - alfa, 0, ipplImg);

                //  Cv2.ImShow("Objekty", segmentedImages);

                img = ipplImg;

            }
            else
            {
                img = imagesThermalColor[trackbarWithLabel1.Value].Clone();
            }
            Cv2.Resize(img, img, new OpenCvSharp.Size(Convert.ToInt32(160 * 4.5), 120 * 4), 0, 0, InterpolationFlags.Linear);

            foreach (var item in charTemps)
            {
                int j = charTemps.IndexOf(item);
                img.Circle(new OpenCvSharp.Point(eXs[j] * 4.5, eYs[j] * 4.0), 5, Scalar.LightSeaGreen);
                img.PutText("Seria" + j, new OpenCvSharp.Point(eXs[j] * 4.5, (eYs[j] - 2) * 4.0), new HersheyFonts(), 0.5, Colors[j]);
            }
            pictureBoxIpl1.Invoke(new Action(() => pictureBoxIpl1.ImageIpl = img));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReloadThdImg();
            Segmentation();
            showThd = true;
            showObjSegmentedImg();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showThd = !showThd;
            showObjSegmentedImg();

        }


        private void Segmentation()
        {
            // Init values

            int gausianBlueSize = 5;
            double thresholdDistanceTransform = 0.2;
            thresholdDistanceTransform = Convert.ToDouble(maskedTextBox2.Text);

            double distanceCondition = 2.2;
            // distanceCondition = Convert.ToDouble(maskedTextBox3.Text);
            byte[] kernelValues = { 255, 255, 255,
                                    255, 255, 255,
                                    255, 255, 255
            };
            Mat kernel = new Mat(3, 3, MatType.CV_8UC1, kernelValues);

            //  Mat kernel = Mat.Ones(new OpenCvSharp.Size(3, 3), MatType.CV_8UC1);

            byte[] kernelValues2 = { 255, 255, 255,
                                    255, 255, 255,
                                    255, 255, 255
            }; // cross (+)
            Mat kernel2 = new Mat(Convert.ToInt16(Math.Sqrt(kernelValues2.Length)),
                Convert.ToInt16(Math.Sqrt(kernelValues2.Length)),
                MatType.CV_8UC1, kernelValues2);
            //  Mat kernel2 = Mat.Ones(3, 3, MatType.CV_8UC1);




            ////////////////////////////////////
            ////////////////////////////////////
            ////////////////////////////////////
            ////////////////////////////////////

            Mat sumCoppy = new Mat();
            Cv2.GaussianBlur(SummaryThdImage, sumCoppy, new OpenCvSharp.Size(gausianBlueSize, gausianBlueSize), 0);
            double minv;
            double maxv;
            Cv2.Threshold(sumCoppy, sumCoppy, 10, 255, ThresholdTypes.Binary);
            // Cv2.MinMaxIdx(sumCoppy, out minv, out maxv);
            //  Console.WriteLine("min: " + minv + " max: " + maxv);

            Mat dist = new Mat();
            Mat norm = new Mat();

            Cv2.DistanceTransform(sumCoppy, dist, DistanceTypes.L2, DistanceMaskSize.Mask3);
            Cv2.Normalize(dist, norm, 0.0, 1.0, NormTypes.MinMax);

            //  Cv2.MinMaxIdx(norm, out minv, out maxv);
            // Console.WriteLine("min: "+minv+" max: "+maxv);


            ////////
            Cv2.Threshold(norm, norm, thresholdDistanceTransform, 1.0, ThresholdTypes.Binary);

            //Cv2.MorphologyEx(norm, norm, MorphTypes.Close, kernel);

            Mat dist_8U = new Mat();
            norm.ConvertTo(dist_8U, MatType.CV_8U);
            dist_8U = dist_8U * 255;

            // Cv2.MinMaxIdx(dist_8U, out minv, out maxv);
            // Console.WriteLine("min: " + minv + " max: " + maxv);


            OpenCvSharp.Point[][] contours;
            OpenCvSharp.HierarchyIndex[] hierarchy;
            Cv2.FindContours(dist_8U, out contours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxSimple);

            Mat markes = Mat.Zeros(dist_8U.Size(), MatType.CV_32SC1);

            for (int i = 0; i < contours.Length; i++)
            {
                Cv2.DrawContours(markes, contours, i, OpenCvSharp.Scalar.All(i + 1), -1);
            }
            Cv2.Circle(markes, new OpenCvSharp.Point(5, 5), 3, Scalar.White); // Marker tła



            Mat SummaryThdColor = new Mat();
            Cv2.CvtColor(sumCoppy, SummaryThdColor, ColorConversionCodes.GRAY2BGR);
            //Cv2.ImShow("thdcolor", SummaryThdColor);


            Cv2.Watershed(SummaryThdColor, markes);

            Random rnd = new Random();
            Vec3b[] colors = new Vec3b[contours.Length];
            for (int i = 0; i < contours.Length; i++)
            {
                Scalar color = Scalar.RandomColor();
                colors[i] = color.ToVec3b();
            }


            Mat dst = Mat.Zeros(markes.Size(), MatType.CV_8UC3);

            /// Rozdzielenie obiektów na obrazy
            List<Mat> objects = new List<Mat>();
            for (int i = 0; i < contours.Length; i++)
            {
                objects.Add(Mat.Zeros(new OpenCvSharp.Size(159, 119), MatType.CV_8U));
            }
            List<int> Indexes = new List<int>();
            for (int i = 0; i < markes.Rows; i++)
            {
                for (int j = 0; j < markes.Cols; j++)
                {
                    int index = markes.At<int>(i, j);
                    if (index > 0 && index <= contours.Length)
                    {
                        objects[index - 1].Set<byte>(i, j, 255);
                        Console.WriteLine("Index:" + index);
                        dst.Set<Vec3b>(i, j, colors[index - 1]);
                    }
                    else
                    {
                        dst.Set<Vec3b>(i, j, Scalar.Black.ToVec3b());
                    }
                }
            }

            Mat imgTest = new Mat(markes.Size(), MatType.CV_8SC4, Scalar.Black);
            List<List<OpenCvSharp.Point>> objectPoints = new List<List<OpenCvSharp.Point>>();
            // Łaczenie
            for (int i = 0; i < objects.Count; i++)
            {
                objectPoints.Add(new List<OpenCvSharp.Point>());

                for (int x = 0; x < markes.Rows; x++)
                {
                    for (int y = 0; y < markes.Cols; y++)
                    {
                        if (objects[i].At<byte>(x, y) == 255)
                        {
                            objectPoints[i].Add(new OpenCvSharp.Point(x, y));
                            imgTest.Set<Scalar>(x, y, Scalar.White);
                        }
                    }
                }
            }


            bool[] styki = new bool[objects.Count];
            for (int i = 0; i < styki.Length; i++)
            {
                styki[i] = false;
            }

            List<List<bool>> stykniecia = new List<System.Collections.Generic.List<bool>>();
            for (int i = 0; i < objects.Count; i++)
            {
                stykniecia.Add(new List<bool>());
                for (int j = 0; j < objects.Count; j++)
                {
                    stykniecia[i].Add(false);
                }
            }

            for (int i = 0; i < objects.Count; i++)
            {
                double odlegloscX;
                double odlegloscY;
                double odleglosc = new double();
                double odlegloscStyku = new double();

                for (int j = 0; j < objects.Count; j++)
                {
                    if (i != j)
                    {
                        for (int x = 0; x < objectPoints[i].Count; x++)
                        {
                            for (int y = 0; y < objectPoints[j].Count; y++)
                            {

                                odlegloscX = Math.Abs(objectPoints[i][x].X - objectPoints[j][y].X);
                                odlegloscY = Math.Abs(objectPoints[i][x].Y - objectPoints[j][y].Y);
                                odleglosc = Math.Sqrt(Math.Pow(odlegloscX, 2) + Math.Pow(odlegloscY, 2));
                                if (odleglosc < distanceCondition)
                                {
                                    odlegloscStyku = odleglosc;
                                    //   Console.WriteLine("Obiekty: " + i + " i " + j);
                                    //   Console.WriteLine("Styk  Obj1" + objectPoints[i][x].X + " " + objectPoints[i][x].Y);
                                    //    Console.WriteLine("Styk  Obj2" + objectPoints[j][y].X + " " + objectPoints[j][y].Y);
                                    stykniecia[i][j] = true;
                                    stykniecia[j][i] = true;
                                }
                            }
                        }

                    }

                }

            }

            for (int i = 0; i < stykniecia.Count; i++)
            {
                for (int j = 0; j < stykniecia.Count; j++)
                {

                    Console.WriteLine("Czy sie stykneły? " + stykniecia[i][j] + " Objekt nr: " + i + " z Objektem nr: " + j);

                }
                Console.WriteLine();
                Console.WriteLine();
            }

            List<OpenCvSharp.Point> centreOfObj = new List<OpenCvSharp.Point>();
            for (int i = 0; i < objects.Count; i++)
            {


                int truePixX = 0;
                int truePixY = 0;
                int truePix = 0;
                for (int j = 0; j < objects[i].Rows; j++)
                {
                    for (int k = 0; k < objects[i].Cols; k++)
                    {
                        if (objects[i].At<byte>(j, k) == 255)
                        {
                            truePixX += j;
                            truePixY += k;
                            truePix++;
                        }
                    }
                }
                double centreX;
                double centreY;

                if (truePix != 0)
                {
                    centreX = truePixX / truePix;
                    centreY = truePixY / truePix;
                    Cv2.Circle(objects[i], new OpenCvSharp.Point(centreY, centreX), 3, Scalar.Black);
                    //  Cv2.ImShow(i + " obj", objects[i]);
                    Console.WriteLine(i + " obj, centreX= " + centreX + " ,centreY= " + centreY);
                    centreOfObj.Add(new OpenCvSharp.Point(centreX, centreY));
                    Cv2.PutText(dst, i.ToString(), new OpenCvSharp.Point(centreY - 5, centreX - 5), HersheyFonts.HersheyComplex, 0.5, Scalar.Green);

                }




            }

            //////////////////
            ////////////////
            for (int i = 0; i < objects.Count; i++)
            {
                Indexes.Add(i + 1);
            }
            List<int> wykonajStyki = new List<int>();
            for (int i = 0; i < objects.Count; i++)
            {
                wykonajStyki.Clear();
                for (int j = 0; j < objects.Count; j++)
                {
                    if (stykniecia[i][j])
                    {
                        wykonajStyki.Add(j);
                    }
                }
                for (int k = 0; k < wykonajStyki.Count; k++)
                {
                    int index = i;
                    Console.WriteLine("Obj 1: " + i);
                    Console.WriteLine("Obj 2: " + wykonajStyki[k]);
                    Console.WriteLine("Index 1: " + Indexes[i]);
                    Console.WriteLine("Index 2: " + Indexes[wykonajStyki[k]]);
                    for (int x = 0; x < markes.Rows; x++)
                    {
                        for (int y = 0; y < markes.Cols; y++)
                        {
                            if (markes.At<int>(x, y) == Indexes[wykonajStyki[k]])
                            {
                                markes.Set<int>(x, y, Indexes[i]);
                            }
                        }
                    }
                    Indexes[wykonajStyki[k]] = Indexes[i];
                    Console.WriteLine("Index 2: " + Indexes[k]);
                    stykniecia[i][wykonajStyki[k]] = false;
                    stykniecia[wykonajStyki[k]][i] = false;
                    Console.WriteLine("[wykonajStyki[k]" + wykonajStyki[k]);

                    if (k == wykonajStyki.Count - 1)
                    {
                        i = wykonajStyki[k] - 1;
                    }



                    Console.WriteLine("i " + i);
                }

                if (i == objects.Count - 1)
                {
                    foreach (var obj in stykniecia)
                    {
                        foreach (var itemb in obj)
                        {
                            if (itemb)
                            {
                                i = 0;
                                Console.WriteLine("Do i wpisano 0");
                            }
                        }
                    }
                }


            }


            Mat dst2 = Mat.Zeros(markes.Size(), MatType.CV_8UC3);
            objects.Clear();
            Indexes.Clear();

            for (int i = 0; i < contours.Length; i++)
            {
                objects.Add(Mat.Zeros(new OpenCvSharp.Size(159, 119), MatType.CV_8UC3));
            }


            for (int i = 0; i < markes.Rows; i++)
            {
                for (int j = 0; j < markes.Cols; j++)
                {
                    int index = markes.At<int>(i, j);

                    if (index > 0 && index <= contours.Length)
                    {
                        objects[index - 1].Set<Vec3b>(i, j, colors[index - 1]);
                        //   Console.WriteLine("Index:" + index);
                        dst2.Set<Vec3b>(i, j, colors[index - 1]);

                    }
                    else
                    {
                        dst2.Set<Vec3b>(i, j, Scalar.Black.ToVec3b());
                    }
                }
            }



            dst2 = Mat.Zeros(dst2.Rows, dst2.Cols, MatType.CV_8UC3);
            foreach (var item in objects)
            {
                Cv2.MorphologyEx(item, item, MorphTypes.Close, kernel2);
                Mat itemColor = new Mat(item.Size(), MatType.CV_8UC3);
                // Cv2.ImShow("Obj " + objects.IndexOf(item), item);
                Cv2.Add(item, dst2, dst2);
            }


            for (int i = 0; i < objects.Count; i++)
            {
                int truePixX = 0;
                int truePixY = 0;
                int truePix = 0;
                for (int j = 0; j < objects[i].Rows; j++)
                {
                    for (int k = 0; k < objects[i].Cols; k++)
                    {
                        if (objects[i].At<Vec3b>(j, k) != Scalar.Black.ToVec3b())
                        {
                            truePixX += j;
                            truePixY += k;
                            truePix++;
                        }
                    }
                }
                if (truePix != 0)
                {
                    double centreX = truePixX / truePix;
                    double centreY = truePixY / truePix;
                    Cv2.Circle(objects[i], new OpenCvSharp.Point(centreY, centreX), 3, Scalar.Black);
                    //  Cv2.ImShow(i + " obj", objects[i]);
                    Console.WriteLine(i + " obj, centreX= " + centreX + " ,centreY= " + centreY);
                    centreOfObj.Add(new OpenCvSharp.Point(centreX, centreY));
                    Cv2.PutText(dst2, i.ToString(), new OpenCvSharp.Point(centreY - 5, centreX - 5), HersheyFonts.HersheyComplex, 0.5, Scalar.Green);

                }
            }

            segmentedImages = dst2.Clone();

            //Mat markersSHow = new Mat();
            //markes.ConvertTo(markersSHow, MatType.CV_8U, 255);
            // Cv2.Normalize(markersSHow, norm, 0.0, 1.0, NormTypes.MinMax);
            //Cv2.ImShow("markers", markersSHow);

            //   Cv2.ImShow("dist", norm);

            //  Cv2.ImShow("dist8U", dist_8U);

            Cv2.Resize(dst, dst, new OpenCvSharp.Size(160 * 3.0, 120 * 3.0));
            Cv2.ImShow("dst", dst);

            Cv2.Resize(dst2, dst2, new OpenCvSharp.Size(160 * 3.0, 120 * 3.0));
            Cv2.ImShow("dst2", dst2);

            Console.WriteLine("Contours: " + contours.Length);


        }
    }
}





