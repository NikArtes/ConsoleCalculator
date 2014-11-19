using System;
using ClassLibraryCalculator.NumberClass;

namespace ClassLibraryCalculator
{
    public class DivisionOperator : IOperator
    {
        public string Name
        {
            get
            {
                return "/";
            }
        }

        public int Priority
        {
            get
            {
                return 3;
            }
        }
        public INumber Expression(INumber op1, INumber op2)
        {
            var opRes = new Number();
            if (op2.Value == 0)
            {
                throw new Exception("you can not divide by zero");
            }
            opRes.Value = op1.Value / op2.Value;
            return opRes;
        }
    }
}
