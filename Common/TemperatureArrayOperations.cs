using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// 
    /// </summary>
    public class TemperatureArrayOperations
    {

        /// <summary>
        /// Konwertuje tablice Ushort do Double
        /// </summary>
        /// <param name="tempsUshort"></param>
        /// <returns></returns>
        public double[,] UshortToDouble(ushort[,] tempsUshort)
        {
            double[,] tempArray = new double[120, 160];
            for (int j = 0; j < 160; j++)
            {
                for (int i = 0; i < 120; i++)
                {
                    tempArray[i, j] = (double)(tempsUshort[i, j] - 1000.0) / 10.0;

                }
            }
            return tempArray;
        }

        /// <summary>
        /// Odszukanie min i max temperatury w tablicy typu double
        /// </summary>
        /// <param name="TempArray"></param>
        public void FindMinMaxTemp(double[,] TempArray)
        {
            try
            {
                double min = 9999;
                double max = -9999;
                double tempT;
                // Znalezenie minimalnej i maksymalnej temperatury na obrazie
                for (int i = 0; i <= 160; i++)
                {
                    for (int j = 0; j <= 120; j++)
                    {
                        tempT = TempArray[i, j];
                        if ((tempT < min) & (tempT > 0)) { min = tempT; }
                        if (tempT > max) { max = tempT; }
                    }
                }
                this.minT = min;
                this.maxT = max;
            }
            catch { }

        }

        /// <summary>
        /// Transpozycja macierzy double
        /// </summary>
        /// <param name="TempArray"></param>
        /// <returns></returns>
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


        private double MinT;
        public double minT
        {
            get { return MinT; }
            set { MinT = value; }
        }
        private double MaxT;
        public double maxT
        {
            get { return MaxT; }
            set { MaxT = value; }
        }


    }
}
