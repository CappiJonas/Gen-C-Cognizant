using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polimorfismo
{
    class Retangulo : Quadrilatero
    {
        public double Base { get; set; }
        public double Altura { get; set; }

        public Retangulo()
        {

        }

        public Retangulo(double bse, double altura)
        {
            Base = bse;
            Altura = altura;
        }

        public override double Area()
        {
            return Base * Altura;
        }
    }
}
