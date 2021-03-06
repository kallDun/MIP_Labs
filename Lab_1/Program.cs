using Lab_1.Classes;
using System;
using System.Threading;

namespace Lab_1
{
    class Program
    {
        static InformationImpactProcess process;
        static DateTime start_date = new(2021, 01, 01);

        static void Main(string[] args)
        {
            ImpactModel leading = new(rangeMin: 0.5, rangeMax: 0.8, intensity: 5, perceptionCofficient: 1);
            ImpactModel coordinator1 = new(rangeMin: 0.3, rangeMax: 0.4, intensity: 10, perceptionCofficient: 0.85);
            ImpactModel coordinator2 = new(rangeMin: 0.25, rangeMax: 0.3, intensity: 12, perceptionCofficient: 0.75);

            process = new(start_date, leading, coordinator1, coordinator2);
            new Thread(Update).Start();

            Console.WriteLine("Program started!");
            Console.ReadKey();
        }

        private static void Update()
        {
            while (process.State != States.Completion)
            {
                Console.WriteLine($"Day: {string.Format("{0:00}/{1:00}/{2}", process.Date.Day, process.Date.Month, process.Date.Year)}, " +
                    $"Saved memory: {string.Format("{0:0.00}", process.Memory)}, State: {process.State};");

                Thread.Sleep(500);
                process.ChangeDay();
            }
            Console.WriteLine($"State: {process.State}. Guy started doing his work in {(process.Date - start_date).Days} days");
        }
    }
}
