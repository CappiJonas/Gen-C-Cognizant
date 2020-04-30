using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polimorfismo
{
    class Quadrado : Poligono
    {
        public double Lado { get; set; }

        public Quadrado()
        {

        }

        public Quadrado(double lado)
        {
            Lado = lado;
        }

        public override double Area()
        {
            return Math.Pow(Lado, 2.0);
        }
    }
}
