using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryCalculator
{
    public interface IGeneralCalculator
    {
        INumber Calculation(string input);
        IGeneralCalculator AddOperator(IOperator oper);
    }
}
