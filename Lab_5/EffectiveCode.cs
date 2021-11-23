using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_5
{
    class EffectiveCode
    {
        int countOfSymbols;
        Dictionary<string, double> dictionary;
        Dictionary<string, string> combination = new();
        public EffectiveCode(Dictionary<string, double> dictionary, int countOfSymbols)
        {
            this.dictionary = dictionary;
            this.countOfSymbols = countOfSymbols;
            foreach (var item in dictionary)
            {
                combination.Add(item.Key, "");
            }
        }

        public Dictionary<string, string> CreateCode()
        {
            var sorted = dictionary.OrderBy(x => -x.Value).Select(x => x.Key).ToList();
            SplitArrayAndTypeCode(sorted);
            return combination;
        }

        private void SplitArrayAndTypeCode(List<string> list)
        {
            if (list.Count <= 1) return;

            int divide_in = 1;
            double delta = -1;
            for (int i = 1; i < list.Count; i++)
            {
                double sum_first_part = 0, sum_second_part = 0;
                for (int j = 0; j < i; j++) sum_first_part += dictionary[list[j]];
                for (int j = i; j < list.Count; j++) sum_second_part += dictionary[list[j]];

                var new_delta = Math.Abs(sum_first_part - sum_second_part);
                if (new_delta == 0 || i == list.Count - 1)
                {
                    divide_in = i;
                    break;
                }
                if (delta != -1 && new_delta > delta)
                {
                    divide_in = i - 1;
                    break;
                }
                delta = new_delta;
            }

            var list_1 = list.Take(divide_in).ToList();
            var list_2 = list.Skip(divide_in).ToList();

            list_1.ForEach(x => combination[x] += "1");
            list_2.ForEach(x => combination[x] += "0");

            SplitArrayAndTypeCode(list_1);
            SplitArrayAndTypeCode(list_2);
        }

        public double GetEntropia()
            => dictionary.Select(x => -1 * x.Value * Math.Log(x.Value, 2)).Sum();
        public double GetAverageNumberLength()
            => dictionary.Select(x => x.Value * combination[x.Key].Length).Sum() / countOfSymbols;
    }
}
