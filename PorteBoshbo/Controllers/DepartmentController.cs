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
    public class DepartmentController : ApiController
    {
        [Route("api/departments/update")]
        [HttpOptions]
        public HttpResponseMessage UpdateOptions()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
        [Route("api/departments/add")]
        [HttpOptions]
        public HttpResponseMessage AddOptions()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }



        [Route("api/departments")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = DepartmentService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/departments/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = DepartmentService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/departments/add")]
        [HttpPost]
        public HttpResponseMessage Add(DepartmentDTO department)
        {
            if (DepartmentService.Add(department))
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = department });

            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [Route("api/departments/update")]
        [HttpPost]
        public HttpResponseMessage Update(DepartmentDTO department)
        {
            if (DepartmentService.Update(department))
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated", data = department });

            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [Route("api/departments/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            if (DepartmentService.Delete(id))
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Deleted" });

            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
}
