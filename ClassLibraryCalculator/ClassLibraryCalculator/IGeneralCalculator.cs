﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryCalculator
{
    public interface IGeneralCalculator
    {
        INumb Calculation(string input);
        void AddOperator(IOperator oper);
    }
}
