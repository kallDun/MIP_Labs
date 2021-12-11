using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    class Program
    {
        static void Main(string[] args)
        {
            // --- 4.3.2 ---
            var A = "10101";
            var B = "01011";
            int d = 3;

            Task__4_2 task__4_2 = new Task__4_2(A, B, d);
            Console.WriteLine($"--- 4.3.2 ---\nA+B={task__4_2.GetSum()} | w = {task__4_2.GetWeight()}");
            string[] combinations = task__4_2.GetCombinations();
            Console.WriteLine($"Count of combinations: {combinations.Length}\nCombinations: {string.Join(" ", combinations)}");

            // --- 4.3.3 ---
            var A_ = "101010";
            var n = 6;
            var d_ = 3;

            Task__4_3 task__4_3 = new Task__4_3(A_, n, d_);
            string[] combinations_ = task__4_3.GetCombinations();   
            Console.WriteLine($"\n--- 4.3.3 ---\nCount of combinations: {combinations_.Length}\nCombinations: {string.Join(" ", combinations_)}");

            Console.ReadKey();
        }
    }
}
