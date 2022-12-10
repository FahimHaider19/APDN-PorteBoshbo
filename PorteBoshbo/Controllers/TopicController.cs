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
    public class TopicController : ApiController
    {
        [Route("api/topics")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = TopicService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/topics/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = TopicService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/topics/add")]
        [HttpPost]
        public HttpResponseMessage Add(TopicDTO topic)
        {
            if (TopicService.Add(topic))
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = topic });

            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [Route("api/topics/update")]
        [HttpPost]
        public HttpResponseMessage Update(TopicDTO topic)
        {
            if (TopicService.Update(topic))
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated", data = topic });

            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [Route("api/topics/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            if (TopicService.Delete(id))
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Deleted" });

            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
}
