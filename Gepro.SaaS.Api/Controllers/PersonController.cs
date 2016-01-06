using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace gepro.saas.api.Controllers
{
    public class PersonController : ApiController
    {
        Gepro.SaaS.Application.PersonApplication app = new Gepro.SaaS.Application.PersonApplication();

        [HttpGet]
        [Route("person")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, app.ListAll());
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
           
        }

        [HttpGet]
        [Route("person/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var item = app.ListById(id);

                if (item == null)
                    throw new KeyNotFoundException();

                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (KeyNotFoundException)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person not found");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("person/{id}")]
        public HttpResponseMessage Remove(int id)
        {
            try
            {
                app.Remove(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("person")]
        public HttpResponseMessage Add([FromBody] Gepro.SaaS.Domain.Entities.Person.Person person)
        {
            try
            {
                app.Add(person);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { controller = "Person", id = person.Id }));

                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            
        }

        [HttpPut]
        [Route("person")]
        public HttpResponseMessage Edit([FromBody] Gepro.SaaS.Domain.Entities.Person.Person person)
        {
            try
            {
                var item = app.ListById(person.Id);

                if (item == null)
                    throw new KeyNotFoundException();

                app.Update(person);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (KeyNotFoundException)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Person not found");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}