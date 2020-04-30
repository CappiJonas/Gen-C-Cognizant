using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_Metodos_Atributos
{
    class Quadrado
    {
        public double Lado;

        public double AreaQuadrado()
        {
            return Math.Pow(Lado, 2.0);
        }
    }
}
