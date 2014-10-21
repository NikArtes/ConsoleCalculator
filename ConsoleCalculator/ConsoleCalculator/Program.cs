using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            Console.WriteLine("Add the mathematical expression");
            Console.WriteLine(calc.Calculation(Console.ReadLine()));
            Console.ReadKey();
        }
    }
}
