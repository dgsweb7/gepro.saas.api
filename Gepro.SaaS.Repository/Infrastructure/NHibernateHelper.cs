using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg;
using System.Reflection;

namespace Gepro.SaaS.Repository.Infrastructure
{
    public class NHibernateHelper
    {
        private static ISessionFactory factory = CreateSessionFactory();

        private static ISessionFactory CreateSessionFactory()
        {
            Configuration cfg = new Configuration();
            cfg.Configure();
            ISessionFactory factory = Fluently.Configure(cfg).Mappings(x =>
            {
                x.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly());
            }).BuildSessionFactory();

            return factory;
        }

        public static ISession OpenConnection()
        {
            return factory.OpenSession();
        }
    }
}
