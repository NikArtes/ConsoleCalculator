using ClassLibraryCalculator.NumberClass;

namespace ClassLibraryCalculator
{
    public class PlusOperator : IOperator
    {
        public string Name
        {
            get
            { 
                return "+";
            }
        }
        public int Priority
        {
            get 
            {
                return 2;
            }
        }
        public INumber Expression(INumber op1, INumber op2)
        {
            var opRes = new Number {Value = op1.Value + op2.Value};
            return opRes;
        }
    }
}
