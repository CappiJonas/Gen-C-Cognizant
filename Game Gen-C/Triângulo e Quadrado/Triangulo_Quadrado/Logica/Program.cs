using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Logica
{
    class Program
    {
        static void Main(string[] args)
        {
            double ladoA, ladoB, ladoC, ladoQuadrado, areaTriangulo, areaQuadrado;

            Console.WriteLine("Entre com as medidas do triângulo: ");
            ladoA = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            ladoB = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            ladoC = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine();

            double p = (ladoA + ladoB + ladoC) / 2.0;
            areaTriangulo = Math.Sqrt(p * (p - ladoA) * (p - ladoB) * (p - ladoC));

            Console.WriteLine("Entre com a medida do lado do quadrado: ");
            ladoQuadrado = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine();

            areaQuadrado = Math.Pow(ladoQuadrado, 2.0);

            Console.WriteLine($"A área do triângulo é {areaTriangulo.ToString("F4", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"A área do quadrado é {areaQuadrado.ToString("F4", CultureInfo.InvariantCulture)}");

            if (areaTriangulo > areaQuadrado)
            {
                Console.WriteLine("A área do triângulo é maior que a área do quadrado");
            }
            else if (areaTriangulo == areaQuadrado)
            {
                Console.WriteLine("A área do triângulo e do quadrado são iguais");
            }
            else
            {
                Console.WriteLine("A área do quadrado é maior que a área do triângulo");
            }
            Console.ReadKey();
        }
    }
}
