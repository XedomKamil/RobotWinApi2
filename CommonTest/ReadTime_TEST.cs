using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using System.Collections.Generic;
using System.IO;

namespace CommonTest
{
    [TestClass]
    public class ReadTime_TEST
    {
        [TestMethod]
        public void TestMethod1()
        {
            string currentPath = @"C:\Users\lamko\source\RobotWinApi\RobotWinApi2\WindowsFormsApp\bin\Release";
            //string currentPath = Directory.GetCurrentDirectory();
            if (currentPath[currentPath.Length - 1] != '\\')
            {
                currentPath += "\\";
            };
            currentPath += "temps9.txt";


            string customFormat = "yyyy-MM-dd HH:mm:ss:fff";
            TimeRead timeRead = new TimeRead();

            List<DateTime> times;
            string Path = timeRead.GetTempFilePath(currentPath);
            Console.WriteLine(Path);
            times = timeRead.Read_All_Times(Path);
            

           // Console.WriteLine(timeRead.TimeDifference(times[0], times[50]));
            foreach (var item in times)
            {
                Console.WriteLine(item.ToString(customFormat));
            }
            
          //  Console.WriteLine(time.Count);
        }
    }



}
