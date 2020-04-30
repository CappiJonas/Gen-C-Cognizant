using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_Metodos_Atributos
{
    class Quadrado
    {
        public double lado;

        public double AreaQuadrado()
        {
            return Math.Pow(lado, 2.0);
        }
    }
}
