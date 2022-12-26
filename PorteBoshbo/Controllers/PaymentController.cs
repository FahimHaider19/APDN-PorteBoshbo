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
    public class PaymentController : ApiController
    {
        [Route("api/payments/update")]
        [HttpOptions]
        public HttpResponseMessage UpdateOptions()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
        [Route("api/payments/add")]
        [HttpOptions]
        public HttpResponseMessage AddOptions()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }



        [Route("api/payments")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = PaymentService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/payments/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = PaymentService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/payments/add")]
        [HttpPost]
        public HttpResponseMessage Add(PaymentDTO payment)
        {
            if (PaymentService.Add(payment))
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = payment });

            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [Route("api/payments/update")]
        [HttpPost]
        public HttpResponseMessage Update(PaymentDTO payment)
        {
            if (PaymentService.Update(payment))
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated", data = payment });

            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [Route("api/payments/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            if (PaymentService.Delete(id))
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Deleted" });

            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
}
