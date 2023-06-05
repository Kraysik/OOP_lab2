using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class SoftwarePriceComparer : IComparer<Software>
    {
        public int Compare(Software? x, Software? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            return x.Price.CompareTo(y.Price);
        }
    }
}
