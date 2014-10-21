using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryCalculator;

namespace TestProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            Console.WriteLine("Add the mathematical expression");
            Console.WriteLine(calculator.Calculation(Console.ReadLine()));
            Console.ReadKey();

        }
    }
}
