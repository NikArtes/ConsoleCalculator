using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryCalculator;
using ClassLibraryCalculator.NumberClass;

namespace ClassLibraryCalculatorTests
{
    class Class1 : IEqualityComparer<List<ITerm>>
    {

        bool IEqualityComparer<List<ITerm>>.Equals(List<ITerm> x, List<ITerm> y)
        {
            bool fres=false;
            if (x.Count() == y.Count())
            {
                for (int i = 0; i < x.Count(); i++)
                {
                    if (x[i].Name == y[i].Name)
                    {
                        fres = true;
                    }
                    else
                    {
                        fres = false;
                        break;
                    }
                }
            }
            return fres;
        }

        int IEqualityComparer<List<ITerm>>.GetHashCode(List<ITerm> obj)
        {
            throw new NotImplementedException();
        }
    }
}
