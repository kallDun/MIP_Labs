using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                new double[3]{q, pp, pv},
                new double[3]{pp, q, pv}
            };

        }


    }
}
