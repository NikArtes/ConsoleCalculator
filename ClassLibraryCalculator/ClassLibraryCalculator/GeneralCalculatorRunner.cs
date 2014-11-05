using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryCalculator
{
    class GeneralCalculatorRunner
    {
        private IGeneralCalculator GeneralCalculator = null;

        public GeneralCalculatorRunner(IGeneralCalculator _GeneralCalculator)
        {
            GeneralCalculator = _GeneralCalculator;
        }
        public string Calculation(string input)
        {
            string output = GeneralCalculator.GetExpression(input);
            if (output == "error")
                return "Invalid symbols in the mathematical expression";
            return GeneralCalculator.ColculateOnString(output);
        }
    }
}
