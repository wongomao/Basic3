using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic3.CacheCache
{
    public class Vendor1
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return $"Name: {Name} Address: {Address}";
        }
    }
}
