using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common
{
    public class TimeRead
    {

        public List<DateTime> Read_All_Times(string filePath)
        {
            Regex rx;
            rx = new Regex(@"(?<year>\d{4})-(?<month>\d{2})-(?<day>\d{2}) (?<hour>\d{2}):(?<minute>\d{2}):(?<sec>\d{2}):\D{0,2}(?<ms>\d{1,3})");

            List<DateTime> times = new List<DateTime>();

            
            //filePath = @"C:\Users\lamko\source\RobotWinApi\RobotWinApi2\WindowsFormsApp\bin\Release\times9.times";
            var lineCount = NumerOfLines(filePath);
            using (var reader = File.OpenText(filePath))
            {
                for (int i = 0; i < lineCount; i++)
                {
                    string line = reader.ReadLine();
                    //lines.Add(line);
                    Match m = rx.Match(line);
                    
                    DateTime dat1 = new DateTime(
                     Convert.ToInt16(m.Groups["year"].Value),
                     Convert.ToInt16(m.Groups["month"].Value),
                     Convert.ToInt16(m.Groups["day"].Value),
                     Convert.ToInt16(m.Groups["hour"].Value),
                     Convert.ToInt16(m.Groups["minute"].Value),
                     Convert.ToInt16(m.Groups["sec"].Value),
                     Convert.ToInt16(m.Groups["ms"].Value)
                      );
                    times.Add(dat1);

                }
            }
            return times;
        }



        public int NumerOfLines(string filePath)
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

        public TimeSpan TimeDifference(DateTime dat1, DateTime dat2)
        {
            TimeSpan timeSpan = dat2 - dat1;
            return timeSpan;
        }

        public string GetTempFilePath(string path)
        {
            path = path.Replace("txt", "times");
                return path;
        }

    }



}
