using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryCalculator
{
    public interface IGeneralCalculator
    {
        string GetExpression(string input);
        string ColculateOnString(string input);
        int GetPriority(char symbol);
        bool IsOperator(char symbol);
        bool IsNumber(char symbol);
    }
}
