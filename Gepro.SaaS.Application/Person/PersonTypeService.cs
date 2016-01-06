using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gepro.SaaS.Service.Person
{
    public class PersonTypeService
    {
        private Repository.Data.Person.PersonTypeRepository repository = new Repository.Data.Person.PersonTypeRepository();

        public PersonTypeService()
        {

        }

        public IEnumerable<Gepro.SaaS.Domain.Entities.Person.PersonType> GetAll()
        {
            return repository.GetAll();
        }

        public Gepro.SaaS.Domain.Entities.Person.PersonType ListById(int id)
        {
            return repository.GetById(id);
        }

        public void Remove(int id)
        {
            repository.Remove(repository.GetById(id));
        }

        public void Add(Gepro.SaaS.Domain.Entities.Person.PersonType entity)
        {
            repository.Add(entity);
        }

        public void Update(Gepro.SaaS.Domain.Entities.Person.PersonType entity)
        {
            repository.Edit(entity);
        }
    }
}
