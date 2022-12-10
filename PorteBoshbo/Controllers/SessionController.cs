using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PorteBoshbo.Controllers
{
    public class SessionController : ApiController
    {
        [Route("api/sessions")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = SessionService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/sessions/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = SessionService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/sessions/add")]
        [HttpPost]
        public HttpResponseMessage Add(SessionDTO session)
        {
            if (SessionService.Add(session))
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = session });

            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [Route("api/sessions/update")]
        [HttpPost]
        public HttpResponseMessage Update(SessionDTO session)
        {
            if (SessionService.Update(session))
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated", data = session });

            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [Route("api/sessions/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            if (SessionService.Delete(id))
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Deleted" });

            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
}
