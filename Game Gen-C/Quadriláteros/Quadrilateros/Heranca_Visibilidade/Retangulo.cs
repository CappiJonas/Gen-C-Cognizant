using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heranca_Visibilidade
{
    class Retangulo : Quadrilatero
    {
        public double _base;
        public double altura;

        public double AreaRetangulo()
        {
            return _base * altura;
        }
    }
}
