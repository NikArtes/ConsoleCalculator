﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryCalculator
{
    public interface IOperator : ITerm
    {
        new string Name
        {
            get;
        }
        int Priority
        {
            get;
        }
        INumber Expression(INumber op1, INumber op2);
    }
}
