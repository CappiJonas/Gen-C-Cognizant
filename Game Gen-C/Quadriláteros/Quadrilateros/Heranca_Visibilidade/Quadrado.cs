using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heranca_Visibilidade
{
    class Quadrado : Quadrilatero
    {
        public double lado;

        public double AreaQuadrado()
        {
            return Math.Pow(lado, 2.0);
        }
    }
}
