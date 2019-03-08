using System;
using Polly;

namespace PollyPolly
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // DoPollyRetry();
            DoPollyInsidePolly();
        }

        // ========================================================================================

        public static void DoPollyInsidePolly()
        {
            try
            {
                var pollyOuter = Policy.Handle<ExceptionA>().Fallback(() => { Console.WriteLine("outer fallback"); });
                
                var svc = new CalcService();
                var a = -4;
                var b = -2;
                pollyOuter.Execute(() => Console.WriteLine($"a({a}) - b({b}) = {svc.CalculateSubtractP(a, b)}"));
                
            }
            catch (Exception e)
            {
                Console.WriteLine("-- Inside main catch --");
            }
            
            Console.ReadLine();
        }















        // ========================================================================================

        public static void DoPollyRetry()
        {
            var service = new CalcService();
            try
            {
                int a = 6;
                int b = 9;
                Console.WriteLine($"{a} + {b} = {service.CalculateAdd(a, b)}");
                a = 6;
                b = 9000;
                Console.WriteLine($"{a} + {b} = {service.CalculateAdd(a, b)}");
                a = 6;
                b = 3;
                Console.WriteLine($"{a} + {b} = {service.CalculateAdd(a, b)}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("== == == == == == == == == == == == == == == == == == == == ==");
            Console.WriteLine();

            var policy = Policy.Handle<ArgumentOutOfRangeException>().Retry(3);
            try
            {
                policy.Execute(() =>
                    {
                        int a = 6;
                        int b = 9;
                        Console.WriteLine($"{a} + {b} = {service.CalculateAdd(a, b)}");
                        a = 6;
                        b = 9000;
                        Console.WriteLine($"{a} + {b} = {service.CalculateAdd(a, b)}");
                        a = 6;
                        b = 3;
                        Console.WriteLine($"{a} + {b} = {service.CalculateAdd(a, b)}");
                    }
                );

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            

            Console.ReadLine();
        }
    }
}
