using System;

namespace Lab_3
{
    class Calc
    {
        private double q, Pp, Pv, P0;
        private double[][] matrix;
        public Calc(double q, double pp, double pv, double p0)
        {
            this.q = q;
            Pp = pp;
            Pv = pv;
            P0 = p0;

            matrix = new double[2][]
            {
                new double[3] { q, pp, pv },
                new double[3] { pp, q, pv },
            };

        }

        public double[][] Matrix => matrix;
        public double MaxH_Y => -1 * (2 * (((q + Pp) / 2) * Math.Log((q + Pp) / 2, 2)) + Pv * Math.Log(Pv, 2));
        public double H_Y_X1 => -1 * (q * Math.Log(q, 2) + Pp * Math.Log(Pp, 2) + Pv * Math.Log(Pv, 2));
        public double C => P0 * Math.Abs(MaxH_Y - H_Y_X1);
    }
}
