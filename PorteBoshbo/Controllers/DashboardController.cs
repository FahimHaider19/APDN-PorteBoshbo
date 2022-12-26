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
    public class DashboardController : ApiController
    {

        [Route("api/dashboard")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var tcourse = CourseService.total();
            var tuser = UserService.total();
            var tdept = DepartmentService.total();
            var ttopic = TopicService.total();
            IDictionary<string, int> totals = new Dictionary<string, int>();
            totals.Add("Total courses", tcourse);
            totals.Add("Total users", tuser);
            totals.Add("Total departments", tdept);
            totals.Add("Total topics", ttopic);

            return Request.CreateResponse(HttpStatusCode.OK, totals);
        }

        [Route("api/top")]
        [HttpGet]

        public HttpResponseMessage Top()
        {
            var teacher = ReviewService.top();
            return Request.CreateResponse(HttpStatusCode.OK, teacher);
        }




    }
}
