using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryCalculator
{
    class ColculationWithRPN : IGeneralCalculator
    {
        private Dictionary<char, IOperator> arrOperators = new Dictionary<char,IOperator>();

        public ColculationWithRPN()
        {
            plusOperator plus = new plusOperator();
            minusOperator minus = new minusOperator();
            multiplicationOperator multiplication = new multiplicationOperator();
            divisionOperator division = new divisionOperator();
            AddOperator(plus);
            AddOperator(minus);
            AddOperator(multiplication);
            AddOperator(division);
        }

        public string Calculation(string input)
        {
            return (new GeneralCalculatorRunner(new ColculationWithRPN())).Calculation(input);
        }

        public int GetPriority(char symbol)
        {
            if (IsOperator(symbol))
            {
                return arrOperators[symbol].priorityOperator;
            }
            return -1;
        }

        public bool IsOperator(char symbol)
        {
            if (arrOperators.ContainsKey(symbol))
            {
                return true;
            }
            return false;
        }

        public bool IsNumber(char symbol)
        {
            if (symbol >= '0' && symbol <= '9' || symbol == ',' || symbol == '.')
            {
                return true;
            }
            return false;
        }

        public string GetExpression(string input)
        {
            string output = string.Empty;
            Stack<char> operStack = new Stack<char>();

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
                        return "error";
                    }
                    char s = operStack.Pop();
                    while (s != '(')
                    {
                        output += s.ToString() + ' ';
                        s = operStack.Pop();
                    }
                }
                else if (IsOperator(input[i]))
                {
                    if (operStack.Count > 0)
                    {
                        while (operStack.Count != 0 && GetPriority(input[i]) <= GetPriority(operStack.Peek()))
                        {
                            output += operStack.Pop().ToString() + " ";
                        }
                    }
                    operStack.Push(char.Parse(input[i].ToString()));
                }
                else if (IsNumber(input[i]))
                {
                    while (IsNumber(input[i]))
                    {
                        if (input[i] == '.')
                        {
                            output += ',';
                            i++;
                            continue;
                        }
                        output += input[i];
                        i++;
                        if (i == input.Length)
                            break;
                    }
                    output += " ";
                    i--;
                }
                else
                {
                    return "error";
                }
            }
            while (operStack.Count > 0)
                output += operStack.Pop() + " ";

            return output;
        }

        public string ColculateOnString(string input)
        {
            double result = 0;
            Stack<double> resStack = new Stack<double>();
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    string buf = string.Empty;
                    while (input[i] != ' ' && !IsOperator(input[i]))
                    {
                        buf += input[i];
                        i++;
                        if (i == input.Length)
                            break;
                    }
                    resStack.Push(double.Parse(buf));
                    i--;
                }
                else if (IsOperator(input[i]))
                {
                    double a = resStack.Pop();
                    double b = resStack.Pop();
                    result = arrOperators[input[i]].Expression(b, a);
                    resStack.Push(result);
                }
            }
            return resStack.Peek().ToString();
        }

        public void AddOperator(IOperator oper)
        {
            arrOperators.Add(oper.nameOperator, oper);
        }
    }
}
