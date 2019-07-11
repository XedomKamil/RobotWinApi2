using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
//using OpenCvSharp;

namespace CommonTest
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()

        {
            FileOperations fileOperations = new FileOperations();
            ImageOperations imageOperations = new ImageOperations();
            /*
            string currentPath = (@"E:\PBL\Prof Białecki Programy\wetransfer-9d2a73\Nowy folder\view frame\WindowsFormsApp1\WindowsFormsApp1\bin\Debug\temps.txt");
            fileOperations.ReadFile22(currentPath, 0);
            Console.WriteLine(fileOperations.liczba2.Length);
            imageOperations.CreateImage22(fileOperations.liczba2);
            Console.WriteLine(imageOperations.imageGray.Size());
            Console.WriteLine(imageOperations.imageGray.Data);
            Cv2.ImShow("ss",imageOperations.imageGray);*/
        }


        [TestMethod]
        public void TestMethodOLD()

        {
            /*
            FileOperations fileOperations = new FileOperations();
            ImageOperations imageOperations = new ImageOperations();

            string currentPath = (@"E:\PBL\Prof Białecki Programy\wetransfer-9d2a73\Nowy folder\view frame\WindowsFormsApp1\WindowsFormsApp1\bin\Debug\temps.txt");
            fileOperations.ReadFile(currentPath, 0);
            Console.WriteLine(fileOperations.liczba2.Length);
            imageOperations.CreateImage(fileOperations.liczba2);
            Console.WriteLine(imageOperations.imageGray.Size());
            Console.WriteLine(imageOperations.imageGray.Data);
            */
        }

    }
}
