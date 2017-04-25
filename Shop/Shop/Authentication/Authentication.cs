using LoginRegister.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace LoginRegister {

    public class AuthenticationAttribute : AuthorizationFilterAttribute {

        public override void OnAuthorization(HttpActionContext actionContext) {
            if (actionContext.Request.Headers.Authorization.Parameter == null) {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            } else {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                string[] usernamePasswordArray = decodedAuthenticationToken.Split(':');
                string username = usernamePasswordArray[0];
                string password = usernamePasswordArray[1];
                CheckUser checkUser = new CheckUser();
                if (checkUser.login(username, password)) {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                } else {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}