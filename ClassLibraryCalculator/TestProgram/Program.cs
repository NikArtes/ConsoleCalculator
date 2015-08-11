using System;
using ClassLibraryCalculator;
using log4net;

namespace TestProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var logger = LogManager.GetLogger(typeof (Program));
                log4net.Config.DOMConfigurator.Configure();
                var calculator = new CalculationWithRPN();
                calculator.AddOperator(new PlusOperator()).AddOperator(new MinusOperator()).AddOperator(new DivisionOperator()).AddOperator(new MultiplicationOperator());
                Console.WriteLine("Add the mathematical expression");
                
                var result = calculator.Calculation(Console.ReadLine());
                logger.Info(string.Format("Результат = {0}", result.Name));

                Console.WriteLine(result.Name);
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
