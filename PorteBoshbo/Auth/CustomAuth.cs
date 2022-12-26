using BLL.Services;
using DAL.Repos;
using PorteBoshbo.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace PorteBoshbo.Auth
{
    public class CustomAuth : AuthorizationFilterAttribute
    {
        public string Roles="";


        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var authHeader = actionContext.Request.Headers.Authorization;
            if (authHeader == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.NotFound, "No token supplied");

            }
            else
            {
                string tokenString = authHeader.ToString();
                var token = AuthService.GetToken(tokenString);
                var user = UserService.Get(token.UserId);
                bool authorized = false;
                foreach(string s in Roles.Split(',', ' ')) 
                {
                    if(s!="" && s.ToLower()==user.Role.ToLower()) 
                        authorized = true;
                }

                var rs = AuthService.CheckValidityToken(tokenString);
                if (!authorized || !rs)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized Access");
                }
            }
            base.OnAuthorization(actionContext);
        }
    }
}