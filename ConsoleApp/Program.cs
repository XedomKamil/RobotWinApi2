using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread th = new Thread();

            FileOperations fileOperations = new FileOperations();
            fileOperations.ReadFile();
            fileOperations.CreateImage();

            Console.ReadLine();
        }
    }
}
