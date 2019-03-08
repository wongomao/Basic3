using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollyPolly
{
    class ExceptionB : Exception
    {
        public ExceptionB()
        {
            Console.WriteLine("Exception B");
        }
    }
}
