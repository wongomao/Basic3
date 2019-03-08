using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basic3.CacheCache;

namespace Basic3
{
    class Program
    {
        static void Main(string[] args)
        {
            DoCaching();
        }

        static void DoCaching()
        {
            var v1Cache = new V1Cache();
            var v11 = new Vendor1() {Name = "Matt", Address = "1001 Sego Lily Drive"};
            v1Cache.Add("a", v11);
            var v12 = new Vendor1() { Name = "Ken", Address = "1002 Sego Lily Drive" };
            v1Cache.Add("b", v12);

            var v21 = new Vendor2() {Name = "Sunil", Addr = "1003 Sego Lily Drive", Dollars = 17};
            v1Cache.Add("c", v21);
            var v22 = new Vendor2() { Name = "Anil", Addr = "1004 Sego Lily Drive", Dollars = 17 };
            v1Cache.Add("d", v22);

            Console.WriteLine(v1Cache.GetAs<Vendor1>("a"));
            Console.WriteLine(v1Cache.GetAs<Vendor2>("a"));

            Console.ReadLine();
        }

        static void Nop()
        {
            DateTime2 x = new DateTime2();
        }
    }
}
