using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryCalculator.NumberClass;

namespace ClassLibraryCalculator
{
    public class divisionOperator : IOperator
    {
        public string Name
        {
            get
            {
                return "/";
            }
        }
        public int priority
        {
            get
            {
                return 3;
            }
        }
        public INumber Expression(INumber op1, INumber op2)
        {
            Number opRes = new Number();
            opRes.Value = op1.Value / op2.Value;
            return opRes;
        }
    }
}
