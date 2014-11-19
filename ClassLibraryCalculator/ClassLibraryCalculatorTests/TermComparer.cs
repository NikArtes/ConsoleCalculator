using System;
using System.Collections.Generic;
using ClassLibraryCalculator;

namespace ClassLibraryCalculatorTests
{
    class TermComparer : IEqualityComparer<ITerm>
    {

        bool IEqualityComparer<ITerm>.Equals(ITerm x, ITerm y)
        {
            if (x.Name == y.Name)
                return true;
            return false;
        }
        public int GetHashCode(ITerm obj)
        {
            throw new NotImplementedException();
        }
    }
}
