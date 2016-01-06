using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace gepro.saas.api.Controllers
{
    public class PersonTypeController : ApiController
    {
        Gepro.SaaS.Service.Person.PersonTypeService service = new Gepro.SaaS.Service.Person.PersonTypeService();

        [HttpGet]
        [Route("persontype")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, service.GetAll());
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpGet]
        [Route("persontype/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var item = service.ListById(id);

                if (item == null)
                    throw new KeyNotFoundException();

                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (KeyNotFoundException)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("persontype/{id}")]
        public HttpResponseMessage Remove(int id)
        {
            try
            {
                service.Remove(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("persontype")]
        public HttpResponseMessage Add([FromBody] Gepro.SaaS.Domain.Entities.Person.PersonType entity)
        {
            try
            {
                service.Add(entity);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { controller = "PersonType", id = entity.Id }));

                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpPut]
        [Route("persontype")]
        public HttpResponseMessage Edit([FromBody] Gepro.SaaS.Domain.Entities.Person.PersonType entity)
        {
            try
            {
                var item = service.ListById(entity.Id);

                if (item == null)
                    throw new KeyNotFoundException();

                service.Update(entity);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (KeyNotFoundException)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}