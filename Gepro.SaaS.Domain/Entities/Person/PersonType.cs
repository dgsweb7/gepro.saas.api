using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gepro.SaaS.Domain.Entities.Person
{
    public class PersonType : BaseEntity
    {
        public virtual String Type { get; set; }
    }
}
