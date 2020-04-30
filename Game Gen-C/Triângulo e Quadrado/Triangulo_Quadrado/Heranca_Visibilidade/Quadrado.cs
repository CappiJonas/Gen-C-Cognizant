using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heranca_Visibilidade
{
    class Quadrado : Poligono
    {
        public double Lado;       

        public double AreaQuadrado()
        {
            return Math.Pow(Lado, 2.0);
        }
    }
}
