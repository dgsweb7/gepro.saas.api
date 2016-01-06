using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gepro.SaaS.Application
{
    public class PersonApplication
    {
        private Repository.Data.Person.PersonRepository repository = new Repository.Data.Person.PersonRepository();

        public PersonApplication()
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

        public void Add(Gepro.SaaS.Domain.Entities.Person.Person person)
        {
            repository.Add(person);
        }

        public void Update(Gepro.SaaS.Domain.Entities.Person.Person person)
        {
            repository.Edit(person);
        }

    }
}
