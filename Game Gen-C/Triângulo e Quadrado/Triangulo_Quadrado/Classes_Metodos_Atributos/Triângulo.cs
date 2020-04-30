using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_Metodos_Atributos
{
    class Triangulo
    {
        public double LadoA;
        public double LadoB;
        public double LadoC;

        public double AreaTriangulo()
        {
            double p = (LadoA + LadoB + LadoC) / 2.0;
            return Math.Sqrt(p * (p - LadoA) * (p - LadoB) * (p - LadoC));
        }
    }
}
