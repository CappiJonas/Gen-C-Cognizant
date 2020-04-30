﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Polimorfismo
{
    class Program
    {
        static void Main(string[] args)
        {
            Retangulo retangulo = new Retangulo();
            Quadrado quadrado = new Quadrado();

            Console.WriteLine("Entre com as medidas do retângulo: ");
            retangulo.Base = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            retangulo.Altura = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine();


            Console.WriteLine("Entre com a medida do lado do quadrado: ");
            quadrado.Lado = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine();

            Console.WriteLine($"A área do retângulo é {retangulo.Area().ToString("F4", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"A área do quadrado é {quadrado.Area().ToString("F4", CultureInfo.InvariantCulture)}");

            if (retangulo.Area() > quadrado.Area())
            {
                Console.WriteLine("A área do retângulo é maior que a área do quadrado");
            }
            else if (retangulo.Area() == quadrado.Area())
            {
                Console.WriteLine("A área do retângulo e do quadrado são iguais");
            }
            else
            {
                Console.WriteLine("A área do quadrado é maior que a área do retângulo");
            }
            Console.ReadKey();
        }
    }
}
