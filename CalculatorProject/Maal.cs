using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorProject
{
    class Maal :IOperator
    {
        public double Berekening(double a, double b)
        {
            return a * b;
        }
    }
}
