using Lab_1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_1
{
    class Program
    {
        static DateTime date;
        static InformationImpactProcess process;

        static void Main(string[] args)
        {
            date = new DateTime(01, 01, 2021);
            //ImpactModel 

            //process = new(date, );
            new Thread(Update).Start();
            Console.WriteLine("Program started!");
        }

        private static void Update()
        {

        }
    }
}
