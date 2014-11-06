﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryCalculator
{
    public interface IOperator : ITemp
    {
        string name
        {
            get;
        }
        int priority
        {
            get;
        }
        INumb Expression(INumb op1, INumb op2);
    }
}
