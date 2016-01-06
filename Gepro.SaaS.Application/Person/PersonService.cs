using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gepro.SaaS.Service
{
    public class PersonService
    {
        private Repository.Data.Person.PersonRepository repository = new Repository.Data.Person.PersonRepository();

        public PersonService()
        {

        }

        public IEnumerable<Gepro.SaaS.Domain.Entities.Person.Person> GetAll()
        {
            return repository.GetAll();
        }

        public Gepro.SaaS.Domain.Entities.Person.Person ListById(int id)
        {
            return repository.GetById(id);
        }

        public void Remove(int id)
        {
            repository.Remove(repository.GetById(id));
        }

        public void Add(Gepro.SaaS.Domain.Entities.Person.Person entity)
        {
            repository.Add(entity);
        }

        public void Update(Gepro.SaaS.Domain.Entities.Person.Person entity)
        {
            repository.Edit(entity);
        }

    }
}
