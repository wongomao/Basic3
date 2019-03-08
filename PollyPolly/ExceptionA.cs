using System;

namespace PollyPolly
{
    public class ExceptionA : Exception
    {
        public ExceptionA()
        {
            Console.WriteLine("Exception A");
        }
    }
}
