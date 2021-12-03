using System;
using System.Linq;

namespace Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // --- 3.1
            double v0 = 75;
            double[][] input_matrix = new double[3][]
            {
                new double[3] { 0.360, 0.016, 0.012 },
                new double[3] { 0.024, 0.360, 0.008 },
                new double[3] { 0.016, 0.024, 0.180 }
            };

            CommunicationChannels comm = new CommunicationChannels(input_matrix, v0);
            Console.WriteLine($"Matrix = \n{string.Join("\n", comm.Matrix.Select(x => string.Join(" ", x)))}" +
                $"\n\nT = {comm.T}\nC = {comm.C}\nI(X,Y) = {comm.I}\nI- = {comm.I_}\n");

            // --- 3.2
            double q = 0.87;
            double Pп = 0.01;
            double Pв = 0.12;
            double V_0 = 120;

            Calc calc = new Calc(q, Pп, Pв, V_0);
            Console.WriteLine($"Matrix = \n{string.Join("\n", calc.Matrix.Select(x => string.Join(" ", x)))}" +
                $"\n\nmax_H(Y) = {calc.MaxH_Y}\nH(Y/x1) = {calc.H_Y_X1}\nC = {calc.C}\n");
        }
    }
}
