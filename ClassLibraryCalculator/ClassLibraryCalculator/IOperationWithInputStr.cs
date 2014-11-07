using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryCalculator
{
    interface IOperationWithInputStr
    {
        IEnumerable<ITerm> GetExpression(string input);
        INumber CalculateOnString(IEnumerable<ITerm> input);
    }
}
