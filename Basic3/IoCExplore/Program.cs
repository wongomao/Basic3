using Autofac;

namespace IoCExplore
{
    class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            // we need to register all of our components (classes) and expose their 
            // services (interfaces) so things can get wired up nicely.
            var builder = new ContainerBuilder();
            builder.RegisterType<ConsoleOutput>().As<IOutput>();
            builder.RegisterType<TodayWriter>().As<IDateWriter>();
            Container = builder.Build();

            // The WriteDate method is where we'll make use
            // of our dependency injection.
            WriteDate();
        }

        public static void WriteDate()
        {
            // Create the scope, resolve your IDateWriter,
            // use it, then dispose of the scope.
            using (var scope = Container.BeginLifetimeScope())
            {
                var writer = scope.Resolve<IDateWriter>();
                writer.WriteDate();
            }
        }
        /*
            Now when you run your program...

            The “WriteDate” method asks Autofac for an IDateWriter.
            Autofac sees that IDateWriter maps to TodayWriter so starts creating a TodayWriter.
            Autofac sees that the TodayWriter needs an IOutput in its constructor.
            Autofac sees that IOutput maps to ConsoleOutput so creates a new ConsoleOutput instance.
            Autofac uses the new ConsoleOutput instance to finish constructing the TodayWriter.
            Autofac returns the fully-constructed TodayWriter for “WriteDate” to consume.
         */
    }
}
