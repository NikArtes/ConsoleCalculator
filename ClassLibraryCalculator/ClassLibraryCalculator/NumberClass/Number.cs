using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryCalculator.NumberClass
{
    public class Number : INumber
    {
        public string Name
        {
            get
            {
                return Value.ToString();
            }
        }
        public dynamic Value
        {
            get;
            set;
        }
    }
}
