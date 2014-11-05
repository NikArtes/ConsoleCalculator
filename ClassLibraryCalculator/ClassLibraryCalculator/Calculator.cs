using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace ClassLibraryCalculator
{
    public class Calculator 
    {
        private readonly ColculationWithRPN GeneralCalculator = new ColculationWithRPN();

        public Calculator() { }

        public string Calculation(string input)
        {
            return GeneralCalculator.Calculation(input);
        }

        public void AddOperator(IOperator oper)
        {
            GeneralCalculator.AddOperator(oper);
        }
    }
}
