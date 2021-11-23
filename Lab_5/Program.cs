using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_5
{
    class Program
    {

        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            Console.WriteLine("Type count of symbols in one letter. " +
                "For 'AA' type 2, for 'A' - 1, for 'AAA' - 3");
            int countOfSymbols = int.Parse(Console.ReadLine());

            Console.WriteLine("Type alphabet symbol and chance like 'AA 0.15'\n" +
                "To exit TypeMenu type 'exit' or 'close'");
            Dictionary<string, double> dictionary = new();

            string key = "";
            double value;
            do
            {
                (key, value) = GetPairForDictionary();
                if (string.IsNullOrEmpty(key)) continue;
                if (dictionary.ContainsKey(key))
                {
                    Console.WriteLine("Dictionary already has this symbol!");
                    continue;
                }
                if (value >= 1 || value <= 0)
                {
                    Console.WriteLine("Chance must be between 0 and 1");
                    continue;
                }
                dictionary.Add(key, value);
            }
            while (!string.IsNullOrEmpty(key));
            if (dictionary.Sum(x => x.Value) != 1) throw new Exception("Sum of chances must be = 1");

            EffectiveCode effectiveCode = new(dictionary, countOfSymbols);
            var code = effectiveCode.CreateCode();

            var output = string.Join("\n", code.Select(x => $"symbol: {x.Key} with code: {x.Value}"));
            Console.WriteLine(output);

            var entropia = effectiveCode.GetEntropia();
            var average = effectiveCode.GetAverageNumberLength();
            var effectively_percent = Math.Abs(average - entropia) / average * 100;
            Console.WriteLine($"Entropia: {entropia}, Average: {average}, Effective: {effectively_percent}%");

            Console.ReadKey();
        }

        static (string, double) GetPairForDictionary()
        {
            var text = Console.ReadLine();
            if (string.IsNullOrEmpty(text) || text == "close" || text == "exit") return ("", 0);
            
            var typed = text.Split();
            return (typed[0], double.Parse(typed[1]));
        }
    }
}
