using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryCalculator
{
    public interface IOperator 
    {
        char nameOperator
        {
            get;
        }
        int priorityOperator
        {
            get;
        }
        dynamic Expression(dynamic op1, dynamic op2);
    }
}
