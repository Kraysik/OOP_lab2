using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Software : IComparable<Software>
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }
        public float Price { get; set; }

        public int CompareTo(Software? other)
        {
            if (other == null) return 1;
            return this.Size.CompareTo(other.Size);
        }
    }
}
