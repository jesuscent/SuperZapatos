using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WebSuperZapatos.App_Start
{
    public class AuthorizationHeaderHandler : DelegatingHandler
    {
  
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Initialization.  
            IEnumerable<string> apiKeyHeaderValues = null;
            AuthenticationHeaderValue authorization = request.Headers.Authorization;
            string userName = null;
            string password = null;
            // Verification.  
            if (request.Headers.TryGetValues("Authorization", out apiKeyHeaderValues) &&
              !string.IsNullOrEmpty(authorization.Parameter))
            {
                var apiKeyHeaderValue = apiKeyHeaderValues.First();
                // Get the auth token  
                string authToken = authorization.Parameter;
                // Decode the token from BASE64  
                string decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));
                // Extract username and password from decoded token  
                userName = decodedToken.Substring(0, decodedToken.IndexOf(":"));
                password = decodedToken.Substring(decodedToken.IndexOf(":") + 1);
                // Verification.  
                if (userName.Equals("my_user") && password.Equals("my_password"))
                {
                    // Setting  
                    var identity = new GenericIdentity(userName);
                    SetPrincipal(new GenericPrincipal(identity, null));
                }
            }
            // Info.  
            return base.SendAsync(request, cancellationToken);
        }      
        private static void SetPrincipal(IPrincipal principal)
        {
            // setting.  
            Thread.CurrentPrincipal = principal;
            // Verification.  
            if (HttpContext.Current != null)
            {
                // Setting.  
                HttpContext.Current.User = principal;
            }
        }
     
    }
}