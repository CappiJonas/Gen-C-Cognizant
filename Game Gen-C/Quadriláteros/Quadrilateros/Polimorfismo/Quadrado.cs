using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polimorfismo
{
    class Quadrado : Quadrilatero
    {
        public double Lado { get; set; }

        public override double Area()
        {
            return Math.Pow(Lado, 2.0);
        }
    }
}
