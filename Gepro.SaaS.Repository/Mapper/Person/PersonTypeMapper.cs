using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gepro.SaaS.Repository.Mapper.Person
{
    public class PersonTypeMapper : ClassMap<Domain.Entities.Person.PersonType>
    {
        public PersonTypeMapper()
        {
            Id(PersonType => PersonType.Id).GeneratedBy.Identity();
            Map(PersonType => PersonType.Description);
            Map(Person => Person.CreatedAt);
            Map(Person => Person.CreatedBy);
            Map(Person => Person.UpdatedAt);
            Map(Person => Person.UpdatedBy);
            Map(Person => Person.Enabled);
        }
    }
}
