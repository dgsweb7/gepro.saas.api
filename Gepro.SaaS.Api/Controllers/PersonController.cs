﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace gepro.saas.api.Controllers
{
    public class PersonController : ApiController
    {
        Gepro.SaaS.Service.PersonService service = new Gepro.SaaS.Service.PersonService();

        [HttpGet]
        [Route("person")]
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
        [Route("person/{id}")]
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
        [Route("person/{id}")]
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
        [Route("person")]
        public HttpResponseMessage Add([FromBody] Gepro.SaaS.Domain.Entities.Person.Person entity)
        {
            try
            {
                service.Add(entity);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { controller = "Person", id = entity.Id }));

                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpPut]
        [Route("person")]
        public HttpResponseMessage Edit([FromBody] Gepro.SaaS.Domain.Entities.Person.Person entity)
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