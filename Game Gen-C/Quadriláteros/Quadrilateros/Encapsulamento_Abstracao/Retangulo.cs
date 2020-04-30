using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulamento_Abstracao
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

        //public double Base
        //{
        //    get { return _base; }
        //    set
        //    { 
        //        if (value > 0.0)
        //        {
        //            _base = value;
        //        }
        //    }
        //}

        //public double Altura
        //{
        //    get { return _altura; }
        //    set 
        //    {
        //        if (value > 0.0)
        //        {
        //            _altura = value;
        //        }
        //    }
        //}


        //public void SetBase(double bse)
        //{
        //    _base = bse;
        //}

        //public double GetBase()
        //{
        //    return _base;
        //}

        //public void SetAltura(double altura)
        //{
        //    _altura = altura;
        //}

        //public double GetAltura()
        //{
        //    return _altura;
        //}
        public double AreaRetangulo()
        {
            return Base * Altura;
        }
    }
}
