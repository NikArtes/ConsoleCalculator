using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryCalculator
{
    public interface INumb : ITemp
    {
        string name
        {
            get;
        }
        dynamic value
        {
            get;
            set;
        }
    }
}
