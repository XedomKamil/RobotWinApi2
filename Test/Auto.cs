using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Auto
    {
        private int rocznik;

        


        public Auto(int rocznik)
        {
            this.rocznik = rocznik;
        }

        public int PodajRocznik()
        {
            return this.rocznik;
        }





        private int szerokoscOpony;

        public int SzerokoscOpony
        {
            get { return szerokoscOpony; }
            set { szerokoscOpony = value; }
        }









    }
}
