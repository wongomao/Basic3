using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Linq;
using System.Linq;
using System;
using System.Reflection;

namespace NH_Fundamentals
{
    class Program
    {




        static void Main(string[] args)
        {

            var cfg = new Configuration();
            cfg.DataBaseIntegration(x =>
            {
                x.ConnectionString = "Server=NORMAN-PC;Database=NHibernateDemo;Integrated Security=SSPI;";
                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2012Dialect>();
                //x.LogSqlInConsole = true;
            });
            cfg.AddAssembly(Assembly.GetExecutingAssembly());
            var sessionFactory = cfg.BuildSessionFactory();

            using (var session = sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {

                // perform database logic


                // -- insert --
                //var cust = new tCustomer()
                //{
                //    FirstName = "Sansa",
                //    LastName = "Stark"
                //};
                //session.Save(cust);
                //Console.WriteLine("New Id of the customer is {0}", cust.CustomerId);



                // -- read --

                //var customers = session.CreateCriteria<tCustomer>()
                //    .List<tCustomer>();

                // -- find & update --
                //var sansa = (from customer in session.Query<tCustomer>()
                //             where customer.FirstName.CompareTo("Sansa") == 0
                //             select customer).First();
                //sansa.LastName = "Starky";
                //session.Update(sansa);

                var customers = from customer in session.Query<tCustomer>()
                                //where customer.LastName.CompareTo("m") > 0
                                orderby customer.LastName
                                select customer;

                foreach (var customer in customers)
                {
                    Console.WriteLine("{0} {1}", customer.FirstName, customer.LastName);
                }


                tx.Commit();
            }
        }





    }
}
