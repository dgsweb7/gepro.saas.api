using System.Collections.Generic;
using System.Web.Http;

namespace gepro.saas.api.Controllers
{
    public class PersonController : ApiController
    {
        Gepro.SaaS.Application.PersonApplication app = new Gepro.SaaS.Application.PersonApplication();

        [HttpGet]
        [Route("person")]
        public IEnumerable<Gepro.SaaS.Domain.Entities.Person.Person> GetAll()
        {
           return app.ListAll();
        }

        [HttpGet]
        [Route("person/{id}")]
        public Gepro.SaaS.Domain.Entities.Person.Person GetById(int id)
        {
            return app.ListById(id);
        }

        [HttpDelete]
        [Route("person/{id}")]
        public void Remove(int id)
        {
            app.Remove(id);
        }

        [HttpPost]
        [Route("person")]
        public void Add([FromBody] Gepro.SaaS.Domain.Entities.Person.Person person)
        {
            app.Add(person);
        }

        [HttpPut]
        [Route("person")]
        public void Edit([FromBody] Gepro.SaaS.Domain.Entities.Person.Person person)
        {
            app.Update(person);
        }

    }
}