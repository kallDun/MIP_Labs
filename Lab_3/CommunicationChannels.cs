using System;
using System.Linq;

namespace Lab_3
{
    class CommunicationChannels
    {
        private double v0;
        private double[][] original_matrix, matrix;
        private double[] pX;
        private double[] pY;
        public CommunicationChannels(double[][] input_matrix, double v0)
        {
            pY = input_matrix.Select(x => x.Sum()).ToArray();
            pX = new double[input_matrix[0].Length];
            for (int i = 0; i < pX.Length; i++)
            {
                for (int j = 0; j < input_matrix.Length; j++)
                {
                    pX[i] += input_matrix[j][i];
                }
            }

            matrix = input_matrix
                .Select(x => Enumerable.Range(0, x.Length)
                .Select(s => x[s] / pX[s])
                .ToArray())
                .ToArray();
            original_matrix = input_matrix;
            this.v0 = v0;
        }

        public double[][] Matrix => matrix;
        public double T => 1.0 / v0;
        public double C => v0 * Math.Abs(Math.Log(matrix[0].Length, 2) + matrix[0].Select(x => x * Math.Log(x, 2)).Sum());
        public double I => Enumerable.Range(0, original_matrix.Length)
            .Select(i => Enumerable.Range(0, original_matrix[i].Length)
            .Select(j => original_matrix[i][j] * Math.Log(original_matrix[i][j] / (pX[i] * pY[j]), 2)).Sum())
            .Sum();
        public double I_ => I * v0;
    }
}
