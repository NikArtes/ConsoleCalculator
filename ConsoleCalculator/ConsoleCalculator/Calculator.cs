using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    static class Calculator
    {
        static private Dictionary<char, int> arrOperators = new Dictionary<char,int>();

        static Calculator()
        {
            arrOperators.Add('(',0);
            arrOperators.Add(')', 1);
            arrOperators.Add('+', 2);
            arrOperators.Add('-', 2);
            arrOperators.Add('*', 3);
            arrOperators.Add('/', 3);
        }

        static private int GetPriority(char symbol)
        {
            foreach (var Op in arrOperators.Keys)
            {
                if (Op == symbol)
                {
                    return arrOperators[symbol];
                }
            }
            return -1;
        }

        static private bool IsOperator(char symbol)
        {
            if (arrOperators.ContainsKey(symbol))
            {
                return true;
            }
            return false;
        }

        static private bool IsNumber(char symbol)
        {
            if (symbol >= '0' && symbol <= '9' || symbol == ',' || symbol == '.')
            {
                return true;
            }
            return false;
        }

        static private string GetExpression(string input)
        {
            string output = string.Empty;
            Stack<char> operStack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (IsOperator(input[i]))
                {
                    if (GetPriority(input[i]) == 0)
                    {
                        operStack.Push(input[i]);
                    }
                    else if (GetPriority(input[i]) == 1)
                    {
                        char s = operStack.Pop();

                        while (GetPriority(s) != 0)
                        {
                            output += s.ToString() + ' ';
                            s = operStack.Pop();
                        }
                    }
                    else
                    {
                        if (operStack.Count > 0)
                        {
                            while (operStack.Count!=0 && GetPriority(input[i]) <= GetPriority(operStack.Peek()))
                            {
                                output += operStack.Pop().ToString() + " ";
                            }
                        }
                        operStack.Push(char.Parse(input[i].ToString()));
                    }
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

        static private double ColculateOnString(string input)
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
                    switch (input[i])
                    {
                        case '+': result = b + a; break;
                        case '-': result = b - a; break;
                        case '*': result = b * a; break;
                        case '/': result = b / a; break;
                    }
                    resStack.Push(result);
                }
            }
            return resStack.Peek();
        }

        static public string Calculation(string input)
        {
            string output = GetExpression(input);
            if (output != "error")
            {
                double result = ColculateOnString(output);
                return result.ToString();
            }
            return "Invalid symbols in the mathematical expression";
        }
    }
}
