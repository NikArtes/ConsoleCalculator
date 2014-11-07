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
            try
            {
                plusOperator plus = new plusOperator();
                minusOperator minus = new minusOperator();
                multiplicationOperator multiplication = new multiplicationOperator();
                divisionOperator division = new divisionOperator();
                CalculationWithRPN calculator = new CalculationWithRPN();
                calculator.AddOperator(plus).AddOperator(minus).AddOperator(division).AddOperator(multiplication);
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
