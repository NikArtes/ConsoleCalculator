using System;
using ClassLibraryCalculator;

namespace TestProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var calculator = new CalculationWithRPN();
                calculator.AddOperator(new PlusOperator()).AddOperator(new MinusOperator()).AddOperator(new DivisionOperator()).AddOperator(new MultiplicationOperator());
                Console.WriteLine("Add the mathematical expression");
                Console.WriteLine(calculator.Calculation(Console.ReadLine()).Name);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }

        }
    }
}
