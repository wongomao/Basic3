using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polly;

namespace PollyPolly
{
    public class CalcService
    {
        public int CalculateAdd(int a, int b)
        {
            if (a > 1000)
            {
                Console.WriteLine("Inside CalculateAdd(). a > 1000!!");
                throw new ArgumentOutOfRangeException("a", a, "Value should be not greater than 1000");
            }

            if (b == 3)
            {
                Console.WriteLine("Inside CalculateAdd(). b is three - before throw");
                throw new Exception("b is three");
            }

            return a + b;
        }



        public int CalculateSubtractP(int a, int b)
        {
            var pollyInner = Policy<int>.Handle<ExceptionA>().Fallback<int>(() => 
            {
                Console.WriteLine("inner fallback");
                return -555;
            });


            var pollyReturn = pollyInner.ExecuteAndCapture(() =>
            {
                if (a < 0)
                    throw new ExceptionA();
                if (b < 0)
                    throw new ExceptionB();
                return a - b;
            });

            return pollyReturn.Result;
        }









        public int CalculateSubtract(int a, int b)
        {
            if (a < 0)
                throw new ExceptionA();
            if (b < 0)
                throw new ExceptionB();
            return a - b;
        }
    }
}
