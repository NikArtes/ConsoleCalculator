using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryCalculator
{
    interface IOperationWithInputStr
    {
        IEnumerable<ITemp> GetExpression(string input);
        INumb ColculateOnString(IEnumerable<ITemp> input);
    }
}
