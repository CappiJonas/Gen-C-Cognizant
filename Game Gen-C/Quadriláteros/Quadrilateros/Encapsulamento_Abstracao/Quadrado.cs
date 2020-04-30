using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulamento_Abstracao
{
    class Quadrado : Quadrilatero
    {
        public double Lado { get; set; }

        public double AreaQuadrado()
        {
            return Math.Pow(Lado, 2.0);
        }
    }
}
