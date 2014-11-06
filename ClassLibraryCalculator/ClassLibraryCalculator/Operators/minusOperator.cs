using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryCalculator.NumberClass;

namespace ClassLibraryCalculator
{
    public class minusOperator : IOperator
    {
        public string name
        {
            get
            { 
                return "-";
            }
        }
        public int priority
        {
            get
            {
                return 2;
            }
        }
        public INumb Expression(INumb op1, INumb op2)
        {
            Number opRes = new Number();
            opRes.value = op1.value - op2.value;
            return opRes;
        }
    }
}
