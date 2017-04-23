using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDI
{
    class Program
    {
        static void Main(string[] args)
        {
            //IMessageWriter writer = new ConsoleMessageWriter();
            IMessageWriter writer = new FileMessageWriter();
            var salutation = new Salutation(writer);
            salutation.Exclaim();
        }
    }
}
