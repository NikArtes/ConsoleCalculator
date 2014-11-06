using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryCalculator.NumberClass
{
    class Number : INumb
    {
        private dynamic numb;
        public string name
        {
            get
            {
                return numb.ToString();
            }
        }
        public dynamic value
        {
            get
            {
                return numb;
            }
            set 
            {
                numb = value;
            }
        }
    }
}
