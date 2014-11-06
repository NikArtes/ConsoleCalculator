using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryCalculator
{
    public class ColculationWithRPN : IGeneralCalculator, IOperationWithInputStr
    {
        private Dictionary<string, IOperator> arrOperators = new Dictionary<string,IOperator>();

        public ColculationWithRPN()
        {
        }

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

        public IEnumerable<ITemp> GetExpression(string input)
        {
            Stack<char> operStack = new Stack<char>();
            List<ITemp> outp = new List<ITemp>();

            
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
                    numb.value = double.Parse(buf);
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

        public INumb ColculateOnString(IEnumerable<ITemp> input)
        {
            Stack<ITemp> resStack = new Stack<ITemp>();
            foreach (ITemp temp in input)
            {
                if (temp is INumb)
                {
                    resStack.Push(temp);
                }
                else if (temp is IOperator)
                {
                    INumb a = resStack.Pop() as INumb;
                    INumb b = resStack.Pop() as INumb;
                    IOperator t = temp as IOperator;
                    INumb res = t.Expression(b, a);
                    resStack.Push(res);
                }
            }
            return resStack.Peek() as INumb;
        }
        public INumb Calculation(string input)
        {
            IEnumerable<ITemp> output = GetExpression(input);
            return ColculateOnString(output);
            
        }
        public void AddOperator(IOperator oper)
        {
            arrOperators.Add(oper.name, oper);
        }
    }
}
