using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulamento_Abstração
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

        //public double Lado
        //{
        //    get { return _lado; }
        //    set 
        //    { 
        //        if (value > 0)
        //        {
        //            _lado = value;
        //        }
        //    }
        //}


        //public void SetLado(double lado)
        //{
        //    _lado = lado;
        //}

        //public double GetLado()
        //{
        //    return _lado;
        //}

        public double AreaQuadrado()
        {
            return Math.Pow(Lado, 2.0);
        }
    }
}
