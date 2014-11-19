using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryCalculator
{
    public interface INumber : ITerm
    {
        new string Name
        {
            get;
        }
        dynamic Value
        {
            get;
            set;
        }
    }
}
