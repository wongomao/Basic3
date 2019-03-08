using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic3.CacheCache
{
    public class Vendor2
    {
        public string Name { get; set; }
        public string Addr { get; set; }
        public int Dollars { get; set; }

        public override string ToString()
        {
            return $"Name: {Name} Address:{Addr} Dollars:{Dollars.ToString()}";
        }
    }
}
