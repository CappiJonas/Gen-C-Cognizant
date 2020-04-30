using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulamento_Abstração
{
    class Triangulo : Poligono
    {
        public double LadoA { get; set; }
        public double LadoB { get; set; }
        public double LadoC { get; set; }

        public Triangulo()
        {

        }

        public Triangulo(double ladoA, double ladoB, double ladoC)
        {
            LadoA = ladoA;
            LadoB = ladoB;
            LadoC = ladoC;
        }

        public double AreaTriangulo()
        {
            double p = (LadoA + LadoB + LadoC) / 2.0;
            return Math.Sqrt(p * (p - LadoA) * (p - LadoB) * (p - LadoC));
        }
    }
}
