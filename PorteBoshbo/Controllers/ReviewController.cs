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
    public class ReviewController : ApiController
    {
        [Route("api/reviews/update")]
        [HttpOptions]
        public HttpResponseMessage UpdateOptions()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
        [Route("api/reviews/add")]
        [HttpOptions]
        public HttpResponseMessage AddOptions()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }



        [Route("api/reviews")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = ReviewService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/reviews/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = ReviewService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/reviews/add")]
        [HttpPost]
        public HttpResponseMessage Add(ReviewDTO review)
        {
            if (ReviewService.Add(review))
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = review });

            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [Route("api/reviews/update")]
        [HttpPost]
        public HttpResponseMessage Update(ReviewDTO review)
        {
            if (ReviewService.Update(review))
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated", data = review });

            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [Route("api/reviews/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            if (ReviewService.Delete(id))
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Deleted" });

            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
}
