using System;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonTest
{
    [TestClass]
    public class GetUpperDirTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            string path = (@"E:\PBL\Prof Białecki Programy\wetransfer-9d2a73\Nowy folder\view frame\WindowsFormsApp1\WindowsFormsApp1\bin\Debug\");

            FileOperations fileOperations = new FileOperations();
            fileOperations.GetUpperDirectory(path);

            string[] subDirs = fileOperations.GetFoldersInDir(path);
            foreach (var subDir in subDirs)
            {
                fileOperations.GetUpperDirectory(subDir);

            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            path = (@"E:\PBL\Prof Białecki Programy\wetransfer-9d2a73\Nowy folder\view frame\WindowsFormsApp1\WindowsFormsApp1\bin\");
            string[] subDirs2 = fileOperations.GetFoldersInDir(path);
            foreach (var subDir in subDirs2)
            {
                fileOperations.GetUpperDirectory(subDir);
                Console.Write("!!!!!Name of folder= ");
                Console.WriteLine(fileOperations.GetNameOfDir(subDir));
            }




        }
    }
}
