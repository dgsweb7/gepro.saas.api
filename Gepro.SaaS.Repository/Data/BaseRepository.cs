using Gepro.SaaS.Repository.Interface;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gepro.SaaS.Repository.Data
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private ISession session;

        public BaseRepository()
        {
            this.session = Repository.Infrastructure.NHibernateHelper.AbreSession();
        }

        public void Add(T entity)
        {
            ITransaction tx = session.BeginTransaction();
            session.Save(entity);
            tx.Commit();
        }

        public void Edit(T entity)
        {
            ITransaction tx = session.BeginTransaction();
            session.Merge(entity);
            tx.Commit();
        }

        public IEnumerable<T> GetAll()
        {
            return session.Query<T>();
        }

        public T GetById(int id)
        {
            return session.Get<T>(id);
        }

        public void Remove(T entity)
        {
            ITransaction tx = session.BeginTransaction();
            session.Delete(entity);
            tx.Commit();
        }
    }
}
