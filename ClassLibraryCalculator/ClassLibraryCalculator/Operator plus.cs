using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryCalculator
{
    public class Operator_plus : IOperator
    {
        public char nameOperator
        {
            get
            { 
                return '+';
            }
        }
        public int priorityOperator
        {
            get 
            {
                return 2;
            }
        }
        public dynamic Expression(dynamic op1, dynamic op2)
        {
            return op1 + op2;
        }
    }
}
