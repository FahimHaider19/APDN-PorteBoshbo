using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTOs;
using BLL.Services;

namespace PorteBoshbo.Controllers
{
    public class CourseController : ApiController
    {
        [Route("api/courses")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = CourseService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/courses/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = CourseService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/courses/add")]
        [HttpPost]
        public HttpResponseMessage Add(CourseDTO course)
        {
            if (CourseService.Add(course))
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = course });

            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [Route("api/courses/update")]
        [HttpPost]
        public HttpResponseMessage Update(CourseDTO course)
        {
            if (CourseService.Update(course))
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated", data = course });

            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [Route("api/courses/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            if (CourseService.Delete(id))
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Deleted"});

            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
}
