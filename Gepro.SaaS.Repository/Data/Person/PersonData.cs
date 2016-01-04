using Gepro.SaaS.Repository.Interface.Person;
using System.Collections.Generic;
using NHibernate;

namespace Gepro.SaaS.Repository.Data.Person
{
    public class PersonRepository : IPersonRepository
    {
        string hql = string.Empty;
        private ISession session;

        public PersonRepository()
        {
            this.session = Repository.Infrastructure.NHibernateHelper.AbreSession();
        }

        public IEnumerable<Domain.Entities.Person.Person> ListAll()
        {
            hql = "select p from Person p";
            IQuery query = session.CreateQuery(hql);
            return query.Enumerable<Domain.Entities.Person.Person>();
        }

        public Domain.Entities.Person.Person ListById(int id)
        {
            return session.Get<Domain.Entities.Person.Person>(id);
        }

        public void Add(Domain.Entities.Person.Person person)
        {
            ITransaction tx = session.BeginTransaction();
            session.Save(person);
            tx.Commit();
        }

        public void Update(Domain.Entities.Person.Person person)
        {
            ITransaction tx = session.BeginTransaction();
            session.Merge(person);
            tx.Commit();
        }

        public void Remove(Domain.Entities.Person.Person person)
        {
            ITransaction tx = session.BeginTransaction();
            session.Delete(person);
            tx.Commit();
        }
    }
}
