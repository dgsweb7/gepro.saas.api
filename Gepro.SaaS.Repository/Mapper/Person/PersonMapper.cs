using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gepro.SaaS.Domain;
using FluentNHibernate.Mapping;

namespace Gepro.SaaS.Repository.Mapper.Person
{
    public class PersonMapper : ClassMap<Domain.Entities.Person.Person>
    {
        public PersonMapper()
        {
            Id(Person => Person.Id).GeneratedBy.Identity();
            Map(Person => Person.Alias);
            Map(Person => Person.FirstName);
            Map(Person => Person.LastName);
            Map(Person => Person.CreatedAt);
            Map(Person => Person.CreatedBy);
            Map(Person => Person.UpdatedAt);
            Map(Person => Person.UpdatedBy);
            Map(Person => Person.Enabled);

        }
    }

}
