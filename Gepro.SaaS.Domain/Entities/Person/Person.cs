using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gepro.SaaS.Domain.Entities.Person
{
    public class Person : BaseEntity
    {
        public virtual string Alias { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }


    }
}
