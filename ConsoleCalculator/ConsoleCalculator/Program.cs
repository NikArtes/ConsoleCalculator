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
            Console.WriteLine("Add the mathematical expression");
            Console.WriteLine(Calculator.Calculation(Console.ReadLine()));
            Console.ReadKey();
        }
    }
}
