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
            double b, altura, lado, areaRetangulo, areaQuadrado;

            Console.WriteLine("Entre com as medidas do retângulo: ");
            b = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            altura = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine();

            areaRetangulo = b * altura;

            Console.WriteLine("Entre com a medida do lado do quadrado: ");
            lado = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine();

            areaQuadrado = Math.Pow(lado, 2.0);

            Console.WriteLine($"A área do retângulo é {areaRetangulo.ToString("F4", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"A área do quadrado é {areaQuadrado.ToString("F4", CultureInfo.InvariantCulture)}");

            if (areaRetangulo > areaQuadrado)
            {
                Console.WriteLine("A área do retângulo é maior que a área do quadrado");
            }
            else if (areaRetangulo == areaQuadrado)
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
