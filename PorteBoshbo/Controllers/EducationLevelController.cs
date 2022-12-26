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
    public class EducationLevelController : ApiController
    {
        [Route("api/educationLevels/update")]
        [HttpOptions]
        public HttpResponseMessage UpdateOptions()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
        [Route("api/educationLevels/add")]
        [HttpOptions]
        public HttpResponseMessage AddOptions()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }



        [Route("api/educationLevels")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = EducationLevelService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/educationLevels/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = EducationLevelService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/educationLevels/add")]
        [HttpPost]
        public HttpResponseMessage Add(EducationLevelDTO educationLevel)
        {
            if (EducationLevelService.Add(educationLevel))
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = educationLevel });

            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [Route("api/educationLevels/update")]
        [HttpPost]
        public HttpResponseMessage Update(EducationLevelDTO educationLevel)
        {
            if (EducationLevelService.Update(educationLevel))
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated", data = educationLevel });

            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [Route("api/educationLevels/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            if (EducationLevelService.Delete(id))
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Deleted" });

            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
}
