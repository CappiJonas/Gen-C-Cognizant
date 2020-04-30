using System;
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
            Triangulo triangulo;
            Quadrado quadrado;

            triangulo = new Triangulo();
            quadrado = new Quadrado();

            Console.WriteLine("Entre com as medidas do triângulo: ");
            triangulo.LadoA = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            triangulo.LadoB = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            triangulo.LadoC = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine();

            Console.WriteLine("Entre com a medida do lado do quadrado: ");
            quadrado.Lado = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine();

            Console.WriteLine($"A área do triângulo é {triangulo.Area().ToString("F4", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"A área do quadrado é {quadrado.Area().ToString("F4", CultureInfo.InvariantCulture)}");

            if (triangulo.Area() > quadrado.Area())
            {
                Console.WriteLine("A área do triângulo é maior que a área do quadrado");
            }
            else if (triangulo.Area() == quadrado.Area())
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
