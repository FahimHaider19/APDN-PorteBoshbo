using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using PorteBoshbo.Auth;

namespace PorteBoshbo.Controllers
{
    public class UserController : ApiController
    {
        [Route("api/users/update")]
        [HttpOptions]
        public HttpResponseMessage UpdateOptions()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
        [Route("api/users/add")]
        [HttpOptions]
        public HttpResponseMessage AddOptions()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }



        [CustomAuth(Roles="user")]
        [Route("api/users")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = UserService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/users/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = UserService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/users/add")]
        [HttpPost]
        public HttpResponseMessage Add(UserDTO user)
        {
            if (UserService.Add(user))
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = user });

            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [Route("api/users/update")]
        [HttpPost]
        public HttpResponseMessage Update(UserDTO user)
        {
            //var v = UserService.Update(user);
            if (UserService.Update(user))
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated", data = user });

            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [Route("api/users/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            if (UserService.Delete(id))
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Deleted" });

            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        internal static object GetShort()
        {
            throw new NotImplementedException();
        }
    }
}
