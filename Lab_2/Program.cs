using System;

namespace Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("To turn crossover for user press 'U' or 'З' in ukrainian,\n" +
                "to exit application press 'ESC'.\n");

            int timer = 1;
            bool in_cycle = true;
            TrafficLight trafficLight = new();

            trafficLight.ChangeState += (State st) 
                => Console.WriteLine($"State is {st} time is {timer++}");
            trafficLight.Start();

            while (in_cycle)
            {
                var button = Console.ReadKey(true).Key;
                switch (button)
                {
                    case ConsoleKey.P:
                        Console.WriteLine("User pressed 'З'");
                        trafficLight.AllowCrossOver();
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("User pressed 'ESC'");
                        in_cycle = false;
                        trafficLight.Stop();
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}
