using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common
{
    public class DirOperations
    {




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

            #region ConsoleWrite
            // Wypisuje wszystkie subfoldery
            // foreach (var subDir in subdirectoryEntries)
            // {
            //      Console.Write("Sub dir: ");
            //      Console.WriteLine(subDir);
            //  }
            #endregion

            return subdirectoryEntries;
        }




        public string GetNameOfDir(string dirpath)
        {
            string folder = new DirectoryInfo(dirpath).Name;
            return folder;
        }





        /// <summary>
        /// Zwraca ścieżke katalogu wyżej
        /// </summary>
        /// <param name="dirPath">Scieżka katalogu</param>
        /// <returns></returns>
        public string GetUpperDirectory(string dirPath)
        {
            #region ConsoleWrite
            // Console.WriteLine("Otrzymano dir: ");
            // Console.WriteLine(dirPath);
            // Sprawdzanie ilości znaku "\"
            #endregion
            #region workAround
            /*
            if (dirPath[length-1]!='\\')
            {
                dirPath += "\\";
            }
            length = dirPath.Length;
            */
            #endregion

            int length = dirPath.Length;
            int countSlash = dirPath.Count(f => f == '\\');
            countSlash--;
            string upperDir = "";


            int getShalshCount = 0;

            for (int i = 0; i < length; i++)
            {
                if (dirPath[i].Equals('\\'))
                {
                    //Console.WriteLine("Dostano \\");
                    getShalshCount++;
                }
                if (getShalshCount != countSlash)
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


        private List<string> FilesList;
        public List<string> filesList
        {
            get { return FilesList; }
            set { FilesList = value; }
        }


    }
}
