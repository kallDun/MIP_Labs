using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    static class CodeHelper
    {
        public static string Sum(string code1, string code2)
        {
            if (code1.Length != code2.Length) throw new IndexOutOfRangeException("Codes must have the same length!");

            string code3 = "";
            for (int i = 0; i < code1.Length; i++)
            {
                code3 += code1[i] == code2[i] ? '0' : '1';
            }
            return code3;
        }

        public static string[] GenerateAllCombinationsByDistance(string code, int distance)
        {
            var n = code.Length;
            weight_combinations = new List<string>();
            GenerateWeightCombinations(n, distance);
            return weight_combinations.Select(s => Sum(s, code)).ToArray();
        }

        private static List<string> weight_combinations;
        private static void GenerateWeightCombinations(int length, int weight, int position = 1, string code = "")
        {
            var count = length - code.Length;
            for (int i = 0; i < count; i++)
            {
                if (position == weight)
                {
                    weight_combinations.Add(code + "1" + string.Join("", Enumerable.Range(0, length - code.Length - 1).Select(x => "0")));
                }
                else
                {
                    GenerateWeightCombinations(length, weight, position + 1, code + "1");
                }
                code += "0";
            }
        }

    }
}
