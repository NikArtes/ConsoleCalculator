using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryCalculator
{
    public class CalculationWithRPN : IGeneralCalculator, IOperationWithInputStr
    {
        private readonly Dictionary<string, IOperator> arrOperators = new Dictionary<string,IOperator>();

        private int GetPriority(string symbol)
        {
            if (IsOperator(symbol))
            {
                return arrOperators[symbol].priority;
            }
            return -1;
        }

        private bool IsOperator(string symbol)
        {
            if (arrOperators.ContainsKey(symbol))
            {
                return true;
            }
            return false;
        }

        private bool IsNumber(char symbol)
        {
            if (symbol >= '0' && symbol <= '9' || symbol == ',' || symbol == '.')
            {
                return true;
            }
            return false;
        }

        public IEnumerable<ITerm> GetExpression(string input)
        {
            Stack<char> operStack = new Stack<char>();
            List<ITerm> outp = new List<ITerm>();

            
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    operStack.Push(input[i]);
                }
                else if (input[i] == ')')
                {
                    if (operStack.Count == 0)
                    {
                        throw new Exception("improper placement of parentheses");
                    }
                    char s = operStack.Pop();
                    while (s != '(')
                    {
                        outp.Add(arrOperators[s.ToString()]);
                        s = operStack.Pop();
                    }
                }
                else if (IsOperator(input[i].ToString()))
                {
                    if (operStack.Count > 0)
                    {
                        while (operStack.Count != 0 && GetPriority(input[i].ToString()) <= GetPriority(operStack.Peek().ToString()))
                        {
                            outp.Add(arrOperators[operStack.Pop().ToString()]);
                        }
                    }
                    operStack.Push(char.Parse(input[i].ToString()));
                }
                else if (IsNumber(input[i]))
                {
                    string buf = string.Empty;
                    while (IsNumber(input[i]))
                    {
                        if (input[i] == '.')
                        {
                            buf += ',';
                            i++;
                            continue;
                        }
                        buf += input[i];
                        i++;
                        if (i == input.Length)
                            break;
                    }
                    NumberClass.Number numb = new NumberClass.Number();
                    numb.Value = double.Parse(buf);
                    outp.Add(numb);
                    i--;
                }
                else
                {
                    throw new Exception("Invalid symbols in the mathematical expression");
                }
            }
            while (operStack.Count > 0)
                outp.Add(arrOperators[operStack.Pop().ToString()]);

            return outp;  
        }

        public INumber CalculateOnString(IEnumerable<ITerm> input)
        {
            Stack<ITerm> resStack = new Stack<ITerm>();
            foreach (ITerm term in input)
            {
                if (term is INumber)
                {
                    resStack.Push(term);
                }
                else if (term is IOperator)
                {
                    INumber a = resStack.Pop() as INumber;
                    INumber b = resStack.Pop() as INumber;
                    IOperator t = term as IOperator;
                    INumber res = t.Expression(b, a);
                    resStack.Push(res);
                }
            }
            return resStack.Peek() as INumber;
        }
        public INumber Calculation(string input)
        {
            IEnumerable<ITerm> output = GetExpression(input);
            return CalculateOnString(output);
            
        }
        public IGeneralCalculator AddOperator(IOperator oper)
        {
            arrOperators.Add(oper.Name, oper);
            return this;
        }
    }
}
