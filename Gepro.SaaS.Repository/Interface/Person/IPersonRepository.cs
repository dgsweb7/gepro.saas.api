﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gepro.SaaS.Repository.Interface.Person
{
    public interface IPersonRepository
    {
        IEnumerable<Domain.Entities.Person.Person> ListAll();

    }
}
