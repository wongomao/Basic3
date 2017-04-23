using Autofac;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DependInject2
{
    // Tutorial from:
    // https://www.codeproject.com/Articles/25380/Dependency-Injection-with-Autofac
    //


    class Program
    {
        static void Main(string[] args)
        {
            // we need to register all of our components (classes) and expose their 
            // services (interfaces) so things can get wired up nicely.
            var builder = new ContainerBuilder();

            // ------------------------------------------------------------------------------------
            // register a component created with an expression
            builder.Register(c => new MemoChecker(
                c.Resolve<IQueryable<Memo>>(),
                c.Resolve<IMemoDueNotifier>()));
            builder.Register(c => new PrintingNotifier(c.Resolve<TextWriter>())).As<IMemoDueNotifier>();
            // register component instances
            var memos = GetDataStore();
            builder.RegisterInstance(memos);
            builder.RegisterInstance(Console.Out).As<TextWriter>().ExternallyOwned();


            // ------------------------------------------------------------------------------------
            // OR register a component with its implementation type
            //builder.RegisterType<MemoChecker>();
            // or use auto-wiring using Assembly.GetExecutingAssembly()


            using (var container = builder.Build())
            {
                container.Resolve<MemoChecker>().CheckNow();
            }
        }

        public static IQueryable<Memo> GetDataStore()
        {
            IQueryable<Memo> memos = new List<Memo>()
            {
                new Memo {Title = "memo 1", DueAt = new DateTime(2017,4,10) },
                new Memo {Title = "memo 2", DueAt = new DateTime(2017,4,11) },
                new Memo {Title = "memo 3", DueAt = new DateTime(2017,7,30) }
            }.AsQueryable();
            return memos;
        }
    }
}
